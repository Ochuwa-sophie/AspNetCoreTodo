using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        //this action method is responsible for 
        //1. getting the to-do items from the db. We'll use services to do this so as to keep the controller lean
        //2. putting those items into a model the view can understand
        // this I'm doing . 3. sending the view back to the user's browser/view rendering
        //this I'm also doing . handle incoming data or input from the user
        //business logic is handled by my service class


        // Presentation layer = ontrollers and view 
        // Service layer =  business logic and databse code

       //using IActionResult because it gives me a wider scope of return types
       
       private readonly ITodoItemService _todoItemService; //reference to the interface
       
       public TodoController(ITodoItemService todoItemService) //defines constructor for the todocontroller class, object must match Itodoitemservice interface in order to create the todocontroller
       {
            _todoItemService = todoItemService;
       }
       //the above will help my controler work with the todoitemserviceinterface aka ITodoItemService

        public async Task<IActionResult> Index()
        //because async
        
        {
            var items = await _todoItemService.GetIncompleteItemsAsync();
//takes todo item from service and puts them in the view model then bind model to the view

            var model = new TodoViewModel()
            {
                Items = items
            };
                
            return View(model);
        }
//model binding btw todomodel properties and data in a request. the browser POSTs to this action once user submits the form.
//model validation checks wether the data bound tot he model from the incoming request makes sense or is valid
        [ValidateAntiForgeryToken]
       //the above is also involved in preventing cross-site request forgery, it looks for and verifies the hidden verification token added to the form by asp-action tag helper
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("Index");
        }

    }  
}