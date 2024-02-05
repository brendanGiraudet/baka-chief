using bakaChiefApplication.Enums;

namespace bakaChiefApplication.Constants
{
    public class PagesUrl
    {
        #region Nutriments
        public static string NutrimentsPathUrl => "/nutriments";
        public static string GetNutrimentFormUrl(FormMode formMode, string? nutrimentId) => nutrimentId == null ? $"{NutrimentsPathUrl}/{formMode}" : $"{NutrimentsPathUrl}/{nutrimentId}/{formMode}";
        #endregion
        
        #region Ingredients
        public static string IngredientsPathUrl => "/ingredients";
        
        public static string GetIngredientFormUrl(FormMode formMode, string? ingredientId = null) => ingredientId == null ? $"{IngredientsPathUrl}/{formMode}" : $"{IngredientsPathUrl}/{ingredientId}/{formMode}";
        
        public static string GetIngredientDetailsUrl(string ingredientId) => $"{IngredientsPathUrl}/{ingredientId}/details";
        #endregion
        
        #region Recips
        public static string RecipsPathUrl => "/recips";
        
        public static string GetRecipFormUrl(FormMode formMode, string? recipId = null) => recipId == null ? $"{RecipsPathUrl}/{formMode}" : $"{RecipsPathUrl}/{recipId}/{formMode}";
        
        public static string GetRecipDetailsUrl(string recipId) => $"{RecipsPathUrl}/{recipId}/details";
        #endregion
        
        #region SelectedRecipHistories
        public static string SelectedRecipHistoriesPathUrl => "/selectedRecipHistories";
        public static string GetSelectedRecipHistoryUrl(string Id) =>$"{SelectedRecipHistoriesPathUrl}/{Id}";
        #endregion

        #region RecipTypes
        public static string RecipTypesPathUrl => "/recipTypes";
        public static string GetRecipTypeFormUrl(FormMode formMode, string? recipTypeId) => recipTypeId == null ? $"{RecipTypesPathUrl}/{formMode}" : $"{RecipTypesPathUrl}/{recipTypeId}/{formMode}";
        #endregion
    }
}
