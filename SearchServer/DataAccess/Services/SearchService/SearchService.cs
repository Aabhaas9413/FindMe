using DataAccess.Common.Interface;
using DataAccess.Common.Models;

namespace DataAccess.Services.SearchService
{
    public class SearchService : ISearchService
    {
        private readonly IGetData<List<User>> _getData;
        private const string jsonFilePath = "C:\\Users\\aabha\\OneDrive\\Desktop\\FindMe\\SearchServer\\DataAccess\\Common\\Assets\\data.json";
        public SearchService(IGetData<List<User>> getData)
        {

            _getData = getData;
        }

        public Task<List<User>?> GetAllResults()
        {
            var data = _getData.GetData(jsonFilePath);
            return data;
        }
        public async Task<List<User>?> GetSearchResults(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new EmptySearchTermException();
            }
            var users = await _getData.GetData(jsonFilePath);
            var searchResults = users?
            .Where(person =>
                person.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                person.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                person.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                (person.FirstName + " " + person.LastName).Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
            return searchResults;
        }

    }
}
