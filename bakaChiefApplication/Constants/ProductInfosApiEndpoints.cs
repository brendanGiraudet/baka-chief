namespace bakaChiefApplication.Constants;

public static class ProductInfosApiEndpoints
{
    public const string BasePath = "/odata/ProductInfos";

    public static string GetProductInfosUrl(int top, int skip) => $"{BasePath}?$top={top}&$skip={skip}&$filter=countries eq 'France'&$orderby=product_name";
   
    public static string GetProductInfosByNameUrl(int top, int skip, string name) => $"{BasePath}?$top={top}&$skip={skip}&$filter=countries eq 'France' and startswith(product_name, '{name}') eq true &$orderby=product_name";
}
