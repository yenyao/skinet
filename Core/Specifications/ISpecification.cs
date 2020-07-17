using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        // Allows for paging, takes the first x amount
        int Take { get; }
        // Allows for paging, omits the other x amount
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
