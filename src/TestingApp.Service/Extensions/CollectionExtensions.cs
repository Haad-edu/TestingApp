using TestingApp.Domain.Configurations;

namespace TestingApp.Service.Extensions;

public static  class CollectionExtensions
{
    public static IQueryable<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams @params)
    {
        return @params.PageIndex > 0 && @params.PageSize >= 0
            ? source.Take(((@params.PageIndex - 1) * @params.PageSize)..@params.PageSize)
            : source;
    }
}
