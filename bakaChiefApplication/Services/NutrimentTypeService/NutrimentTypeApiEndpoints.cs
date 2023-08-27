namespace bakaChiefApplication.Services.NutrimentTypeService
{
    public static class NutrimentTypeApiEndpoints
    {
        public const string BasePath = "/api/nutrimenttype";

        public const string GetAllNutrimentTypes = BasePath;
        public static string GetNutrimentTypeById(string id) => $"{BasePath}/{id}";
        public const string CreateNutrimentType = BasePath;
        public static string UpdateNutrimentType(string id) => $"{BasePath}/{id}";
        public static string DeleteNutrimentType(string id) => $"{BasePath}/{id}";
    }
}
