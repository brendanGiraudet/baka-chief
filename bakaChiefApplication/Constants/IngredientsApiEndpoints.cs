namespace bakaChiefApplication.Constants
{
    public static class IngredientsApiEndpoints
    {
        public const string BasePath = "/api/ingredients";

        public const string GetAllIngredient = BasePath;
        public static string GetIngredientById(string id) => $"{BasePath}/{id}";
        public const string CreateIngredient = BasePath;
        public static string UpdateIngredient(string id) => $"{BasePath}/{id}";
        public static string DeleteIngredient(string id) => $"{BasePath}/{id}";
    }
}
