namespace LinqToNest
{
    using System.Linq.Expressions;

    public interface IQueryContext
    {
        object Execute(Expression expression, bool isEnumerable);
    }
}