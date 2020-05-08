using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Lucas Rock
// CIS 237
// 4/1/2020
namespace cis237_assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Console Window Size
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.WindowHeight = 40;
            Console.WindowWidth = 120;

            // Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            // Create an instance of the BeverageCollection class
            BeverageRepository _beverageRepository = new BeverageRepository();

            // Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            // Display the Menu and get the response. Store the response in the choice integer
            // This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            // While the choice is not exit program
            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        // Display all of the items in the Database
                        userInterface.DisplayAllItems();
                        break;

                    case 2:
                        // Make a new beverage in order to get the user information
                        Beverage beverageToAdd = new Beverage();
                        // Get the user information for the new beverage
                        userInterface.GetNewItemInformation(beverageToAdd);
                        // Adds the new beverage to the database based on the information submitted from the user
                        
                        break;

                    case 3:
                        // Make a new instance of beverage to hold the user information
                        Beverage beverageToUpdate = new Beverage();
                        // Get the information from the user about what they want to change
                        userInterface.UpdateItemInformation(beverageToUpdate);
                        // Change the beverage if it is found in the database
                        
                        break;

                    case 4:
                        // Gets the ID from the User of the beverage they want to search for
                        string searchQuery = userInterface.GetSearchQuery();
                        // Finds the beverage with the ID from the user and prints it out
                        userInterface.DisplayItemFound(searchQuery);
                        break;
                    case 5:
                        // Gets the ID of what the user wants to delete
                        string searchToDelete = userInterface.GetSearchQuery();
                        // Uses the ID to find the beverage and delete it from the database
                        userInterface.DeleteBeverage(searchToDelete);
                        break;
                }

                // Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }
        }
    }
}
