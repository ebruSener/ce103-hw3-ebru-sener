
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ce103_hw3_library_app
{


    public class password
    {
        
          public  void login()
            {

                int RightToTry = 3;

                while (true)
                {
                    Console.WriteLine("Enter your username: ");
                    string username = Console.ReadLine();

                    Console.WriteLine("Enter your password: ");
                    string Password = Console.ReadLine();


                    if (username == "ebrusener" && Password == "1110")
                    {
                        Console.WriteLine("Logged in!");
                        break;
                    }



                    else
                    {
                        Console.WriteLine("Your username or password is incorrect");

                        if (RightToTry > 0)
                        {
                            RightToTry = -1;
                        }
                        if (RightToTry == 0)
                        {
                            Console.WriteLine("Your right has expired. You cannot login!!!");
                            break;

                        }

                    }
                    Console.ReadLine();



                }
            Console.ReadKey();
            Console.ReadLine();

            FirstScreen mylib = new FirstScreen();
            mylib.Start();







        }
        
    }



 
}



