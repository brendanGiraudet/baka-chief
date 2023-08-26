using bakaChiefApplication.Models;
using bakaChiefApplication.Services.NutrimentTypeService;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace bakaChiefApplication.UnitTests.Service
{
    public class NutrimenTypeServiceTests
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;

        public NutrimenTypeServiceTests()
        {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        }

        #region GetAllNutrimentTypesAsync
        [Fact]
        public async Task GetAllNutrimentTypesAsync_ShouldReturnListOfNutrimentTypes()
        {
            // Arrange
            var expectedNutrimentTypes = new List<NutrimentType>
            {
                new NutrimentType { Id = "1", Name = "Protein" },
                new NutrimentType { Id = "2", Name = "Vitamin" }
            };

            // Mock HTTP Client
            var httpClient = CreateHttpClientMock(HttpStatusCode.OK, expectedNutrimentTypes);
            _httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(httpClient);
            var nutrimentTypeService = getNutrimenntTypeService();

            // Act
            var result = await nutrimentTypeService.GetAllNutrimentTypesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedNutrimentTypes.Count, result.Count());
            Assert.Equal(expectedNutrimentTypes, result, new NutrimentTypeComparer());
        }

        #endregion

        private NutrimentTypeService getNutrimenntTypeService()
        {
            return new NutrimentTypeService(_httpClientFactoryMock.Object);
        }

        #region GetNutrimentTypeByIdAsync
        [Fact]
        public async Task GetNutrimentTypeByIdAsync_ShouldReturnNutrimentType()
        {
            // Arrange
            var expectedNutrimentType = new NutrimentType { Id = "1", Name = "Protein" };

            // Mock HTTP Client
            var httpClient = CreateHttpClientMock(HttpStatusCode.OK, expectedNutrimentType);
            _httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(httpClient);
            var nutrimentTypeService = getNutrimenntTypeService();

            // Act
            var result = await nutrimentTypeService.GetNutrimentTypeByIdAsync("1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedNutrimentType, result, new NutrimentTypeComparer());
        }
        #endregion

        #region CreateNutrimentTypeAsync
        [Fact]
        public async Task CreateNutrimentTypeAsync_ShouldCreateAndReturnNutrimentType()
        {
            // Arrange
            var nutrimentTypeToCreate = new NutrimentType { Name = "Vitamin" };
            var expectedCreatedNutrimentType = new NutrimentType { Id = "1", Name = "Vitamin" };

            // Mock HTTP Client
            var httpClient = CreateHttpClientMock(HttpStatusCode.Created, expectedCreatedNutrimentType);
            _httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(httpClient);
            var nutrimentTypeService = getNutrimenntTypeService();

            // Act
            var result = await nutrimentTypeService.CreateNutrimentTypeAsync(nutrimentTypeToCreate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCreatedNutrimentType, result, new NutrimentTypeComparer());
        }
        #endregion

        #region UpdateNutrimentTypeAsync
        [Fact]
        public async Task UpdateNutrimentTypeAsync_ShouldUpdateNutrimentType()
        {
            // Arrange
            var nutrimentTypeToUpdate = new NutrimentType { Id = "1", Name = "Updated Vitamin" };

            // Mock HTTP Client
            var httpClient = CreateHttpClientMock(HttpStatusCode.NoContent);
            _httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(httpClient);
            var nutrimentTypeService = getNutrimenntTypeService();

            // Act & Assert: If no exception was thrown, the test is successful
            await nutrimentTypeService.UpdateNutrimentTypeAsync(nutrimentTypeToUpdate);
        }
        #endregion

        #region DeleteNutrimentTypeAsync
        [Fact]
        public async Task DeleteNutrimentTypeAsync_ShouldDeleteNutrimentType()
        {
            // Arrange
            var nutrimentTypeId = "1";

            // Mock HTTP Client
            var httpClient = CreateHttpClientMock(HttpStatusCode.NoContent);
            _httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(httpClient);
            var nutrimentTypeService = getNutrimenntTypeService();

            // Act & Assert: If no exception was thrown, the test is successful
            await nutrimentTypeService.DeleteNutrimentTypeAsync(nutrimentTypeId);
        }
        #endregion

        // Helper method to create a mock of HttpClient with a specific response
        private HttpClient CreateHttpClientMock(HttpStatusCode statusCode, object responseObject = null)
        {
            var response = new HttpResponseMessage(statusCode);

            if (responseObject != null)
            {
                response.Content = new StringContent(JsonSerializer.Serialize(responseObject));
            }

            var httpMessageHandler = new Mock<HttpMessageHandler>();
            httpMessageHandler.Protected()
                    .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                        ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>()
                    )
                    .ReturnsAsync(response);


            var httpClient = new HttpClient(httpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://localhost")
            };

            return httpClient;
        }

        // Custom comparer for NutrimentType objects
        private class NutrimentTypeComparer : IEqualityComparer<NutrimentType>
        {
            public bool Equals(NutrimentType x, NutrimentType y)
            {
                return x.Id == y.Id && x.Name == y.Name;
            }

            public int GetHashCode(NutrimentType obj)
            {
                return HashCode.Combine(obj.Id, obj.Name);
            }
        }
    }
}
