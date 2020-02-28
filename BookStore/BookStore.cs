using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class BookStore
    {
        List<Book> books;
        List<Reader> readers;

        public BookStore()
        {
            books = new List<Book>();
            readers = new List<Reader>();
        }

        public void AddReader(string readerName)
        {
            readers.Add(new Reader(readerName));
        }

        public void AddReader(Reader reader)
        {
            readers.Add(reader);
        }


        public void RemoveReader(Reader reader)
        {
            if (reader.GetRentedBooksCount() > 0)
            {
                Console.WriteLine("All books must be return to Book Store first!");
            }
            else
            {
                readers.Remove(reader);
            }
        }

        public void AddBook(string bookName, int bookSerial, bool status)
        {
            books.Add(new Book(bookName, bookSerial, status));
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book, int serialNo)
        {
            if (book.IsAvailable(serialNo) == true)
            {
                books.Remove(book);
            }
            else
            {
                Console.WriteLine("Book is not available!");
            }
        }

        public void RentBook(Book book, Reader reader)
        {
            if (books.Contains(book) && readers.Contains(reader))
            {
                reader.RentBook(book);
            }
            else
            {
                Console.WriteLine("Invalid reader or book!");
            }
        }

        public void ReturnBook(Book book, Reader reader)
        {
            if (books.Contains(book) && readers.Contains(reader))
            {
                reader.ReturnBook(book);
            }
            else
            {
                Console.WriteLine("Invalid reader or book!");
            }
        }
        public void DisplayReaders()
        {
            Console.WriteLine("Reader Names:");
            foreach (Reader reader in readers)
            {
                Console.WriteLine(reader.GetReaderName() +"\n");
            }
        }

        public void DisplayBookStoreInformation()
        {
            Console.WriteLine();
            Console.WriteLine("Book Store Information:");
            Console.WriteLine();
            Console.WriteLine("Reader Names:");
            foreach (Reader reader in readers)
            {
                Console.WriteLine(reader.GetReaderName());
            }
            Console.WriteLine();
            Console.WriteLine("Rented Books:");
            foreach (Book book in books)
            {
                Console.WriteLine(book.GetBookName());
            }
            Console.WriteLine();
        }
    }
}
