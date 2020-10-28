using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync(ApplicationUser user);
        // Task <bool> AddItemAsync(TodoItem newItem, ApplicationUser user);
        // Task<bool> MarkDoneAsync(Guid id, ApplicationUser user);
        
        // Task<DateTimeOffset> SetDueDateAsync(TodoItem newItem);
    }
}