namespace Notary.Configurations
{
    public static class CorsConfiguration
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddDefaultPolicy(builder => builder
                .WithOrigins("https://localhost:44383")
                .AllowAnyHeader()
                .AllowAnyMethod()
            ));
        }
    }
}
