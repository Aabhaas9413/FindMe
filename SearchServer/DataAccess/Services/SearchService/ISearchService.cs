using DataAccess.Common.Models;

namespace DataAccess.Services.SearchService
{
    public interface ISearchService
    {
        Task<List<User>?> GetAllResults();
        Task<List<User>?> GetSearchResults(string keyword);
    }
}