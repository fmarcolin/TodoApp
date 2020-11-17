using System;
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string User)
        {
            return x => x.User == User;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(string User)
        {
            return x => x.User == User && x.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUndone(string User)
        {
            return x => x.User == User && !x.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetByDay(string User, DateTime date, bool done)
        {
            return x => 
                x.User == User && 
                x.Done == done &&
                x.Date.Date == date.Date;
        }
    }
}
