namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors( this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    //We are using basic CORS policy settings because allowing any origin,
                    //method, and header is okay for now.But we should be more
                    //restrictive with those settings in the production environment.More
                    //precisely, as restrictive as possible.
                    //Instead of the AllowAnyOrigin() method which allows requests from any
                    //source, we can use the WithOrigins("https://example.com") which will
                    //allow requests only from that concrete source.Also, instead of9
                    //AllowAnyMethod() that allows all HTTP methods, we can use
                    //WithMethods("POST", "GET") that will allow only specific HTTP methods.
                    //Furthermore, you can make the same changes for the AllowAnyHeader()
                    //method by using, for example, the WithHeaders("accept", "contenttype") method to allow only specific headers.
                    builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();

                });
            });
        }
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options =>
        {
        });
    }
}
