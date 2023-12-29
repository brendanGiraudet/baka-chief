namespace bakaChiefApplication.Constants;

public static class NutrimentsApiEndpoints
{
    public const string BasePath = "/odata/Nutriments";

    public static string GetNutrimentsUrl(int top, int skip) => $"{BasePath}?$top={top}&$skip={skip}&$orderby=name";
   
    public static string GetNutrimentsByNameUrl(int top, int skip, string name) => $"{GetNutrimentsUrl(top,skip)}&$filter=startswith(name, '{name}') eq true";
}
