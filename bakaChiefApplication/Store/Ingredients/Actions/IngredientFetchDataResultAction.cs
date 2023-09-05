﻿using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Ingredients.Actions
{
    public class IngredientFetchDataResultAction
    {
        public Models.Ingredient Ingredient { get; }

        public IngredientFetchDataResultAction(Ingredient ingredient)
        {
            Ingredient = ingredient;
        }
    }
}
