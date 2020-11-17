using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueriesTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("title 1", "user", DateTime.Now));
            _items.Add(new TodoItem("title 2", "another user", DateTime.Now));
            _items.Add(new TodoItem("title 3", "another user", DateTime.Now));
            _items.Add(new TodoItem("title 4", "user", DateTime.Now));
            _items.Add(new TodoItem("title 5", "user", DateTime.Now));
            _items.Add(new TodoItem("title 6", "another user", DateTime.Now));
            _items.Add(new TodoItem("title 7", "another user", DateTime.Now));
            _items.Add(new TodoItem("title 8", "user", DateTime.Now));
        }

        [TestMethod]
        public void ShoudReturnJustUserTasks()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("user"));
            Assert.AreEqual(result.Count(), 4);
        }
    }
}
