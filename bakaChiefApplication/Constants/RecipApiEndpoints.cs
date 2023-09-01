namespace bakaChiefApplication.Constants
{
    public static class RecipApiEndpoints
    {
        public const string BasePath = "/api/recips";

        public const string GetAllRecip = BasePath;
        public static string GetRecipById(string id) => $"{BasePath}/{id}";
        public const string CreateRecip = BasePath;
        public static string UpdateRecip(string id) => $"{BasePath}/{id}";
        public static string DeleteRecip(string id) => $"{BasePath}/{id}";
    }
}
