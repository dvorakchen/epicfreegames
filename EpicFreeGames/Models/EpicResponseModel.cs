using System.Text.Json.Serialization;

namespace EpicFreeGames.Models
{

    public class AppliedRule
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("discountSetting")]
        public DiscountSetting DiscountSetting { get; set; }
    }

    public class Catalog
    {
        [JsonPropertyName("searchStore")]
        public SearchStore SearchStore { get; set; }
    }

    public class CatalogNs
    {
        [JsonPropertyName("mappings")]
        public List<Mapping> Mappings { get; set; }
    }

    public class Category
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }
    }

    public class CurrencyInfo
    {
        [JsonPropertyName("decimals")]
        public int Decimals { get; set; }
    }

    public class CustomAttribute
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("Catalog")]
        public Catalog Catalog { get; set; }
    }

    public class DiscountSetting
    {
        [JsonPropertyName("discountType")]
        public string DiscountType { get; set; }

        [JsonPropertyName("discountPercentage")]
        public int DiscountPercentage { get; set; }
    }

    public class Element
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("namespace")]
        public string Namespace { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("effectiveDate")]
        public string EffectiveDate { get; set; }

        [JsonPropertyName("offerType")]
        public string OfferType { get; set; }

        [JsonPropertyName("expiryDate")]
        public object ExpiryDate { get; set; }

        [JsonPropertyName("viewableDate")]
        public string ViewableDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("isCodeRedemptionOnly")]
        public bool IsCodeRedemptionOnly { get; set; }

        [JsonPropertyName("keyImages")]
        public List<KeyImage> KeyImages { get; set; }

        [JsonPropertyName("seller")]
        public Seller Seller { get; set; }

        [JsonPropertyName("productSlug")]
        public string ProductSlug { get; set; }

        [JsonPropertyName("urlSlug")]
        public string UrlSlug { get; set; }

        [JsonPropertyName("url")]
        public object Url { get; set; }

        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }

        [JsonPropertyName("customAttributes")]
        public List<CustomAttribute> CustomAttributes { get; set; }

        [JsonPropertyName("categories")]
        public List<Category> Categories { get; set; }

        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; }

        [JsonPropertyName("catalogNs")]
        public CatalogNs CatalogNs { get; set; }

        [JsonPropertyName("offerMappings")]
        public List<OfferMapping> OfferMappings { get; set; }

        [JsonPropertyName("price")]
        public Price Price { get; set; }

        [JsonPropertyName("promotions")]
        public Promotions Promotions { get; set; }
    }

    public class Error
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("locations")]
        public List<Location> Locations { get; set; }

        [JsonPropertyName("correlationId")]
        public string CorrelationId { get; set; }

        [JsonPropertyName("serviceResponse")]
        public string ServiceResponse { get; set; }

        [JsonPropertyName("stack")]
        public object Stack { get; set; }

        [JsonPropertyName("path")]
        public List<object> Path { get; set; }
    }

    public class Extensions
    {
    }

    public class FmtPrice
    {
        [JsonPropertyName("originalPrice")]
        public string OriginalPrice { get; set; }

        [JsonPropertyName("discountPrice")]
        public string DiscountPrice { get; set; }

        [JsonPropertyName("intermediatePrice")]
        public string IntermediatePrice { get; set; }
    }

    public class Item
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("namespace")]
        public string Namespace { get; set; }
    }

    public class KeyImage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class LineOffer
    {
        [JsonPropertyName("appliedRules")]
        public List<AppliedRule> AppliedRules { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("line")]
        public int Line { get; set; }

        [JsonPropertyName("column")]
        public int Column { get; set; }
    }

    public class Mapping
    {
        [JsonPropertyName("pageSlug")]
        public string PageSlug { get; set; }

        [JsonPropertyName("pageType")]
        public string PageType { get; set; }
    }

    public class OfferMapping
    {
        [JsonPropertyName("pageSlug")]
        public string PageSlug { get; set; }

        [JsonPropertyName("pageType")]
        public string PageType { get; set; }
    }

    public class Paging
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

    public class Price
    {
        [JsonPropertyName("totalPrice")]
        public TotalPrice TotalPrice { get; set; }

        [JsonPropertyName("lineOffers")]
        public List<LineOffer> LineOffers { get; set; }
    }

    public class PromotionalOffer
    {
        [JsonPropertyName("promotionalOffers")]
        public List<PromotionalOffer> PromotionalOffers { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("discountSetting")]
        public DiscountSetting DiscountSetting { get; set; }
    }

    public class Promotions
    {
        [JsonPropertyName("promotionalOffers")]
        public List<PromotionalOffer> PromotionalOffers { get; set; }

        [JsonPropertyName("upcomingPromotionalOffers")]
        public List<UpcomingPromotionalOffer> UpcomingPromotionalOffers { get; set; }
    }

    public class EpicResponseModel
    {
        [JsonPropertyName("errors")]
        public List<Error> Errors { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }

        [JsonPropertyName("extensions")]
        public Extensions Extensions { get; set; }
    }

    public class SearchStore
    {
        [JsonPropertyName("elements")]
        public List<Element> Elements { get; set; }

        [JsonPropertyName("paging")]
        public Paging Paging { get; set; }
    }

    public class Seller
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Tag
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

    public class TotalPrice
    {
        [JsonPropertyName("discountPrice")]
        public int DiscountPrice { get; set; }

        [JsonPropertyName("originalPrice")]
        public int OriginalPrice { get; set; }

        [JsonPropertyName("voucherDiscount")]
        public int VoucherDiscount { get; set; }

        [JsonPropertyName("discount")]
        public int Discount { get; set; }

        [JsonPropertyName("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("currencyInfo")]
        public CurrencyInfo CurrencyInfo { get; set; }

        [JsonPropertyName("fmtPrice")]
        public FmtPrice FmtPrice { get; set; }
    }

    public class UpcomingPromotionalOffer
    {
        [JsonPropertyName("promotionalOffers")]
        public List<PromotionalOffer> PromotionalOffers { get; set; }
    }


}
