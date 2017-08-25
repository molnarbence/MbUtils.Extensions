

using Xunit;

namespace MbUtils.Extensions.Core.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void HasValue_StringIsEmpty()
        {
            // arrange
            var input = string.Empty;

            // act
            var result = input.HasValue();

            // assert
            Assert.False(result);
        }

        [Fact]
        public void HasValue_StringIsNull()
        {
            // arrange
            string input = null;

            // act
            var result = input.HasValue();

            // assert
            Assert.False(result);
        }

        [Fact]
        public void HasValue_StringIsNotEmpty()
        {
            // arrange
            var input = "b";

            // act
            var result = input.HasValue();

            // assert
            Assert.True(result);
        }

        [Fact]
        public void IsNullOrEmpty_StringIsNull()
        {
            // arrange
            string input = null;

            // act
            var result = input.IsNullOrEmpty();

            // assert
            Assert.True(result);
        }        

        [Fact]
        public void IsNullOrEmpty_StringIsEmpty()
        {
            // arrange
            var input = string.Empty;

            // act
            var result = input.IsNullOrEmpty();

            // assert
            Assert.True(result);
        }

        [Fact]
        public void IsNullOrEmpty_StringIsNotEmpty()
        {
            // arrange
            var input = "b";

            // act
            var result = input.IsNullOrEmpty();

            // assert
            Assert.False(result);
        }
    }
}