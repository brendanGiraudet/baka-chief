﻿using bakaChiefApplication.Enums;

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
        #endregion
        
        #region Recips
        public static string RecipsPathUrl => "/recips";
        public static string GetRecipFormUrl(FormMode formMode, string? RecipId = null) => RecipId == null ? $"{RecipsPathUrl}/{formMode}" : $"{RecipsPathUrl}/{formMode}/{RecipId}";
        #endregion
    }
}
