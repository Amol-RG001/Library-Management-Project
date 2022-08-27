using System;
using System.Collections.Generic;
using System.Threading;


namespace CapstoneProject2
{
    
    internal class Program
    {
        static bool isTrue = true; //flag
        static List<Books> bookList = new List<Books>();
        static List<BorrowDetails> borrowList = new List<BorrowDetails>();

        static void Main(string[] args)
        {
         
           // BorrowDetails obj1 = new BorrowDetails();
           // Books obj2 = new Books();


            Console.WriteLine("*****************************************");
            Console.WriteLine("Enter your name:");
            Console.WriteLine("*****************************************");
            string myName = Console.ReadLine();

            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("Welcome {0}!",myName);
            Console.WriteLine("=========================================");
            Console.WriteLine("Please Enter your password:");
            Console.WriteLine("=========================================");
            string myPassword = Console.ReadLine();
            

            if (myPassword == "Amol120#")
            {
                Thread.Sleep(700);
                Console.Clear();

                while (isTrue)
                {
                    
                    Console.WriteLine("*****************************************");
                    Console.WriteLine("----------------MAIN-MENU----------------");
                    Console.WriteLine("*****************************************");
                    Console.WriteLine("\t1.Librarian");
                    Console.WriteLine("\t2.Borrower");
                    Console.WriteLine("\t3.Exit");
                    Console.WriteLine("*****************************************");

                    Console.WriteLine("Choose option from Menu:");
                    int myOption;
                    //for user who enter letter
                    try
                    {
                        myOption = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Letters not allow:" + e.Message);
                        myOption = int.Parse(Console.ReadLine());
                        Main(args);
                    }

                    switch (myOption)
                    {
                        case 3:
                            Console.WriteLine("Thank you! Have a Great Day..");
                            isTrue= false;
                            break;

                        case 2:
                         
                            fBorrower();
                            break;

                        case 1:

                            fLibrarian();
                            break;


                        default:
                            Console.WriteLine("Please enter valid option!");
                            break;

                    }

                }
            }//endOfIf
            else
            {
                Console.WriteLine("Wrong Password! Try again..");
                Program.Main( args); // calling Main method (recursion:D)

            }

           
        }//endOfMain

        /***********************Librarian functionality start***************************/
         public static void fLibrarian()
        {
            //Thread.Sleep(500);
            //Console.Clear();
            Console.WriteLine("*****************************************");
            Console.WriteLine("-------------LIBRARIAN-MENU--------------");
            Console.WriteLine("*****************************************");
            Console.WriteLine("\t1.Add The Book");
            Console.WriteLine("\t2.Delete The Book");
            Console.WriteLine("\t3.Search The Book");
            Console.WriteLine("\t4.Display Book Data");
            Console.WriteLine("\t5.Return to Main Menu");
            Console.WriteLine("*****************************************");

            Console.WriteLine("Choose option from Menu:");
            int myOption;

            //for user who enter letter
            try
            {
                myOption = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Letters not allow:" + e.Message);
                myOption = int.Parse(Console.ReadLine());
                fLibrarian();

            }

            switch (myOption)
            {
                case 5:
                    Console.WriteLine("Thank you! Have a Great Day..");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;



                case 4:
                    //Dispaly All book ID as a Data
                    displayBookData();
                    fLibrarian();
                    break;

                case 3:
                    //search the book
                    searchBook();
                    fLibrarian();
                    break;

                case 2:
                    //Delete The Book
                    deleteBook();
                    fLibrarian();
                    break;

                case 1:
                    //Add The Book
                    addBook();
                    fLibrarian();
                    break;


                default:
                    Console.WriteLine("Please enter valid option!");
                    break;

            }
        }    
         static void displayBookData()
        {
            Books books = new Books();
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Book ID\t" +
                   "\tBook Name\t" +
                   "Book Price\t" +
                   "Book Available\t" +
                   "Total Book Added");
            foreach (Books show in bookList)
            {
                Console.WriteLine("{0} {1,15} {2,20} {3,20} {4,20}", show.bookID, show.bookName, show.bookPrice, show.bookCount, show.numberOfBookX);
            }
            Console.WriteLine("------------------------------------------------------------------------------");
        }  
         static void addBook()
        {
            Books books = new Books();
            Console.WriteLine("Book ID:{0}", books.bookID = bookList.Count + 1); //update bookList by 1 
            Console.Write("Book Name:");
            books.bookName = Console.ReadLine();
            Console.Write("Book Price:");
            try
            {
                books.bookPrice = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:- " + e.Message);
                addBook();
            }

            Console.Write("Number of Books want to add:");
            
            try
            {
                //for original storage //bookCount may changed
                books.numberOfBookX = books.bookCount = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:- " + e.Message);
                addBook();
            }
            bookList.Add(books);

        }    
         static void searchBook() 
        {

            //Console.Clear();
            Books books = new Books();
            Console.Write("Enter BookID:");
            int findBook = int.Parse(Console.ReadLine());

            if (bookList.Exists(numberOfBookX => numberOfBookX.bookID == findBook))
            {
                foreach (Books id in bookList)
                {
                    if (id.bookID == findBook)
                    {
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Book ID:{0}\n" +
                            "Book Name: {1}\n" +
                            "Book Price: {2}\n" +
                            "Book Available: {3}", id.bookID, id.bookName, id.bookPrice, id.bookCount);
                        Console.WriteLine("-----------------------------");
                    }
                }
            }
            else
            {
                Console.WriteLine("Book ID {0} not found in Database", findBook);
            }

        }
         static void deleteBook() 
        {

            // Console.Clear();
            Books books = new Books();
            Console.WriteLine("Enter Book ID to be Deleted:");
            int deleteBook = int.Parse(Console.ReadLine());

            
            if (bookList.Exists(numberOfBookX => numberOfBookX.bookID == deleteBook))
            {
               if(bookList.Exists(numberOfBookX => numberOfBookX.bookID > 0))
                {
                    try
                    {
                        bookList.RemoveAt(deleteBook - 1);
                        Console.WriteLine("Book ID {0} has deleted Successfully!", deleteBook);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception :- " + e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Book ID must be greater than zero");
                }
                
            }
            else
            {
                Console.WriteLine("Book ID - {0} not exist!", deleteBook);
            }
            bookList.Add(books);

        }
        /************************ end of Librarian Functionality*************************/


        /*****************************Borrower Functionality start**************************/
         public static void fBorrower()
        {
            //Thread.Sleep(500); //for delay
            // Console.Clear();
            Console.WriteLine("*****************************************");
            Console.WriteLine("--------------BORROWER-MENU--------------");
            Console.WriteLine("*****************************************");
            Console.WriteLine("\t1.Borrow the book");
            Console.WriteLine("\t2.Return the book");
            Console.WriteLine("\t3.Return to Main Menu");
            Console.WriteLine("*****************************************");

            Console.WriteLine("Choose option from Menu:");
            int myOption;
            //for user who enter letter
            try
            {
                myOption = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Letters not allow:" + e.Message);
                myOption = int.Parse(Console.ReadLine());
                fBorrower();
            }

            switch (myOption)
            {
                case 3:
                    Console.WriteLine("Thank you! Have a Great Learning..");
                    Thread.Sleep(1000);
                    Console.Clear();
                    //isTrue = false;
                    break;

                case 2:
                    //return the book
                    returnBook();
                    fBorrower();
                    break;

                case 1:
                    //borrow the book
                    borrowBook();
                    fBorrower();
                    break;


                default:
                    Console.WriteLine("Please enter valid option!");
                    break;

            }
        }
         static void borrowBook()
        {
            

            Books books = new Books();
            BorrowDetails borrowers = new BorrowDetails();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            Console.Write("User ID: {0}", (borrowers.userID = borrowList.Count + 1));
            Console.WriteLine(); // for next line
            Console.WriteLine("Enter User Name:");
            borrowers.userName = Console.ReadLine();

            Console.WriteLine("Enter Book ID:");
            borrowers.borrowBookID = int.Parse(Console.ReadLine());

            Console.WriteLine("Number of Books want to borrow:");
            borrowers.borrowCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Address:");
            borrowers.userAddress = Console.ReadLine();

            borrowers.borrowDate = DateTime.Now;
            Console.WriteLine("Date:- {0} and Time:- {1}", borrowers.borrowDate.ToShortDateString(), borrowers.borrowDate.ToShortTimeString());
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            Console.WriteLine("+       Book Issued Successfully!       +");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");

            if (bookList.Exists(numberOfBookX => numberOfBookX.bookID == borrowers.borrowBookID))
            {
                foreach (Books findID in bookList)
                {
                    int totalCount = findID.bookCount - borrowers.borrowCount;
                    if (findID.bookCount >= totalCount && totalCount >= 0)
                    {
                        if (findID.bookID == borrowers.borrowBookID)
                        {
                            findID.bookCount = totalCount;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} books are found:)", findID.bookCount);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Book ID - {0} not found:(", borrowers.borrowBookID);

            }
            borrowList.Add(borrowers);


        }
         static void returnBook()
        {

            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            Console.Write("Enter Book ID: ");
            int returnBookId = int.Parse(Console.ReadLine());

            Console.Write("Number of Books want to return: ");
            int returnBookCount = int.Parse(Console.ReadLine());
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");

            if (bookList.Exists(numberOfBookX => numberOfBookX.bookID == returnBookId))
            {
                foreach (Books addReturnBook in bookList)
                {
                    if (addReturnBook.numberOfBookX >= returnBookCount + addReturnBook.bookCount)
                    {
                        if (addReturnBook.bookID == returnBookId)
                        {
                            addReturnBook.bookCount = addReturnBook.bookCount + returnBookCount;
                            Console.WriteLine("Book ID - {0} return, Successfully!", returnBookId);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("you borrow less books that you enter!");
                        break;
                    }
                }
            }

        }
        /*****************************end of Borrower Functionality**************************/

    }//endOfInternalProgramClass
}//endOfNamespace
