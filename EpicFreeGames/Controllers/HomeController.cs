using EpicFreeGames.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static EpicFreeGames.Consts;

namespace EpicFreeGames.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IMemoryCache cache, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _cache = cache;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var now = DateTimeOffset.UtcNow.ToOffset(EasyZone8);

            var freeGames = await _cache.GetOrCreateAsync("FreeGames", async (entry) =>
            {
                if (now.Hour < 23)
                {
                    entry.SetAbsoluteExpiration(now.Date.AddHours(23));
                }
                else
                {
                    entry.SetAbsoluteExpiration(now.Date.AddDays(1).AddHours(23));
                }
                var response = await client.GetFromJsonAsync<EpicResponseModel>("https://store-site-backend-static-ipv4.ak.epicgames.com/freeGamesPromotions?locale=zh-CN&country=CA&allowCountries=CA");

                return response;
            });

            var currentFreeGames = freeGames.Data.Catalog.SearchStore.Elements.Where(game =>
            {
                var promotions = game?.Promotions?.PromotionalOffers;
                if (promotions is { Count: > 0 }
                && DateTimeOffset.TryParse(promotions[0].PromotionalOffers[0].StartDate, out var startDate)
                && DateTimeOffset.TryParse(promotions[0].PromotionalOffers[0].EndDate, out var endDate))
                {
                    startDate = startDate.ToOffset(EasyZone8);
                    endDate = endDate.ToOffset(EasyZone8);
                    if (now > startDate && now < endDate)
                    {
                        return true;
                    }
                }

                return false;
            }).Select(game =>
            {
                var imageUrl = game.KeyImages.Find(keyImage =>
                {
                    return keyImage.Type == "Thumbnail";
                })?.Url ?? null;

                imageUrl ??= game.KeyImages.FirstOrDefault()?.Url ?? "";

                var promotion = game.Promotions.PromotionalOffers[0].PromotionalOffers[0];
                var startDate = DateTimeOffset.Parse(promotion.StartDate);
                var endDate = DateTimeOffset.Parse(promotion.EndDate);
                var pageSlug = game.OfferMappings.Find(v => v.PageType == "productHome")?.PageSlug ?? "";

                return new FreeGame
                {
                    Title = game.Title,
                    ImageUrl = imageUrl,
                    PageSlug = pageSlug,
                    Description = game.Description,
                    EndDate = endDate,
                    StartDate = startDate,
                };
            }).ToList();

            var twoFreeGamesInWeek = freeGames.Data.Catalog.SearchStore.Elements.FindAll(game =>
            {
                if (game?.Promotions?.UpcomingPromotionalOffers is null or { Count: 0 })
                {
                    return false;
                }
                var promotions = game?.Promotions?.UpcomingPromotionalOffers?[0]?.PromotionalOffers;
                if (promotions is { Count: > 0 } && DateTimeOffset.TryParse(promotions[0].StartDate, out var startDate))
                {
                    startDate = startDate.ToOffset(EasyZone8);
                    if (startDate > now)
                    {
                        return true;
                    }
                }

                return false;
            }).Take(2).Select(game =>
            {
                var imageUrl = game.KeyImages.Find(keyImage =>
                {
                    return keyImage.Type == "Thumbnail";
                })?.Url ?? null;

                imageUrl ??= game.KeyImages.FirstOrDefault()?.Url ?? "";

                var promotion = game.Promotions.UpcomingPromotionalOffers[0].PromotionalOffers[0];
                var startDate = DateTimeOffset.Parse(promotion.StartDate);
                var endDate = DateTimeOffset.Parse(promotion.EndDate);
                var pageSlug = game.OfferMappings.Find(v => v.PageType == "productHome")?.PageSlug ?? "";

                return new FreeGame
                {
                    Title = game.Title,
                    ImageUrl = imageUrl,
                    PageSlug = pageSlug,
                    Description = game.Description,
                    EndDate = endDate,
                    StartDate = startDate,
                };
            });

            currentFreeGames.AddRange(twoFreeGamesInWeek);
            currentFreeGames = [.. currentFreeGames.OrderBy(game => game.StartDate)];

            var model = new HomeViewModel
            {
                FreeGames = currentFreeGames,
            };
            return View(model);
        }
    }
}
