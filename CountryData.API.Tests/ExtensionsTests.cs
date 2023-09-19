using CountryData.API.Extensions;
using CountryData.API.Models;
using Newtonsoft.Json;
namespace CountryData.API.Tests
{

    [TestClass]
    public class ExtensionsTests
    {
        private static IEnumerable<Country> _countries = Enumerable.Empty<Country>(); 

        [ClassInitialize]
        public static void ClassDataInit(TestContext context)
        {
            _countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(Data.Countries2JsonString);
        }

        [TestMethod]
        [DataRow("stan", "STAN", new[] { "Afghanistan", "Kyrgyzstan", "Kazakhstan" } )]
        [DataRow("bar", "Bar", new[] { "Barbados" } )]
        [DataRow("bados", "bADOs", new[] { "Barbados" } )]
        [DataRow("vatican", "VATICAN", new[] { "Vatican City" } )]
        [DataRow(null, null, new[] { "Afghanistan", "Kyrgyzstan", "Kazakhstan", "Vatican City", "Barbados" } )]
        [DataRow("zzz", "ZZZ", new string[0])]
        public void FilterByName_Should_Return_Same_Entries_Disregarding_Input_Case(
            string lowerCaseSearch, 
            string mixedCaseSearch,
            string[] expectedNames)
        {
            var upperCaseFilterResult = _countries.FilterByName(mixedCaseSearch).ToArray();
            var lowerCaseFilterResult = _countries.FilterByName(lowerCaseSearch).ToArray();

            CollectionAssert.AreEquivalent(upperCaseFilterResult, lowerCaseFilterResult);

            var resultNames = upperCaseFilterResult.Select(x => x.Name.Common).ToArray();
            CollectionAssert.AreEquivalent(expectedNames, resultNames);
        }

        [TestMethod]
        [DataRow(0, 0, new string[0])]
        [DataRow(null, 5, new[] { "Afghanistan", "Kyrgyzstan", "Kazakhstan", "Vatican City", "Barbados" } )]
        [DataRow(1, 2, new[] { "Vatican City", "Barbados" } )]
        [DataRow(10, 3, new[] { "Kyrgyzstan", "Vatican City", "Barbados" } )]
        [DataRow(20, 4, new[] { "Kazakhstan", "Kyrgyzstan", "Vatican City", "Barbados" } )]
        [DataRow(50, 5, new[] { "Afghanistan", "Kyrgyzstan", "Kazakhstan", "Vatican City", "Barbados" })]
        [DataRow(100, 5, new[] { "Afghanistan", "Kyrgyzstan", "Kazakhstan", "Vatican City", "Barbados" })]
        [DataRow(1000, 5, new[] { "Afghanistan", "Kyrgyzstan", "Kazakhstan", "Vatican City", "Barbados" })]
        [DataRow(2000, 5, new[] { "Afghanistan", "Kyrgyzstan", "Kazakhstan", "Vatican City", "Barbados" })]
        public void FilterByPopulation_Should_Return_Entries_With_Smaller_Population_Than_Input_Value_In_Millions(
            int? inputValue,
            int expectedCount,
            string[] expectedNames)
        {
            var filterResult = _countries.FilterByPopulationSize(inputValue).ToArray();

            Assert.AreEqual(expectedCount, filterResult.Length);

            var resultNames = filterResult.Select(x => x.Name.Common).ToArray();
            CollectionAssert.AreEquivalent(expectedNames, resultNames);
        }

        [TestMethod]
        [DataRow(2500)]
        [DataRow(3000)]
        [DataRow(10000)]
        public void FilterByPopulation_Should_Throw_ArgumentException_When_Input_Is_Too_Large(int input)
        {
            Assert.ThrowsException<OverflowException>(() => _countries.FilterByPopulationSize(input).ToArray());
        }

        [TestMethod]
        [DataRow(new[] { "Afghanistan", "Barbados", "Kazakhstan", "Kyrgyzstan", "Vatican City" }, "ascending")]
        [DataRow(new[] { "Vatican City", "Kyrgyzstan", "Kazakhstan", "Barbados", "Afghanistan" }, "descending")]
        public void SortByName_Should_Order_Entries_By_Name_According_To_The_Direction_Input(string[] expectedNamesInOrder, string direction)
        {
            var sortedResult = _countries.SortByName(direction).ToArray();

            for (int i = 0; i < expectedNamesInOrder.Length; i++)
            {
                Assert.AreEqual(expectedNamesInOrder[i], sortedResult[i].Name.Common);
            }
        }

        [TestMethod]
        public void SortByName_Should_Return_Entries_Unchanged_When_Direction_Is_Null()
        {
            var sortedResult = _countries.SortByName(null).ToArray();
            var expectedResult = _countries.ToArray();

            for (int i = 0; i < sortedResult.Length; i++)
            {
                Assert.AreEqual(expectedResult[i].Name.Common, sortedResult[i].Name.Common);
            }
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 1)]
        [DataRow(5, 5)]
        [DataRow(10, 5)]
        [DataRow(null, 5)]
        public void Limit_Should_Return_Expected_Number_Of_Entries(int? limit, int expectedCount)
        {
            var limitedEntries = _countries.Limit(limit).ToArray();
            Assert.AreEqual(expectedCount, limitedEntries.Length);
        }
    }
}
