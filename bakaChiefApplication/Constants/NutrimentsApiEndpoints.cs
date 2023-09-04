namespace bakaChiefApplication.Constants
{
    public static class NutrimentsApiEndpoints
    {
        public const string BasePath = "/api/nutriments";

        public const string GetAllNutrimentTypes = BasePath;
        public static string GetNutrimentTypeById(string id) => $"{BasePath}/{id}";
        public const string CreateNutrimentType = BasePath;
        public static string UpdateNutrimentType(string id) => $"{BasePath}/{id}";
        public static string DeleteNutrimentType(string id) => $"{BasePath}/{id}";
    }
}
