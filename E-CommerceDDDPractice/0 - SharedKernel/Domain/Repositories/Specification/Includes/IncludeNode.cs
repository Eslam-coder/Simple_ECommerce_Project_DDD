using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0___SharedKernel.Domain.Repositories.Specification.Includes
{
    public class IncludeNode
    {
        public Type EntityType { get; }

        public Type PropertyType { get; }

        public Type PreviousPropertyType { get; }

        public bool ForIEnumerable { get; }

        public Expression IncludeExpression { get; }

        public IncludeNode SubNode { get; set; }

        public IncludeNode(
            Expression includeExpression,
            Type entityType,
            Type propertyType,
            Type previousPropertyType = null,
            bool forIEnumerable = false)
        {
            IncludeExpression = includeExpression;
            EntityType = entityType;
            PropertyType = propertyType;
            PreviousPropertyType = previousPropertyType;
            ForIEnumerable = forIEnumerable;
        }
    }
}
