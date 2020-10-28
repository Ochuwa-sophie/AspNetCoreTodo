using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Services;

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

        }
    }


   
    
}