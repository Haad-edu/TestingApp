
using TestingApp.Domain.Configurations;

namespace TestingApp.Service.Extensions;

public static class CollectionExtension
{
    public static IQueryable<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams @params) 
    {
        if (@params.PageIndex > 0 && @params.PageSize > 0) 
        {
            return source.Skip((@params.PageIndex - 1) * @params.PageSize).
                Take(@params.PageSize);
        }

        return source;
    }
}
