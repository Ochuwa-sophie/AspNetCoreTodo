using System;

namespace AspNetCoreTodo.Models
{
    //model in the mvc so contains multiple todoitem model
    public class TodoViewModel
    {
        public TodoItem[] Items { get; set; }
    }
}