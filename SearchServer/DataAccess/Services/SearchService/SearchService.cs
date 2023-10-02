using DataAccess.Common.Interface;
using DataAccess.Common.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Services.SearchService
{
    public class SearchService : ISearchService
    {
        private const string Key = "FilePath";
        private readonly IGetData<List<User>> _getData;
        private readonly string jsonFilePath;
        private readonly IConfiguration _config;
        public SearchService(IGetData<List<User>> getData, IConfiguration config)
        {
            _getData = getData;
            _config = config;
            jsonFilePath = _config.GetSection(Key)?.Value;
        }

        public async Task<List<User>?> GetAllResults()
        {
            var data = await _getData.GetData(jsonFilePath);
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
