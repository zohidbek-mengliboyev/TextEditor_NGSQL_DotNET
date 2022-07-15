using TextEditor_NGSQL_DotNET.Interface;
using TextEditor_NGSQL_DotNET.IRepository;
using TextEditor_NGSQL_DotNET.Repository;
using TextEditor_NGSQL_DotNET.Service;

namespace TextEditor_NGSQL_DotNET.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IPostContentRepository, PostContentRepository>();
            services.AddScoped<IPostContentService, PostContentService>();
        }
    }
}
