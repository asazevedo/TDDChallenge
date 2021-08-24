using System;
using TDDChallenge.Services;
using Xunit;

namespace TDDChallenge.Tests
{
    public class ArrayOutlierTests
    {
        [Fact]
        public void FindOutlier_WhenInputArrayIsNullOrEmpty_ShouldReturnException()
        {
            //Arrange
            var service = new ArrayOutlierService(null);

            //Act
            Action action = () =>
            {
                service.FindOutlier();
            };

            //Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void EvenCount_WhenInputArrayIsOdd_ShouldReturnZero()
        {
            //Arrange
            var oddInputArray = new int[] { 143, 153, 211, 423 };
            var service = new ArrayOutlierService(oddInputArray);

            //Act
            var evenCount = service.EvenCount;

            //Assert
            Assert.Equal(0, evenCount);
        }

        [Fact]
        public void OddCount_WhenInputArrayIsEven_ShouldReturnZero()
        {
            //Arrange
            var evenInputArray = new int[] { 74, 146, 220, 360 };
            var service = new ArrayOutlierService(evenInputArray);

            //Act
            var oddCount = service.OddCount;

            //Assert
            Assert.Equal(0, oddCount);
        }

        [Theory]
        [InlineData((object)(new int[] { 71,221,317,135,349,499,425,451, 452 }), 452)]
        [InlineData((object)(new int[] { 429, 93, 390, 400 }), 390)]

        [InlineData((object)(new int[] { 5, 438, 442, 308, 204, 168, 258 }), 5)]
        [InlineData((object)(new int[] { 64, 218, 359, 174, 410 }), 359)]
        public void FindOutlier_WhenInputArrayIsOddOrEven_ShouldReturnOutlier(int[] inputArray, int outlier)
        {
            //Arrange
            var service = new ArrayOutlierService(inputArray);

            //Act
            var findOutlier = service.FindOutlier();

            //Assert
            Assert.Equal(outlier, findOutlier);
        }

    }
}
