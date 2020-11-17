using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem todoItem = new TodoItem("my todo", "my user", DateTime.Now);

        [TestMethod]
        public void NewTodoItemShouldBeUndone()
        {
            Assert.AreEqual(todoItem.Done, false);
        }
    }
}
