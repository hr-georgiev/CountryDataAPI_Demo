# CountryDataAPI_Demo
API Wrapper around REST Countries API

This WebApi projects acts as a wrapper of https://restcountries.com/v3.1/all endpoint. The "GET" endpoint exposed in this API accepts 4 optional query parameters:
* name (string) - applies filtering by the common name of a country. Can be a substring and case does not matter.
* population (integer) - applies filtering by a country's population value and returns all entries with population less than the parameter value in millions
* sortdirection (string) - if present, should be "ascending" or "descending". Applies sorting based on the common name of a country.
* limit (integer) - limits the number of returned entries if after any filtering applied there are still more entries in the result.

How to run locally:<br>
In the command line, navigate to the "path-on-your-drive/CountryDataAPI_Demo/CountryData.Api" where the CountryData.Api.csproj file is stored and execute the "dotnet run" command.

How to run the tests:<br>
In the command line, navigate to the "path-on-your-drive/CountryDataAPI_Demo/CountryData.API.Tests" where the CountryData.Api.Tests.csproj file is stored and execute the "dotnet test" command. You can raise the verbosity level by passing the "-v" flag and "n" after it ("dotnet test -v n") for normal verbosity.

URL Usage examplse:<br>
* https://localhost:7223/countries - will return all the countries unfiltered in the result property of the JSON response
* https://localhost:7223/countries?population=10 - will return all the countries with population less than 10 millions in the result array of the JSON response
* https://localhost:7223/countries?name=kingdom - will return all the countries with "kingdom" in their name, case insensitive
* https://localhost:7223/countries?limit=50 - will return the first 50 countries from the result array of the JSON response. If there are less country objects in the array it will return them all
* https://localhost:7223/countries?sortdirection=ascending - will return the country objects sorted by their common name
* https://localhost:7223/countries?population=100&name=KINGDOM - will return all the countries with population less than 100 millions and the string "kingodom" in their common name
* https://localhost:7223/countries?name=stan&sortdirection=descending - will return all the countries with the string "stan" in their name sorted by their common name in descending order
* https://localhost:7223/countries?name=stan&limit=5 - will return the first five countries with the string "stan" in their name. If there are less than 5 countries they will all be returned
* https://localhost:7223/countries?name=stan&limit=5&sort=ascending - will return the first five countries with the string "stan" in their name after the result has been sorted in ascending order
*  https://localhost:7223/countries?name=stan&limit=5&sort=ascending&population=50 - will return the first five countries with the string "stan" in their name and less the 50 millions population, after the result has been sorted in ascending order
