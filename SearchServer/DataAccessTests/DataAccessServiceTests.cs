using DataAccess.Common.Interface;
using DataAccess.Common.Models;
using DataAccess.Services.SearchDataAccess;

namespace DataAccessTests
{
    public class DataAccessServiceTests
    {
        private readonly IGetData<List<User>> _getData;
        public DataAccessServiceTests() {
            _getData = new DataAccessFromJSON<List<User>>();
        }

        [Fact]
        public async void GetUserFromJSONSuccess()
        {
            //Arrange
            var path = "C:\\Users\\aabha\\OneDrive\\Desktop\\FindMe\\SearchServer\\DataAccessTests\\Assets\\mockData.json";
             
            //Act
            var result = await _getData.GetData(path);

            //Assert
            Assert.Equal("Antony", result?.FirstOrDefault()?.FirstName);
            Assert.Equal<int>(20, result.Count());
        }

        [Fact]
        public async void GetUserFromJSONThrowsFileNotFoundException()
        {
            //Arrange
            var path = "C:\\Users\\aabha\\OneDrive\\Desktop\\FindMe\\SearchServer\\DataAccessTests\\Assets\\mockDataNotFound.json";
            var expectedExp = $"Could not find file '{path}'.";
            // Act and Assert
            var exception = await Assert.ThrowsAsync<FileNotFoundException>(async () =>
            {
                // Call the method that is expected to throw FileNotFoundException.
                await _getData.GetData(path);
            });
            Assert.Equal(exception.Message, expectedExp);
        }

       
    }
}