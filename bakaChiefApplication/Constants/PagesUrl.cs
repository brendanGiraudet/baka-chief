using bakaChiefApplication.Enums;

namespace bakaChiefApplication.Constants
{
    public class PagesUrl
    {
        #region Nutriments
        public static string NutrimentsPathUrl => "/nutriments";
        public static string GetNutrimentFormUrl(FormMode formMode) => $"{NutrimentsPathUrl}/{formMode}";
        public static string GetNutrimentFormUrl(FormMode formMode, string? nutrimentId) => nutrimentId == null ? GetNutrimentFormUrl(formMode) : $"{GetNutrimentFormUrl(formMode)}/{nutrimentId}";
        #endregion
        
        #region Ingredients
        public static string IngredientsPathUrl => "/ingredients";
        
        public static string GetIngredientFormUrl(FormMode formMode, string? ingredientId = null) => ingredientId == null ? $"{IngredientsPathUrl}/{formMode}" : $"{IngredientsPathUrl}/{formMode}/{ingredientId}";
        
        public static string GetIngredientDetailsUrl(string ingredientId) => $"{IngredientsPathUrl}/{ingredientId}/details";
        #endregion
        
        #region Recips
        public static string RecipsPathUrl => "/recips";
        
        public static string GetRecipFormUrl(FormMode formMode, string? RecipId = null) => RecipId == null ? $"{RecipsPathUrl}/{formMode}" : $"{RecipsPathUrl}/{formMode}/{RecipId}";
        
        public static string GetRecipDetailsUrl(string recipId) => $"{RecipsPathUrl}/{recipId}/details";
        #endregion
        
        #region SelectedRecipHistories
        public static string SelectedRecipHistoriesPathUrl => "/selectedRecipHistories";
        public static string GetSelectedRecipHistoryUrl(string Id) =>$"{SelectedRecipHistoriesPathUrl}/{Id}";
        #endregion

        #region RecipTypes
        public static string RecipTypesPathUrl => "/recipTypes";
        public static string GetRecipTypeFormUrl(FormMode formMode) => $"{RecipTypesPathUrl}/{formMode}";
        public static string GetRecipTypeFormUrl(FormMode formMode, string? RecipTypeId) => RecipTypeId == null ? GetRecipTypeFormUrl(formMode) : $"{GetRecipTypeFormUrl(formMode)}/{RecipTypeId}";
        #endregion
    }
}
