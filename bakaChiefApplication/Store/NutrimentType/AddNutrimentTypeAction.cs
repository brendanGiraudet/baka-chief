﻿namespace bakaChiefApplication.Store.NutrimentType
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
