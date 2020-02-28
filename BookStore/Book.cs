using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Book
    {
        string bookName;
        int bookSerial;
        static List<int> bookSerials;
        bool status;

        public Book(string bookName, int bookSerial, bool status) 
        {
            //if (bookSerials.Contains(bookSerial))
            //{
            //    Console.WriteLine("Book Serial already exist! Please type unique Serial...");
            //}
            //else
            //{
                this.bookName = bookName;
                this.bookSerial = bookSerial;
                this.status = status;
                //bookSerials.Add(bookSerial);
            //}
        }

        public bool IsAvailable(int serialNo) 
        {
            bool Avaiable=false;
            if (serialNo==bookSerial)
            {
                Avaiable = true;
            }
            return Avaiable;
        }

        public void BookRent() 
        {
            status = false;
        }

        public void BookReturn()
        {
            status = true;
        }

        public void DisplayBookInformation() 
        {
            Console.WriteLine();
            Console.WriteLine("Book Information:");
            Console.WriteLine();
            Console.WriteLine("Book Name: " + bookName);
            Console.WriteLine("Book Serial: " + bookSerial);
            Console.WriteLine("Availability: " + status.ToString());
            Console.WriteLine();
        }
        public int getSerailNo()
        {
            return bookSerial;
        }
        public string GetBookName() 
        {
            return bookName;
        }
    }
}
