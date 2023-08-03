using bakaChiefApplication.DatabaseModels;
using bakaChiefApplication.Repositories.NutrimentTypeRepository;
using bakaChiefApplication.ViewModels.NutrimentTypeViewModel;
using Moq;

namespace bakaChiefApplication.UnitTests.ViewModels
{
    public class NutrimentTypeViewModelTests
    {
        private NutrimentTypeViewModel _viewModel;
        private Mock<INutrimentTypeRepository> _mockRepository;

        public NutrimentTypeViewModelTests()
        {
            _mockRepository = new Mock<INutrimentTypeRepository>();
            _viewModel = new NutrimentTypeViewModel(_mockRepository.Object);
        }

        [Fact]
        public async void Initialize_ShouldLoadNutrimentTypes()
        {
            // Arrange
            var expectedNutrimentTypes = new List<NutrimentType>
            {
                new NutrimentType { Id = Guid.NewGuid().ToString(), Name = "Protein" },
                new NutrimentType { Id = Guid.NewGuid().ToString(), Name = "Carbohydrate" }
            };

            _mockRepository.Setup(repo => repo.GetAllNutrimentTypesAsync()).ReturnsAsync(expectedNutrimentTypes);

            // Act
            await _viewModel.Initialize();

            // Assert
            Assert.Equal(expectedNutrimentTypes.Count, _viewModel.NutrimentTypes.Count);
            foreach (var expectedNutrimentType in expectedNutrimentTypes)
            {
                Assert.Contains(_viewModel.NutrimentTypes, n => n.Id == expectedNutrimentType.Id && n.Name == expectedNutrimentType.Name);
            }
        }

        [Fact]
        public async void Initialize_ShouldSetEmptyList_WhenRepositoryReturnsEmptyList()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetAllNutrimentTypesAsync()).ReturnsAsync(new List<NutrimentType>());

            // Act
            await _viewModel.Initialize();

            // Assert
            Assert.Empty(_viewModel.NutrimentTypes);
        }
    }
}

