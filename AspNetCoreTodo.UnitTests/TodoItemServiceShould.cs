using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;
        namespace AspNetCoreTodo.UnitTests
        {
            public class TodoItemServiceShould
            {
                [Fact]
                public async Task AddNewItemAsIncompleteWithDueDate()
                {
                    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                        .UseInMemoryDatabase(databaseName: "Test_AddNewItem").Options;
                    // Set up a context (connection to the "DB") for writing
                    using (var context = new ApplicationDbContext(options))
                    {
                        var service = new TodoItemService(context);
                        var fakeUser = new ApplicationUser
                        {
                            Id = "fake-000",
                            UserName = "fake@example.com"
                        };
                        
                        await service.AddItemAsync(new TodoItem
                        {
                            Title = "Testing?"
                        }, fakeUser);
                    }

                    // Use a separate context to read data back from the "DB"
                    using (var context = new ApplicationDbContext(options))
                    {
                        var itemsInDatabase = await context
                        .Items.CountAsync();
                        Assert.Equal(1, itemsInDatabase);
                        
                        var item = await context.Items.FirstAsync();
                        Assert.Equal("Testing?", item.Title);
                        Assert.Equal(false, item.IsDone);
                        
                        // Item should be due 3 days from now (give or take a second)
                        var difference = DateTimeOffset.Now.AddDays(3) - item.DueAt;
                        Assert.True(difference < TimeSpan.FromSeconds(1));
                        }
                    }
            }
        }
