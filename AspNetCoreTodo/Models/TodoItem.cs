using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTodo.Models
{
    public class TodoItem
    {
        //get = read, set = write
        //POCO way of doing things
        //model for each todoitem class
        public Guid Id { get; set; }
        public bool IsDone { get; set; }

        [Required]
        public string Title { get; set; }
        public DateTimeOffset? DueAt { get; set; }
    }
}