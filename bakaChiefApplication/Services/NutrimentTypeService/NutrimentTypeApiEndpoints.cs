namespace bakaChiefApplication.Services.NutrimentTypeService
{
    public static class NutrimentTypeApiEndpoints
    {
        public const string GetAllNutrimentTypes = "/nutrimenttype";
        public static string GetNutrimentTypeById(string id) => $"/nutrimenttype/{id}";
        public const string CreateNutrimentType = "/nutrimenttype";
        public static string UpdateNutrimentType(string id) => $"/nutrimenttype/{id}";
        public static string DeleteNutrimentType(string id) => $"/nutrimenttype/{id}";
    }
}
