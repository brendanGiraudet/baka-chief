namespace bakaChiefApplication.Constants;

public static class ProductInfosApiEndpoints
{
    public const string BasePath = "/odata/ProductInfos";

    public static string GetProductInfosUrl(int top, int skip) => $"{BasePath}?$top={top}&$skip={skip}&$filter=countries eq 'France'&$orderby=product_name";


}
