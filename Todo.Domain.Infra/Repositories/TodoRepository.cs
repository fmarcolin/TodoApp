using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public void Create(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(Guid id, string user)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
