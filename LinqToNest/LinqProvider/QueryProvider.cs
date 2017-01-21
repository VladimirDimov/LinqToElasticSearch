namespace LinqToNest
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class QueryProvider : IQueryProvider
    {
        private readonly IQueryContext queryContext;

        public QueryProvider(IQueryContext queryContext)
        {
            this.queryContext = queryContext;
        }

        public virtual IQueryable CreateQuery(Expression expression)
        {
            Type elementType = TypeSystem.GetElementType(expression.Type);
            try
            {
                return
                   (IQueryable)Activator.CreateInstance(typeof(ElasticQueryable<>).
                          MakeGenericType(elementType), new object[] { this, expression });
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }

        public virtual IQueryable<T> CreateQuery<T>(Expression expression)
        {
            return new ElasticQueryable<T>(this, expression);
        }

        object IQueryProvider.Execute(Expression expression)
        {
            return queryContext.Execute(expression, false);
        }

        T IQueryProvider.Execute<T>(Expression expression)
        {
            return (T)queryContext.Execute(expression,
                       (typeof(T).Name == "IEnumerable`1"));
        }
    }
}