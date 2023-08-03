using bakaChiefApplication.DatabaseModels;
using bakaChiefApplication.Repositories.NutrimentTypeRepository;

namespace bakaChiefApplication.ViewModels.NutrimentTypeViewModel
{
    public class NutrimentTypeViewModel : INutrimentTypeViewModel
    {
        public List<NutrimentType> NutrimentTypes { get; private set; }

        private readonly INutrimentTypeRepository _nutrimentTypeRepository;

        public NutrimentTypeViewModel(INutrimentTypeRepository nutrimentTypeRepository)
        {
            _nutrimentTypeRepository = nutrimentTypeRepository;
            NutrimentTypes = new List<NutrimentType>();
        }

        public async Task Initialize()
        {
            NutrimentTypes = await _nutrimentTypeRepository.GetAllNutrimentTypesAsync();
            //NutrimentTypes = new List<NutrimentType> {
            //    new NutrimentType()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Name = "Protein"
            //},
            //    new NutrimentType()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Name = "Vitamin C"
            //} };
        }
    }
}
