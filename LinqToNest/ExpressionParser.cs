namespace LinqToNest
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public static class ExpressionParser
    {
        public static object Process(Expression expression)
        {
            var nodeType = expression.NodeType;

            return "{\"query\":{\"bool\":{\"filter\":{\"term\":{\"IntProp\":2}}}}}";
        }

        //private static object ProcessCallExpression(MethodCallExpression methodCallExpression)
        //{
        //    var methodName = methodCallExpression.Method.Name;
        //    switch (methodName)
        //    {
        //        case "Where":

        //            break;
        //        default:
        //            throw new NotImplementedException();
        //    }
        //}
    }
}