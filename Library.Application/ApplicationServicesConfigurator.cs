using Library.Application.Services.Authors;
using Library.Application.Services.Books;
using Library.Application.Services.Books.Dto;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;

public static class ApplicationServicesConfigurator
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BookMappingProfile));
        
        services.AddTransient<IAuthorService, AuthorService>();
        services.AddTransient<IBookService, BookService>();

        return services;
    }
}