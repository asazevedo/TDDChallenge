using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDChallenge.Services;
using Xunit;

namespace TDDChallenge.Tests
{
    
    public class ListFilterTests
    {
        public static IEnumerable<object[]> SetupData()
        {
            var testData = new List<object[]>();

            testData.Add(new object[] { new List<object> { "abc", "test", "loren" }, ListFilterService.FilterType.Strings, new List<object> { "abc", "test", "loren" } });
            testData.Add(new object[] { new List<object> { "abc", "", 1 }, ListFilterService.FilterType.Integers, new List<object> { 1 } });
            testData.Add(new object[] { new List<object> { "aaa", "bbb", "1", "1" }, ListFilterService.FilterType.Integers, new List<object> { 1 } });
            testData.Add(new object[] { new List<object> { "zxv", "yyz", "1", "2" }, ListFilterService.FilterType.Strings, new List<object> { "zxv", "yyz" } });
            testData.Add(new object[] { new List<object> { "abc", "abc", "abc", "abc" }, ListFilterService.FilterType.Strings, new List<object> { "abc" } });

            return testData;
        }

        [Fact]
        public void FilterList_WhenInputListIsNullOrEmpty_ShouldReturnException()
        {
            //Arrange
            var service = new ListFilterService(null);

            //Act
            Action action = () =>
            {
                service.FilterList(ListFilterService.FilterType.Integers);
            };

            //Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void FilterList_WhenInputListHasOnlyNumbers_ShouldReturnEmptyObjectList()
        {
            //Arrange
            var objectListWithNumbers = new List<object> { 1, 2, 3, 4 };
            var service = new ListFilterService(objectListWithNumbers);

            //Act
            var filter = service.FilterList(ListFilterService.FilterType.Strings);

            //Assert
            Assert.Empty(filter);
        }

        [Fact]
        public void FilterList_WhenInputListHasOnlyStrings_ShouldReturnEmptyObjectList()
        {
            //Arrange
            var objectListWithNumbers = new List<object> { "abc", "test", "loren" };
            var service = new ListFilterService(objectListWithNumbers);

            //Act
            var filter = service.FilterList(ListFilterService.FilterType.Integers);

            //Assert
            Assert.Empty(filter);
        }

        [Theory]
        [MemberData(nameof(ListFilterTests.SetupData))]
        public void FilterList_WhenInputListHasValues_ShouldReturnFilteredList(List<object> inputList, ListFilterService.FilterType filterType, List<object> outputFilter)
        {
            //Arrange
            var service = new ListFilterService(inputList);

            //Act
            var filter = service.FilterList(filterType);

            //Assert
            NUnit.Framework.CollectionAssert.AreEquivalent(outputFilter, filter);
        }
    }
}
