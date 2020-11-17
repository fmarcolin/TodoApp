using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class SetTodoAsUndoneCommand : Notifiable, ICommand
    {
        public SetTodoAsUndoneCommand() { }
        public SetTodoAsUndoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                    new Contract()
                        .Requires()
                        .HasMinLen(User, 6, "User", "Usuário inválido!")
                );
        }
    }
}