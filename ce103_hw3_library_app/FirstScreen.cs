using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Console;
using ce103_hw3_library_app;
using System.Diagnostics.Tracing;
using ce103_hw3_library_dll;


namespace ce103_hw3_library_app
{
    public class FirstScreen

    {



            int SelectedIndex;
            string[] Options;
            string Prompt;
        private readonly object comboBox1;

        public void Start()
            {

                 Title = "My Library";
                RunMainMenu();

            }

            public void RunMainMenu()
            {

                string prompt = @"
               
███╗   ███╗██╗   ██╗    ██╗     ██╗██████╗ ██████╗  █████╗ ██████╗ ██╗   ██╗
████╗ ████║╚██╗ ██╔╝    ██║     ██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝
██╔████╔██║ ╚████╔╝     ██║     ██║██████╔╝██████╔╝███████║██████╔╝ ╚████╔╝ 
██║╚██╔╝██║  ╚██╔╝      ██║     ██║██╔══██╗██╔══██╗██╔══██║██╔══██╗  ╚██╔╝  
██║ ╚═╝ ██║   ██║       ███████╗██║██████╔╝██║  ██║██║  ██║██║  ██║   ██║   
╚═╝     ╚═╝   ╚═╝       ╚══════╝╚═╝╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝   
                                                                            

                
                
                Welcome to the MyLibrary. What would you like to do?
(Use the arrow keys to cycle through options and press enter to select an option.)";
                string[] options = {"BOOKS LIST", "ADD BOOK", "DELETE BOOK", "EDIT BOOK", "BOOK STATUS", "CATEGORİES", "EXIT" };
                Menu  mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.Run();

                switch (selectedIndex)
                {

                    case 0:
                        bookslist();
                        break;
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        DeleteBook();
                        break;
                    case 3:
                        EditBook();
                        break;
                    case 4:
                        BookStatus();
                        break;
                    case 5:
                        Categories();
                        break;                   
                    case 7:
                        ExitLibrary();
                        break;
                    default:
                        break;

                }

            }

         

       
            
            public void ExitLibrary()
            {

            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);

            
            }

            public void Categories()
            {

           
                string[] options = { "ADD CATEGORY", "DELETE CATEGORY", "CATEGORY LIST", "CATEGORY BOOK", "EXIT" };
                Menu mainMenu = new Menu(Prompt, options);
                int selectedIndex = mainMenu.Run();

                switch (selectedIndex)
                {


                   
                    case 0:
                        AddCategory();
                        break;
                    case 1:
                        DeleteCategory();
                        break;
                    case 2:
                        CategoryList();
                        break;
                    case 3:
                        CategoryBook();
                        break;
                    case 4:
                        ExitCategories();
                        break;
                    default:
                        break;
                }

            }
       
        
        
        
        public void AddCategory()
            {
                Clear();
                Console.WriteLine("Enter the category you want to add: ");
                string category = Console.ReadLine();

                Clear();
                Console.WriteLine("CATEGORY IS ADDED!");
                Console.WriteLine("Category you added: " + category);
                Console.ReadLine();

            

            categories mycat = (new categories { category = category });
            StreamWriter streamWriter = new StreamWriter("category.dat", true, Encoding.GetEncoding("Windows-1254"));
            streamWriter.WriteLine("Added Category: "  + mycat.category + "\n" + "\n******************************\n");
            streamWriter.Close();
            streamWriter.Dispose();







            string[] options = { "EXIT" };
               Menu mainMenu = new Menu(Prompt, options);
               int selectedIndex = mainMenu.Run();

            switch (selectedIndex) 
            {
                case 0:
                    ExitAddCategory();
                    break;
            }
            
            } 
                     public void ExitAddCategory() 
                     {
                           FirstScreen mylib = new FirstScreen();
                           mylib.Start();
                     }
         
            public void DeleteCategory()
            {

            Console.WriteLine("Type the category you want to delete: ");
            string deletecategory =Console.ReadLine();

             string file_way = @"C:\Users\asus\OneDrive\Masaüstü\ce103-hw3-ebru-sener\ce103_hw3\ce103_hw3_library_app\bin\Debug\category.dat";
             if (System.IO.File.Exists(file_way)) 
            {
                System.IO.File.Delete(file_way);
                Console.Write("CATEGORY IS DELETED.");
            
            }
            else 
            {
                Console.Write("THERE IS NO SUCH FILE!");
            }
            Console.ReadKey();

            FirstScreen mylib = new FirstScreen();
            mylib.Start();

            }
            public void CategoryList()
            {
            Clear();
            string fileway = @"C:\Users\asus\OneDrive\Masaüstü\ce103-hw3-ebru-sener\ce103_hw3\ce103_hw3_library_app\bin\Debug\category.dat";
            string books1 = System.IO.File.ReadAllText(fileway);
            Console.WriteLine(books1);

            Console.ReadLine() ;

            FirstScreen mylib = new FirstScreen();
            mylib.Start();


            }
     
        public void CategoryBook()
            {

            }

            public void ExitCategories()
            {
           
            FirstScreen mylib = new FirstScreen();
            mylib.Start();
            }

            

            public void BookStatus()
            {    
                BookStatus:
                Clear();
                WriteLine("BOOK STATUS");
                string[] options = { "Present", "Not Present", "Exit" };
                Menu mainMenu = new Menu(Prompt, options);
                int SelectedIndex = mainMenu.Run();


                switch (SelectedIndex)

                {
                    case 0:
                        Present();
                        break;
                    case 1:
                        NotPresent();
                        break;
                    case 2:
                        ExitBookStatus();
                    goto BookStatus;
                    
                default:
                        break;


                }

            }

                    public void Present()
                     {
                        string[] options = { "ExitPresent" };
                        Menu mainMenu = new Menu(Prompt, options);
                        int SelectedIndex = mainMenu.Run();

                         switch (SelectedIndex) 
                          {     case 0:
                                  ExitPresent();
                                 break;
                                 default: 
                                 break;

                    
            
                          }
                     }   
                    public void ExitPresent() 
                     {
            
          
                     }

           
                    public void NotPresent()
                    {
                        string[] options = { "ExitNotPresent" };
                        Menu mainMenu = new Menu(Prompt, options);
                        int SelectedIndex = mainMenu.Run();

                           switch (SelectedIndex) 
                           {
                              case 0:
                                ExitNotPresent();
                                 break;
                                 default:
                                 break;
            
                           }
                    }
                     public void ExitNotPresent() 
                     {
        
                     }

                     public void ExitBookStatus()
                     {
                         FirstScreen mylib = new FirstScreen();
                          mylib.Start();

                     }

            public void EditBook()
            {
             string[] options = { "ExitEditBook" };
                        Menu mainMenu = new Menu(Prompt, options);
                        int SelectedIndex = mainMenu.Run();

                           switch (SelectedIndex) 
                           {
                              case 0:
                                ExitEditBook();
                                 break;
                                 default:
                                 break;
            
                           }
            }

            
            public void ExitEditBook() 
            {
              FirstScreen mylib = new FirstScreen();
              mylib.Start();
            }


            public void DeleteBook()
            {


            Console.WriteLine("Type the book you want to delete: ");
            string deletecategory = Console.ReadLine();

            string file_way = @"C:\Users\asus\OneDrive\Masaüstü\ce103-hw3-ebru-sener\ce103_hw3\ce103_hw3_library_app\bin\Debug\Books.dat";
            if (System.IO.File.Exists(file_way))
            {
                System.IO.File.Delete(file_way);
                Console.Write("BOOK IS DELETED.");

            }
            else
            {
                Console.Write("THERE IS NO SUCH FILE!");
            }
            Console.ReadKey();

            FirstScreen mylib = new FirstScreen();
            mylib.Start();



            }
            public void AddBook()
            {

                Clear();
                Console.Write("Book's ID: ");
                string ID = Console.ReadLine();
                int ıd = Convert.ToInt32(ID);

                Clear();
                Console.Write("Book's Name: ");
                string Name = Console.ReadLine();

                Clear();
                Console.Write("Book's Author: ");
                string Author = Console.ReadLine();

                Clear();
                Console.Write("Book's Year: ");
                string Year = Console.ReadLine();
                int year = Convert.ToInt32(Year);

                Clear();
                Console.Write("Book's Pages: ");
                string Pages = Console.ReadLine();
                int page = Convert.ToInt32(Pages);

                Clear();
                Console.Write("Book's Edition: ");
                string Edition = Console.ReadLine();
                int edition = Convert.ToInt32(Edition); 

                Clear();
                Console.Write("Book's Editors: ");
                string Editor = Console.ReadLine();

                Clear();
                Console.Write("Book's Publisher: ");
                string Publisher = Console.ReadLine();

                Clear();
                Console.Write("Book's Category: ");
                string category = Console.ReadLine();

                Clear();
                Console.Write("Book's Abstract: ");
                string Abstract = Console.ReadLine();

                Clear();
                Console.Write("Tags: ");
                string tags = Console.ReadLine();

                Clear();
                Console.Write("Author Keywords: ");
                string keywords = Console.ReadLine();

                Clear();
                Console.Write("City: ");
                string city = Console.ReadLine();

                Clear();
                Console.Write("URL: ");
                string url = Console.ReadLine();

                Clear();
                Console.Write("Catalog Ids: ");
                string catalogIds = Console.ReadLine();

                Clear();
                Console.Write("Price: ");
                string price = Console.ReadLine();

                Clear();
                Console.Write("Rack No: ");
                string rackNo = Console.ReadLine();
                int RackNo = Convert.ToInt32(rackNo);

                Clear();
                Console.Write("Row No: ");
                string rowNo = Console.ReadLine();
                int RowNo = Convert.ToInt32(rowNo);

                
                


                Clear();

                Clear();
                Console.WriteLine("         --BOOK ADDED--     ");
                Console.WriteLine("Book's ID: " + ID);
                Console.WriteLine("Book's Name: " + Name);
                Console.WriteLine("Book's Author: " + Author);
                Console.WriteLine("Book's Year: " + Year);
                Console.WriteLine("Book's Pages: " + Pages);
                Console.WriteLine("Book's Edition: " + Edition);
                Console.WriteLine("Book's Editors: " + Editor);
                Console.WriteLine("Book's Publisher: " + Publisher);
                Console.WriteLine("Book's Category: " + category);
                Console.WriteLine("Book's Abstract: " + Abstract);
                Console.WriteLine("Book's Tag: " + tags);
                Console.WriteLine("Author Keyword:" + keywords);
                Console.WriteLine("Book City: " + city);
                Console.WriteLine("Book's URL: " + url);
                Console.WriteLine("Book's Catalog Ids: " + catalogIds);
                Console.WriteLine("Book's Price: " + price);
                Console.WriteLine("Book's Rack No: " + RackNo);
                Console.WriteLine("Book's Row No: " + RowNo);
                







                  books mybooks = ( new books {ıd = ıd, BookName = Name, BookAuthor = Author, BookYear = year, BookPage = page, BookEdition = edition, BookEditor = Editor, BookPublisher = Publisher, BookCategory = category , BookAbstract = Abstract, BookTag = tags, AuthorKeyword = keywords, BookCity = city, BookUrl = url, BookCatIds = catalogIds, BookPrice = price, BookRackNo = RackNo, BookRowNo = RowNo  } );
                  StreamWriter streamWriter = new StreamWriter("Books.dat", true, Encoding.GetEncoding("Windows-1254"));
                  streamWriter.WriteLine("ID:" + mybooks.ıd + "\n" + "Book Name:" + mybooks.BookName + "\n" + "Book Author:" + mybooks.BookAuthor + "\n" + "Book Year:" + mybooks.BookYear + "\n" + "Book Page" + mybooks.BookPage + "\n" + "Book Edition:" + mybooks.BookEdition + "\n" + "Book Editor:" + mybooks.BookEditor + "\n" + "Book Publisher:" + mybooks.BookPublisher + "Book Category:" + mybooks.BookCategory +             
                  "\n" + "Book Abstract:" + mybooks.BookAbstract + "\n" + "Book Tag:" + mybooks.BookTag + "\n" +  "Author Keyword:" + mybooks.AuthorKeyword + "\n" + "Book City:" + mybooks.BookCity + "\n" + "Book URL:" + mybooks.BookUrl + "\n" + "Catalog Ids:" + mybooks.BookCatIds + "\n" + "Book Price:" + mybooks.BookPrice + "\n" + "Book Rack No:" + mybooks.BookRackNo + "\n" + "Book Row No:" + mybooks.BookRowNo + "\n" + "\n******************************\n");
                  streamWriter.Close();
                  streamWriter.Dispose();



                 Console.ReadLine();



            FirstScreen mylib = new FirstScreen();
            mylib.Start();
            }


        public void bookslist()
        {


            Clear();
            string fileway = @"C:\Users\asus\OneDrive\Masaüstü\ce103-hw3-ebru-sener\ce103_hw3\ce103_hw3_library_app\bin\Debug\Books.dat";
            string books1 = System.IO.File.ReadAllText(fileway);
            Console.WriteLine(books1);





            Console.ReadLine();

            FirstScreen mylib = new FirstScreen();
            mylib.Start();



        }







    }
      
      
}
   


