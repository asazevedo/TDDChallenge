using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDChallenge.Services;
using Xunit;

namespace TDDChallenge.Tests
{
    public class FormatWordsTests
    {
        [Fact]
        public void CommaSeparatedFormat_WhenInputArrayIsNull_ShouldReturnEmptyString()
        {
            //Arrange
            var service = new FormatWordsService(null);

            //Act
            var wordFormated = service.CommaSeparatedFormat();

            //Assert
            Assert.Equal("", wordFormated);
        }

        [Theory]
        [InlineData((object)(new string[] { "" }), "")]
        [InlineData((object)(new string[] { "ninja", "samurai", "ronin" }), "ninja, samurai and ronin")]
        [InlineData((object)(new string[] { "ninja", "", "ronin" }), "ninja and ronin")]
        [InlineData((object)(new string[] { "ninja" }), "ninja")]
        [InlineData((object)(new string[] { "samurai","","" }), "samurai")]
        [InlineData((object)(new string[] { "samurai", "", "", "robot" }), "samurai and robot")]
        public void CommaSeparatedFormat_WhenInputArrayHasValues_ShouldReturnCorrectString(string[] inputWordsList, string expectedWord)
        {
            //Arrange
            var service = new FormatWordsService(inputWordsList);

            //Act
            var wordFormated = service.CommaSeparatedFormat();

            //Assert
            Assert.Equal(expectedWord, wordFormated);
        }
    }
}
