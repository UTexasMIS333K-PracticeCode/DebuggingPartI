using Microsoft.AspNetCore.Mvc;

//you need to give the controllers namespace access to your models
using DebuggingPartI.Models;

namespace DebuggingPartI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Product()
        {
            //create a new instance of the product class
            Product product = new Product();

            //set the properties of the object
            product.ProductID = 100042;
            product.ProductName = "An example product";
            product.ProductCost = 5.99;
            product.InventoryOnHand = 1000;

            //call methods to calculate properties
            product.CalculateValueOfInventory();

            //return the object to the view
            return View(product);
        }

        public IActionResult Index()
        {
            return View();
        }

        //new method to create a basic job posting
        public IActionResult CreateNewPosting()
        {
            //this displays the blank form to create a new posting
            return View();
        }

        //new method to display the new posting with fields calculated
        public IActionResult JobPosting(JobPosting jobPosting)
        {
            //validate that the information in the posting is correct
            TryValidateModel(jobPosting);

            //if model state is not correct, send user back to the view
            if (ModelState.IsValid == false) //something is wrong
            {
                //go back to the create view
                return View("CreateNewPosting", jobPosting);
            }

            //if code gets this far, we need to calculate the values
            try
            {
                jobPosting.CalculateCompensation();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "There was an error." + " " + ex.Message;
                return View("CreateNewPosting", jobPosting);
            }

            //display the posting in the Index view
            //we do not need another view, since Index is already 
            //set up to display a job posting
            ViewBag.Message = "Input successful!";
            return View(jobPosting);
        }
    }
}
