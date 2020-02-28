using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Book[] book = new Book[100];
            Reader[] readers = new Reader[100];
            BookStore bookStores= new BookStore();
            int bookIndex = 0;
            int readersIndex = 0;

            while (true)
            {
                Console.WriteLine("\n1.Add Book");
                Console.WriteLine("2.Check Book Availability");
                Console.WriteLine("3.Books Information");
                Console.WriteLine("4.Add New Reader");
                Console.WriteLine("5.Rent A Book");
                Console.WriteLine("6.Return Book");
                Console.WriteLine("7.Readers Information");
                Console.WriteLine("Press 0 To Exit\n");
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                {
                    break;
                }
                else if (input == 1)
                {
                    //Add new Book
                    Console.WriteLine("Enter Book Name: ");
                    String bookName = Console.ReadLine();
                    Console.WriteLine("Enter Serial No :");
                    int serialNo = int.Parse(Console.ReadLine());
                    book[bookIndex] = new Book(bookName, serialNo, true);
                    bookStores.AddBook(bookName, serialNo, true);
                    bookIndex++;
                }
                else if (input == 2)
                {
                    //Check Book Availability
                    Console.WriteLine("Enter Book Serail No :");
                    int serialNo = int.Parse(Console.ReadLine());
                    bool status = false; Console.WriteLine();
                    for (int i = 0; i < bookIndex - 1; i++)
                    {
                        status = book[i].IsAvailable(serialNo);
                        if (status == true) break;
                    }
                    if (status == true) Console.WriteLine("Book Is Available");
                    else Console.WriteLine("Book Is Not Available");
                }
                else if (input == 3)
                {
                    //All Book Information
                    Console.WriteLine(bookIndex.ToString());
                    for (int i = 0; i < bookIndex; i++)
                    {
                        book[i].DisplayBookInformation();
                    }
                }
                else if (input == 4)
                {
                    //Add New reader
                    Console.WriteLine("Enter Reader Name : ");
                    string name = Console.ReadLine();
                    readers[readersIndex] = new Reader(name);
                    bookStores.AddReader(name);
                    readersIndex++;
                }
                else if (input == 5)
                {
                    //Rent A book
                    Console.WriteLine("Enter Reader Name : ");
                    string name = Console.ReadLine();
                    bool checkReader = false;
                    bool checkBook = false;
                    int ReaderIndex = 0, BookIndex = 0;

                    for (int i = 0; i < readersIndex; i++)
                    {
                        //Gets Reader Object
                        if (readers[i].GetReaderName() == name)
                        {
                            ReaderIndex = i;
                            checkReader = true;
                            break;
                        }

                    }
                    if (checkReader == true)
                    {
                        Console.WriteLine("Enter Book Name : ");
                        string bname = Console.ReadLine();
                        for (int i = 0; i < bookIndex; i++)
                        {//Gets Book Object
                            if (book[i].GetBookName() == bname)
                            {
                                BookIndex = i;
                                checkBook = true;
                                break;
                            }
                        }
                    }
                    if (checkReader == false)
                    {
                        Console.WriteLine("Invalid Reader Name");
                    }
                    if (checkReader == true && checkBook == true)
                    {
                        bookStores.RentBook(book[BookIndex], readers[ReaderIndex]);
                        Console.WriteLine("Book Is Rented");
                    }
                    else Console.WriteLine("Invalid Book Name");
                }
                else if (input == 6)
                {
                    //Return A book
                    Console.WriteLine("Enter Reader Name : ");
                    string name = Console.ReadLine();
                    bool checkReader = false;
                    bool checkBook = false;
                    int ReaderIndex = 0, BookIndex = 0;

                    for (int i = 0; i < readersIndex; i++)
                    {
                        //Gets Reader Object
                        if (readers[i].GetReaderName() == name)
                        {
                            ReaderIndex = i;
                            checkReader = true;
                            break;
                        }

                    }
                    if (checkReader == true)
                    {
                        Console.WriteLine("Enter Book Name : ");
                        string bname = Console.ReadLine();
                        for (int i = 0; i < bookIndex; i++)
                        {//Gets Book Object
                            if (book[i].GetBookName() == bname)
                            {
                                BookIndex = i;
                                checkBook = true;
                                break;
                            }
                        }
                    }
                    else Console.WriteLine("Invalid Reader Name");
                    if (checkReader == true && checkBook == true)
                    {
                        //readers[ReaderIndex].ReturnBook(book[BookIndex]);
                        bookStores.ReturnBook(book[BookIndex], readers[ReaderIndex]);
                        Console.WriteLine("Book Returned");
                    }
                    else Console.WriteLine("Invalid Book Name");
                }
                else if (input == 7)
                {
                    //Readers Information 
                    Console.WriteLine("Enter Reader Name : ");
                    string name = Console.ReadLine();
                    bool checkReader = false;
                    int ReaderIndex = 0;

                    for (int i = 0; i < readersIndex; i++)
                    {
                        //Gets Reader Object
                        if (readers[i].GetReaderName() == name)
                        {
                            ReaderIndex = i;
                            checkReader = true;
                            break;
                        }
                    }
                    if (checkReader == true)
                    {
                        bookStores.DisplayBookStoreInformation();
                    }
                    else Console.WriteLine("Invalid Reader Name");

                }
                else if (input==8)
                {
                    //Remove Book
                }
                else if(input==9)
                {
                    //Remove User
                }
                else Console.WriteLine("Invalid Input");

            }
        }
    }
}
