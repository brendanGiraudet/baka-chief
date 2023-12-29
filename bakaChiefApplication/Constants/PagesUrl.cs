using bakaChiefApplication.Enums;

namespace bakaChiefApplication.Constants
{
    public class PagesUrl
    {
        #region Nutriments
        public static string NutrimentsPathUrl => "/nutriments";
        public static string GetNutrimentFormUrl(FormMode formMode) => $"{NutrimentsPathUrl}/{formMode}";
        #endregion

        public static string GetRecipFormUrl(FormMode formMode, string? recipId = null) => recipId != null ? $"/recips/{formMode}/{recipId}" : $"/recips/{formMode}";

        public static string RecipsUrl => $"/recips";

        public static string ProductsUrl => "/products";
        
        public static string GetProductDetailsUrl(string code) => $"{ProductsUrl}/{code}/details";
    }
}
