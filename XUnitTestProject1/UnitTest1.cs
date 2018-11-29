using System;
using Xunit;
using IdParser;


namespace IdParser
{
    
    public class UnitTest1
    {
        [Fact]
        public void ID_Contains_Only_Number()
        {
            var code = "3890220332";
            var actual = IdParser.CodeContainsOnlyNumber(code);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("33333320332", "male")]
        [InlineData("48902220332", "female")]
        [InlineData("13434343433", "male")]
        [InlineData("56348739393", "male")]
        [InlineData("66348739393", "female")]
        [InlineData("26348739393", "female")]
        public void Is_Man_Or_Woman(string code, string expected)
        {
            var actual = IdParser.IsMaleOrFemale(code);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ID_Length_Is_Valid()
        {
            var code = "22222222222";
            var actual = IdParser.IsLengthValid(code);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("128329839", true)]
        [InlineData("228329839", true)]
        [InlineData("328329839", true)]
        [InlineData("428329839", true)]
        [InlineData("528329839", true)]
        [InlineData("628329839", true)]
        [InlineData("728329839", true)]
        [InlineData("828329839", true)]
        [InlineData("028329839", false)]
        [InlineData("928329839", false)]
        public void Valid_Or_Not_Valid_Starting_Number(string code, bool expected)
        {

            var actual = IdParser.ValidStartingNum(code);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("33302220332", 1900)]
        [InlineData("48902220332", 1900)]
        [InlineData("13434343433", 1800)]
        [InlineData("56348739393", 2000)]
        [InlineData("66348739393", 2000)]
        public void Valid_Century(string code, int expected)
        {
            var actual = IdParser.CheckCentury(code);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Check_If_Valid_Sum()
        {
            var code = "34101010473";
            var actual = IdParser.CheckSum(code);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("3990228343", "28.02.1999") ]
        [InlineData("3750130222", "30.01.1975") ]
        [InlineData("3891111454", "11.11.1989") ]
        [InlineData("4410712987", "12.07.1941") ]
        [InlineData("3901212989", "12.12.1990") ]
        public void Check_If_Valid_Date(string code, string expected)
        {
            var actual = IdParser.ValidDate(code);

            Assert.Equal(expected, actual);
        }
    }
        
 }

