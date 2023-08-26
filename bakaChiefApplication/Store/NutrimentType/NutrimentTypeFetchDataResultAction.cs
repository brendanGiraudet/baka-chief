﻿using Fluxor;

namespace bakaChiefApplication.Store.NutrimentType
{
    public class NutrimentTypeFetchDataResultAction
    {
        public IEnumerable<Models.NutrimentType> NutrimentTypes { get; }

        public NutrimentTypeFetchDataResultAction(IEnumerable<Models.NutrimentType> nutrimentTypes)
        {
            NutrimentTypes = nutrimentTypes;
        }
    }
}