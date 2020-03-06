using BookInfoProvider;
using System;

namespace ISBN {
    public class ISBNFinder {
        private IBookInfoProvider isbnService = null;

        public ISBNFinder() : this(ISBNService.Instance) {
        }

        public ISBNFinder(IBookInfoProvider bookInfoProvider) {
            isbnService = bookInfoProvider;
        }
        
        public BookInfo lookup(string ISBN) {
            
            if (ISBN.Length != 10) {
                BookInfo badISBN = new BookInfo("ISBN must be 10 characters in length");
                return badISBN;
            }

            BookInfo bookInfo = isbnService.retrieve(ISBN);
            
            if (null == bookInfo) {
                return new BookInfo("Title not found");
            }
            
            return bookInfo;
        }

        public string calcCheckSum10(string isbn) {
            int csDigit = 0;
            for(int i=0; i < isbn.Length-1 && i < 9; i++)
            {
                csDigit += ((int)Char.GetNumericValue(isbn[i])*(i+1));
            }
            csDigit = csDigit % 11;
            if (csDigit == 10)
                return "X";
            return "" + csDigit;
        }
    }
}