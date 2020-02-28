using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Reader
    {
        string readerName;
        List<Book> rentedBooks;
        static List<string> readerNames = new List<string>();

        public Reader(string readerName) 
        {
            if (readerNames.Contains(readerName))
            {
                Console.WriteLine("Reader Name already exist...");
            }
            else
            {
                this.readerName = readerName;
                rentedBooks = new List<Book>();
                readerNames.Add(readerName);
            }
        }
        
        public void RentBook(Book book)
        {
            if (rentedBooks.Count < 2 && book.IsAvailable(book.getSerailNo()))
            {
                book.BookRent();
                rentedBooks.Add(book);
            }
            else if (rentedBooks.Count >= 2)
            {
                Console.WriteLine("Rented Books limit exceed!");
            }
            else 
            {
                Console.WriteLine("Book not available!");
            }
        }

        public void ReturnBook(Book book)
        {
            if (rentedBooks.Contains(book))
            {
                book.BookReturn();
                rentedBooks.Remove(book);
            }
            else 
            {
                Console.WriteLine("Invalid Book cannot be return!");
            }
        }

        public void DisplayReaderInformation()
        {
            Console.WriteLine();
            Console.WriteLine("Reader Information:");
            Console.WriteLine();
            Console.WriteLine("Reader Name: " + readerName);
            Console.WriteLine("Rented Books:");
            foreach (Book book in rentedBooks)
            {
                Console.WriteLine(book.GetBookName());
            }
            Console.WriteLine();
        }

        public int GetRentedBooksCount() 
        {
            return rentedBooks.Count;
        }

        public string GetReaderName() 
        {
            return readerName;
        }
    }
}
