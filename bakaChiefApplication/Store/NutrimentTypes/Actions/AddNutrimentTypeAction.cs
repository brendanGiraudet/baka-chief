﻿namespace bakaChiefApplication.Store.NutrimentTypes.Actions
{
    public class AddNutrimentTypeAction
    {
        public Models.NutrimentType NutrimentType { get; }

        public AddNutrimentTypeAction(Models.NutrimentType nutrimentType)
        {
            NutrimentType = nutrimentType;
        }
    }
}