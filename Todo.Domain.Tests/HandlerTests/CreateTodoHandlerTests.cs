﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("My test", "My valid test", DateTime.Now);

        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        public CreateTodoHandlerTests()
        {
        }

        [TestMethod]
        public void InvalidCommandShouldStop()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);

            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void ValidCommandShouldCreateNewItem()
        {
            var result = (GenericCommandResult)_handler.Handle(_validCommand);

            Assert.AreEqual(result.Success, true);
        }
    }
}
