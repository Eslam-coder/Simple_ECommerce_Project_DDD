using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0___SharedKernel.CQRS
{
    public interface IQueryHandler<TQuery, TQueryResult> : IRequestHandler<TQuery, TQueryResult>
        where TQuery : IQuery<TQueryResult>
    {
    }
}
