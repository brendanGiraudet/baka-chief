namespace bakaChiefApplication.Constants
{
    public static class NutrimentTypeApiEndpoints
    {
        public const string BasePath = "/api/nutrimenttypes";

        public const string GetAllNutrimentTypes = BasePath;
        public static string GetNutrimentTypeById(string id) => $"{BasePath}/{id}";
        public const string CreateNutrimentType = BasePath;
        public static string UpdateNutrimentType(string id) => $"{BasePath}/{id}";
        public static string DeleteNutrimentType(string id) => $"{BasePath}/{id}";
    }
}
