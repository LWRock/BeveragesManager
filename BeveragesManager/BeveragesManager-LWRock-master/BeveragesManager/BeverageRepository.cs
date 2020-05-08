using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Lucas Rock
// CIS 237
// 4/1/2020
namespace cis237_assignment5
{
    class BeverageRepository
    {
        // Private Variables
        // Instance of beverage context to use the beverages and EF methods
        BeverageContext _beverageContext = new BeverageContext();
        

        // Constructor
        public BeverageRepository()
        {
           
        }

        // Add a new item to the collection
        public void AddNewItem(Beverage beverage)
        {
            try
            {
                _beverageContext.Beverages.Add(beverage); // Takes the beverage passed in and adds it to the database
                _beverageContext.SaveChanges(); // Saves the changes which will show the added beverage
            }
            catch (DbUpdateException) // If the user tries to add a beverage that has an ID that matches one already found
            {
                _beverageContext.Beverages.Remove(beverage);
                Console.WriteLine();
                Console.WriteLine("Beverage must have a unique ID");
            }
            catch (Exception) // Catches any other error
            {
                _beverageContext.Beverages.Remove(beverage);
                Console.WriteLine();
                Console.WriteLine("Can't add the beverage due to an unknown error");
            }
           
        }
        // Updates the information of a beverage already in the collection
        public void UpdateItemInformation(Beverage beverage)
        {
            // New instance of a beverage that is equal to the corresponding beverage found by ID
                Beverage beverageToUpdate = _beverageContext.Beverages.Find(beverage.id); 
            // If the beverage is not null
                if (beverageToUpdate != null)
                {
                // Make the new instance equal to the one passed in
                    beverageToUpdate.id = beverage.id;
                    beverageToUpdate.name = beverage.name;
                    beverageToUpdate.pack = beverage.pack;
                    beverageToUpdate.price = beverage.price;
                    beverageToUpdate.active = beverage.active;
                // Saves the changes done which will now show the updated info
                    _beverageContext.SaveChanges();
                    Console.WriteLine(BeverageToString(beverageToUpdate));
                }
                else
                {
                // If the beverage to be updated is null this will happen
                    Console.WriteLine();
                    Console.WriteLine("Could not find the Beverage to Update");
                }
        }

        
        public string BeverageToString(Beverage beverage)
        {
            // Takes a beverage and returns it as a string.
            return $"{beverage.id} {beverage.name} {beverage.pack} {beverage.price} {beverage.active}";
        }

        // Find an item by it's Id
        public void FindById(string id)
        {
            Beverage _beverageByPK = _beverageContext.Beverages.Find(id);
            if (_beverageByPK != null)
            {
                // Return the returnString
                Console.WriteLine(BeverageToString(_beverageByPK));
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("There is no Beverage with this ID");
            }
            
            
        }
        // Prints out the list of beverages
        public void PrintBeverages()
        {
            foreach (Beverage beverage in _beverageContext.Beverages)
            {
                Console.WriteLine(BeverageToString(beverage));
            }
        }
        // Deletes the beverage if one is found with the same ID that is passed in.
        public void DeleteBeverage(string id)
        {
                // Makes a new instance of a beverage and make it equal to the Beverage with a corresponding ID
                Beverage _beverageToDelete = _beverageContext.Beverages.Find(id);
                if (_beverageToDelete != null) // If the beverage isn't null
                {
                    _beverageContext.Beverages.Remove(_beverageToDelete); // Removes the beverage
                    _beverageContext.SaveChanges(); // Saves the changes done by removing 
                    Console.WriteLine();
                    Console.WriteLine("The Beverage was deleted");
                }
                else // if the beverage is null
                {
                    Console.WriteLine();
                    Console.WriteLine("Could not find the Beverage to Delete");
                }

        }
    }
}
