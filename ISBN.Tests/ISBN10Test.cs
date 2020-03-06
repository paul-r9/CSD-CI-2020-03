using System;
using BookInfoProvider;
using Xunit;

namespace ISBN {
    public class ISBN10Test {
        [Fact]
        public void ISBN_ShorterThan10Characters_ReturnsInvalidBookInfo() {
            //Arrange
            string shortISBN = "12345";

            //Act
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(shortISBN);
            
            //Assert
            Assert.Equal("ISBN must be 10 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN_LongerThan10Characters_ReturnsInvalidBookInfo() {
            string longISBN = "123456789ABCEDF";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(longISBN);
            
            Assert.Equal("ISBN must be 10 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN_BookAvailableFromFinder() {
            String unknownISBN = "0553562614";
            
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(unknownISBN);
            
            Assert.Equal("Title not found", actual.Title);
        }

        [Fact]
        public void ISBN_BookFound() {
            string ISBN = "0321146530";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(ISBN);

            BookInfo expected = new BookInfo("Test Driven Development by Example", "Kent Beck", "0321146530", "9780321146533");
            Assert.Equal(expected.ToString(), actual.ToString());
        }

        [Fact]
        public void ISBN_CheckSumISBN10()
        {
            string ISBN = "0201485672";

            ISBNFinder sut = new ISBNFinder();
            string actual = sut.calcCheckSum10(ISBN);


            Assert.Equal("2", actual.ToString());
        }

        [Fact]
        public void ISBN_CheckSumISBN10WithX()
        {
            string ISBN = "043942089X";

            ISBNFinder sut = new ISBNFinder();
            string actual = sut.calcCheckSum10(ISBN);


            Assert.Equal("X", actual.ToString());
        }

    }

}