using DataAccess.Services.SearchService;

namespace SearchServer.Controller
{

    public static class SearchController 
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("getAllData", GetAllData);
            app.MapGet("getSearchResults/{keyword}", GetSearchResults);
        }

        private static IResult GetAllData(ISearchService data)
        {
            try
            {
                var results = data.GetAllResults();

                if (results == null) { return Results.NotFound(); }
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult GetSearchResults(string keyword, ISearchService data)
        {
            try
            {
                var results = data.GetSearchResults(keyword);

                if (results == null) { return Results.NotFound(); }
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
