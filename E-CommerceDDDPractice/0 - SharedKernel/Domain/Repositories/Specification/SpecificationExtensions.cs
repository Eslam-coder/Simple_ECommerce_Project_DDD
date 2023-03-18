using _0___SharedKernel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace _0___SharedKernel.Domain.Repositories.Specification
{
    public static class SpecificationExtensions
    {
        private static readonly MethodInfo _includeMethodInfo = GetIncludeMethodInfo();
        private static readonly MethodInfo _thenIncludeOfIEnumerableMethodInfo =
            GetThenIncludeOfIEnumerableMethodInfo();
        private static readonly MethodInfo _thenIncludeMethodInfo = GetThenIncludeMethodInfo();

        private static MethodInfo GetIncludeMethodInfo()
        {
            return typeof(EntityFrameworkQueryableExtensions)
                   .GetTypeInfo()
                   .GetDeclaredMethods("Include")
                   .Single(mi => mi.GetGenericArguments().Length == 2);
        }

        private static MethodInfo GetThenIncludeOfIEnumerableMethodInfo()
        {
            return typeof(EntityFrameworkQueryableExtensions)
                   .GetTypeInfo()
                   .GetDeclaredMethods("ThenInclude")
                   .Where(mi => mi.GetGenericArguments().Length == 3)
                   .Single(mi =>
                   {
                       var type = mi.GetParameters()[0]
                                    .ParameterType.GenericTypeArguments[1]
                                    .GetTypeInfo();
                       return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
                   });
        }

        private static MethodInfo GetThenIncludeMethodInfo()
        {
            return typeof(EntityFrameworkQueryableExtensions)
                   .GetTypeInfo()
                   .GetDeclaredMethods("ThenInclude")
                   .Where(mi => mi.GetGenericArguments().Length == 3)
                   .Single(mi =>
                           mi.GetParameters()[0]
                             .ParameterType.GenericTypeArguments[1]
                             .GetTypeInfo()
                             .IsGenericType == false);
        }

        public static IQueryable<TEntity> UseCriteria<TEntity>(
            this IQueryable<TEntity> query, ISpecification<TEntity> specification)
            where TEntity : IAggregateRoot
        {
            var result = specification.GetPredicates()
                                      .Aggregate(
                                          query,
                                          (current, specificationCriterion) => 
                                          current.Where(specificationCriterion));
            return result;
        }

        private static IQueryable<TEntity> AddIncludes<TEntity>(
            this IQueryable<TEntity> query,
            ISpecification<TEntity> specification) where TEntity : IAggregateRoot
        {
            var includableSpecification = specification as ISpecification<TEntity>;
            if (includableSpecification == null)
            {
                return query;
            }
            var resultQuery = query as object;
            foreach (var include in includableSpecification.GetIncludes())
            {
                resultQuery = _includeMethodInfo.MakeGenericMethod(include.EntityType, include.PropertyType)
                              .Invoke(null, new[] { resultQuery, include.IncludeExpression });
                var subNode = include;
                while ((subNode = subNode.SubNode) != null)
                {
                    if (subNode.ForIEnumerable)
                    {
                        resultQuery = _thenIncludeOfIEnumerableMethodInfo.MakeGenericMethod(
                                      subNode.EntityType,
                                      subNode.PreviousPropertyType,
                                      subNode.PropertyType)
                                      .Invoke(null, new[]
                                      { 
                                          resultQuery,
                                          subNode.IncludeExpression 
                                      });
                    }
                    else
                    {
                        resultQuery = _thenIncludeMethodInfo.MakeGenericMethod(
                                      subNode.EntityType,
                                      subNode.PreviousPropertyType,
                                      subNode.PropertyType)
                                      .Invoke(null, new[] 
                                      { 
                                          resultQuery, 
                                          subNode.IncludeExpression 
                                      });
                    }
                }
            }
            return (IQueryable<TEntity>)resultQuery;
        }

        public static IQueryable<TEntity> Use<TEntity>(
                   this IQueryable<TEntity> query, ISpecification<TEntity> specification)
                   where TEntity : IAggregateRoot
        {
            return query.UseCriteria(specification)
                        .AddIncludes(specification);
        }
    }
}
