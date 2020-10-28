using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
//need to reference the model

        namespace AspNetCoreTodo.Services
        {
            public interface ITodoItemService
            
            {
                Task<TodoItem[]> GetIncompleteItemsAsync();
                Task<bool> AddItemAsync(TodoItem newItem);
            }
            //Getincompleteitemsasync requires no parameter and returns task<todoitem[]>
            //the task type is like a promise because getincomplete... is an async method so i may not get my todo immediately because
            //I need to talk to the db
        }




//the object methods and properties are defined/signed here
//for interacting with the todo items in the db