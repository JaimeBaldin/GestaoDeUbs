using GestaoDeUbs.Domain.Command.Interfaces;

namespace GestaoDeUbs.Domain.Handlers.Interfaces;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T comando);
}
