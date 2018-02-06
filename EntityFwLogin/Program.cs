using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFwLogin
{
  class Program
  {
    static void Main(string[] args)
    {

      string username;
      string password;

      while (true)
      {
        // User input: username and password
        Console.WriteLine("Please enter your username: ");
        username = Console.ReadLine();

        Console.WriteLine("Please enter your password: ");
        password = Console.ReadLine();

        Console.WriteLine();

        try
        {
          // Check username and password using LINQ
          using (LoginEntities context = new LoginEntities())
          {

            // Case-insensetive because of server collation
            var user = context.users.Where(u => u.username == username && u.password == password).FirstOrDefault();

            // Check if user is found
            if (user != null)
            {
              Console.WriteLine("You have successfully logged in.");
              Console.ReadLine();
              return;
            }
            else
            {
              Console.WriteLine("Login failed, please try again. q to quit");
            }

            // q to quit the program
            if (Console.ReadLine().Equals("q"))
            {
              return;
            }

            Console.WriteLine();
          }
        }
        catch (EntityException ex)
        {
          // Show a message box (an error has occurred)
          Console.WriteLine("Error while accessing the data base...");

          // Inform an admin/log the error
          // ...
        }


      }
    }
  }
}
