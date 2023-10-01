using DataAccess.Common.Interface;
using DataAccess.Common.Models;
using DataAccess.Services.SearchService;
using Moq;

namespace DataAccessTests
{
    public class SearchDataServiceTests
    {
        private readonly Mock<IGetData<List<User>>> mockDataService;
        private readonly ISearchService searchService;
        public SearchDataServiceTests()
        {
            mockDataService = new Mock<IGetData<List<User>>>();
            searchService = new SearchService(mockDataService.Object);
        }

        [Fact]
        public async void GetAllResultsSuccess()
        {
            //Act      
            List<User> expecterdUserList = ArrangeUserList();

            //Arrange
            var actualUsersSearched = await searchService.GetAllResults();

            //Assert
            Assert.Equal(actualUsersSearched, expecterdUserList);
        }

        [Theory]
        [InlineData("User")]
        [InlineData("Test")]
        [InlineData("Test User")]
        [InlineData("Teus")]
        public async void GetSearchResultByKeywordSuccess(string keyword)
        {
            //Arrange     
            List<User> expecterdUserList = ArrangeUserList();

            //Act
            var actualUsersSearched = await searchService.GetSearchResults(keyword);

            //Assert
            Assert.Equal(actualUsersSearched, expecterdUserList);
        }

        [Fact]
        public async void GetSearchResultByKeywordReturnsEmptySuccess()
        {
            //Arrange
            List<User> expecterdUserList = ArrangeUserList();

            //Act
            var actualUsersSearched = await searchService.GetSearchResults("NoUser");

            //Assert
            Assert.NotEqual(actualUsersSearched, expecterdUserList);
            Assert.True(actualUsersSearched.Count == 0);
        }

        [Fact]
        public async void GetSearchResultByEmptyKeywordThrowsException()
        {
            //Arrange
            List<User> expecterdUserList = ArrangeUserList();
            var expectedMessage = "Search term cannot be empty.";

            //Act
            var exception = await Assert.ThrowsAsync<EmptySearchTermException>(async() => {
                await searchService.GetSearchResults("");
            });
            Console.WriteLine(exception);
            Assert.Equal(exception.Message, expectedMessage);
        }

        private List<User> ArrangeUserList()
        {
            List<User> expecterdUserList = new List<User>()
            {
                new User() { 
                    Id = 1,
                    FirstName= "Test",
                    LastName= "User",
                    Email= "Teus@gamil.com",
                    Gender = "male"
                }
            }; 
            mockDataService.Setup(s => s.GetData(It.IsAny<string>())).ReturnsAsync(expecterdUserList);
            return expecterdUserList;
        }
    }
}