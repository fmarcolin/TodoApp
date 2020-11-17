using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<SetTodoAsDoneCommand>,
        IHandler<SetTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada",
                    command.Notifications);

            var todo = new TodoItem(command.Title, command.User, command.Date);

            _repository.Create(todo);

            return new GenericCommandResult(
                true,
                "Tarefa salva com sucesso",
                todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada",
                    command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.UpdateTitle(command.Title);

            _repository.Update(todo);

            return new GenericCommandResult(
                true,
                "Tarefa atualizada com sucesso",
                todo);
        }

        public ICommandResult Handle(SetTodoAsDoneCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada",
                    command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.SetAsDone();

            _repository.Update(todo);

            return new GenericCommandResult(
                true,
                "Tarefa atualizada com sucesso",
                todo);
        }

        public ICommandResult Handle(SetTodoAsUndoneCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada",
                    command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.SetAsUndone();

            _repository.Update(todo);

            return new GenericCommandResult(
                true,
                "Tarefa atualizada com sucesso",
                todo);
        }
    }
}
