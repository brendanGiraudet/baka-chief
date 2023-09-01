﻿using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.NutrimentTypesService
{
    public interface INutrimentTypeService
    {
        Task<IEnumerable<NutrimentType>> GetAllNutrimentTypesAsync();
        Task<NutrimentType> GetNutrimentTypeByIdAsync(string id);
        Task<NutrimentType> CreateNutrimentTypeAsync(NutrimentType nutrimentType);
        Task UpdateNutrimentTypeAsync(NutrimentType nutrimentType);
        Task DeleteNutrimentTypeAsync(string id);
    }
}