namespace LinqToNest
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class ElasticQueryable<T> : IQueryable<T>
    {
        public ElasticQueryable(IQueryContext queryContext)
        {
            Initialize(new QueryProvider(queryContext), null);
        }

        public ElasticQueryable(IQueryProvider provider)
        {
            Initialize(provider, null);
        }

        internal ElasticQueryable(IQueryProvider provider, Expression expression)
        {
            Initialize(provider, expression);
        }

        public Expression Expression { get; private set; }

        public IQueryProvider Provider { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return (Provider.Execute<IEnumerable<T>>(Expression)).GetEnumerator();
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (Provider.Execute<System.Collections.IEnumerable>(Expression)).GetEnumerator();
        }

        public Type ElementType
        {
            get { return typeof(T); }
        }

        private void Initialize(IQueryProvider provider, Expression expression)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            if (expression != null && !typeof(IQueryable<T>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentException(String.Format("Not assignable from {0}", expression.Type), "expression");
            }

            Provider = provider;
            Expression = expression ?? Expression.Constant(this);
        }
    }
}