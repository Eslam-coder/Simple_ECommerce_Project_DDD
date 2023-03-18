using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0___SharedKernel.CQRS
{
    public interface ICommand<TResult> : IRequest<TResult>
    {
    }

    public interface IResultCommand : ICommand<CommandResult>
    {

    }
}
