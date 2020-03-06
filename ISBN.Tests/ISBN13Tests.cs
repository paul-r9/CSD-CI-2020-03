using System;
using BookInfoProvider;
using Xunit;

namespace ISBN
{
    public class ISBN13Tests
    {
        [Fact]
        public void goodCheckSum()
        {
            //Arrange
            string goodISBN = "9780131177055";

            //Act
            ISBNFinder sut = new ISBNFinder();
            //BookInfo actual = sut.lookup(goodISBN);

            //Assert
            Assert.True(sut.calcCheckSum13(goodISBN));
        }

    }
}
