using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0___SharedKernel.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();

        bool HasChanges();
    }
}
