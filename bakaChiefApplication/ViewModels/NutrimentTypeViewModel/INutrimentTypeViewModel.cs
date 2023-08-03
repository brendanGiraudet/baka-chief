using bakaChiefApplication.DatabaseModels;

namespace bakaChiefApplication.ViewModels.NutrimentTypeViewModel
{
    public interface INutrimentTypeViewModel
    {
        List<NutrimentType> NutrimentTypes { get; }
        Task Initialize();
    }
}
