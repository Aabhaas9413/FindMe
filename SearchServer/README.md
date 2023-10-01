# .NET 6 Search Server Solution

## Description

This .NET 6 solution provides a full-text search functionality based on a given set of acceptance criteria. It utilizes a .NET API with LINQ for searching and filtering records.

## Acceptance Criteria

- Given a search term of “James,” when I enter the search term into the search input and click the ‘Search’ button, then the search results should include the records for “James Kubu” and “James Pfieffer.”

- Given a search term of “jam,” when I enter the search term into the search input and click the ‘Search’ button, then the search results should include the records for “James Kubu,” “James Pfieffer,” and “Chalmers Longfut.”

- Given a search term of “Katey Soltan,” when I enter the search term into the search input and click the ‘Search’ button, then the search results should include only the record for “Katey Soltan.”

- Given a search term of “Jasmine Duncan,” when I enter the search term into the search input and click the ‘Search’ button, then no results should be returned.

- Given an empty search term, when I click the ‘Search’ button, I should be notified that I did not provide a search input, and no results should be returned.

## Prerequisites

Before you begin, ensure you have the following:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Code](https://code.visualstudio.com/download) (or your preferred code editor)

## Getting Started

Follow these steps to set up and run the .NET 6 solution:

1) Clone the repository https://github.com/Aabhaas9413/FindMe.
2) In folder Search server open https://github.com/Aabhaas9413/FindMe/blob/master/SearchServer/SearchServer.sln. You can use visual studio 2022 to open and run the solution.
3) The startup project should be SearchAPI.csproj.


## Testing

To run unit tests for the solution, execute the following command:

```bash
dotnet test
```
or else you can run the tests on visual studio

This will run all unit tests using the built-in test runner.
