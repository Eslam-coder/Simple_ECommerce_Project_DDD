using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0___SharedKernel.CQRS
{
    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
    }

    public interface IResultCommandHandler<TCommand> : ICommandHandler<TCommand, CommandResult>
        where TCommand : IResultCommand
    {
    }
}
