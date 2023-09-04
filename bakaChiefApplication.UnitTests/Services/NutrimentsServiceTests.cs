using bakaChiefApplication.Models;
using bakaChiefApplication.Services.NutrimentsService;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text.Json;

namespace bakaChiefApplication.UnitTests.Service
{
    public class NutrimentsServiceTests
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;

        public NutrimentsServiceTests()
        {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        }

        private NutrimentsService getNutrimentsService()
        {
            return new NutrimentsService(_httpClientFactoryMock.Object);
        }

        #region GetNutrimentsAsync
        [Fact]
        public async Task GetNutrimentsAsync_ShouldReturnListOfNutriments()
        {
            // Arrange
            var expectedNutriments = new List<Nutriment>
            {
                new Nutriment { Id = "1", Name = "Protein" },
                new Nutriment { Id = "2", Name = "Vitamin" }
            };

            // Mock HTTP Client
            var httpClient = CreateHttpClientMock(HttpStatusCode.OK, expectedNutriments);
            _httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(httpClient);
            var nutrimentsService = getNutrimentsService();

            // Act
            var result = await nutrimentsService.GetNutrimentsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedNutriments.Count, result.Count());
            Assert.Equal(expectedNutriments, result, new NutrimentComparer());
        }

        #endregion

        #region GetNutrimentByIdAsync
        [Fact]
        public async Task GetNutrimentByIdAsync_ShouldReturnNutriment()
        {
            // Arrange
            var expectedNutriment = new Nutriment { Id = "1", Name = "Protein" };

            // Mock HTTP Client
            var httpClient = CreateHttpClientMock(HttpStatusCode.OK, expectedNutriment);
            _httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(httpClient);
            var nutrimentsService = getNutrimentsService();

            // Act
            var result = await nutrimentsService.GetNutrimentByIdAsync("1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedNutriment, result, new NutrimentComparer());
        }
        #endregion

        #region CreateNutrimentAsync
        [Fact]
        public async Task CreateNutrimentAsync_ShouldCreateAndReturnNutriment()
        {
            // Arrange
            var nutrimentTypeToCreate = new Nutriment { Name = "Vitamin" };
            var expectedCreatedNutriment = new Nutriment { Id = "1", Name = "Vitamin" };

            // Mock HTTP Client
            var httpClient = CreateHttpClientMock(HttpStatusCode.Created, expectedCreatedNutriment);
            _httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(httpClient);
            var nutrimentsService = getNutrimentsService();

            // Act
            var result = await nutrimentsService.CreateNutrimentAsync(nutrimentTypeToCreate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCreatedNutriment, result, new NutrimentComparer());
        }
        #endregion

        #region UpdateNutrimentAsync
        [Fact]
        public async Task UpdateNutrimentAsync_ShouldUpdateNutriment()
        {
            // Arrange
            var nutrimentTypeToUpdate = new Nutriment { Id = "1", Name = "Updated Vitamin" };

            // Mock HTTP Client
            var httpClient = CreateHttpClientMock(HttpStatusCode.NoContent);
            _httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(httpClient);
            var nutrimentsService = getNutrimentsService();

            // Act & Assert: If no exception was thrown, the test is successful
            await nutrimentsService.UpdateNutrimentAsync(nutrimentTypeToUpdate);
        }
        #endregion

        #region DeleteNutrimentAsync
        [Fact]
        public async Task DeleteNutrimentAsync_ShouldDeleteNutriment()
        {
            // Arrange
            var nutrimentTypeId = "1";

            // Mock HTTP Client
            var httpClient = CreateHttpClientMock(HttpStatusCode.NoContent);
            _httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(httpClient);
            var nutrimentsService = getNutrimentsService();

            // Act & Assert: If no exception was thrown, the test is successful
            await nutrimentsService.DeleteNutrimentAsync(nutrimentTypeId);
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

        // Custom comparer for Nutriment objects
        private class NutrimentComparer : IEqualityComparer<Nutriment>
        {
            public bool Equals(Nutriment x, Nutriment y)
            {
                return x.Id == y.Id && x.Name == y.Name;
            }

            public int GetHashCode(Nutriment obj)
            {
                return HashCode.Combine(obj.Id, obj.Name);
            }
        }
    }
}
