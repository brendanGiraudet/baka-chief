﻿using bakaChiefApplication.Services.NutrimentsService;
using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Nutriments;

public class NutrimentsEffect
{
    INutrimentsService _nutrimentsService;

    public NutrimentsEffect(INutrimentsService nutrimentsService)
    {
        _nutrimentsService = nutrimentsService;
    }

    [EffectMethod]
    public async Task HandleNutrimentSearchByNameAction(NutrimentSearchByNameAction action, IDispatcher dispatcher)
    {
        var nutriments = await _nutrimentsService.GetNutrimentsByNameAsync(action.NutrimentSearchTerm);

        dispatcher.Dispatch(new NutrimentSearchByNameResultAction(nutriments));
    }
    
    [EffectMethod]
    public async Task HandleCreateNutrimentAction(CreateNutrimentAction action, IDispatcher dispatcher)
    {
        var createNutrimentResult = await _nutrimentsService.CreateNutrimentAsync(action.NutrimentToCreate);

        if(!createNutrimentResult.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new CreateNutrimentSucceedAction(createNutrimentResult.Value!));
    }
}