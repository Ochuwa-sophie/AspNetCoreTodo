using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        //this action method is responsible for 
        //1. getting the to-do items from the db
        //2. putting those items into a model the view can understand
        //3. sending the view back to the user's browser
        
        //using IActionResult because it gives me a wider scope of return types
        public IActionResult Index()
        {

        }
    }


   
    
}