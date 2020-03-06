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
            for (int i = 0; i < isbn.Length - 1 && i < 9; i++)
            {
                csDigit += ((int)Char.GetNumericValue(isbn[i]) * (i + 1));
            }
            csDigit = csDigit % 11;
            if (csDigit == 10)
                return "X";
            return "" + csDigit;
        }

        public bool calcCheckSum13(string isbn)
        {
            int result = CalculateCheckSum13(isbn);
            return result == (int)Char.GetNumericValue(isbn[isbn.Length - 1]);
        }

        public bool ValidInputLength(string isbn)
        {
            if (isbn.Length == 13 || isbn.Length == 10)
                return true;
            else
                return false;

        }
        


        private  int CalculateCheckSum13(string isbn)
        {
            int result = 0;
            int sum = 0;
            for (int i = 0; i < isbn.Length-1; i++)
            {
                if (IsEven(i))
                {
                    sum += (int)Char.GetNumericValue(isbn[i]);
                    
                }
                else
                {
                    sum += (int)Char.GetNumericValue(isbn[i]) * 3;
                }
            }
            result = sum % 10;
            result = 10 - result;
            return result;
        }

        private static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        public string stripDashAndSpace(string ISBN)
        {
            return ISBN.Replace("-","").Replace(" ","");
        }
        public bool validateCheckSum10(string ISBN)
    
        {
            if (ISBN == "")
                return false;
            return calcCheckSum10(ISBN) == Char.ToString(ISBN[ISBN.Length - 1]);

        }
    }
}