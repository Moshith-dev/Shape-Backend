using Shape.DataBaseConnection;
using Shape.Handlers;
using Shape.Repositories;

namespace Shape
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSingleton<DbConnection>(); // Register DbConnection

            // Register the repository
            builder.Services.AddScoped<IRepository, Repository>(); // Register IRepository and its implementation

            // Register handlers
            builder.Services.AddScoped<ContactUsHandler>();
            builder.Services.AddScoped<IconsHandler>();
            builder.Services.AddScoped<PageContentHandler>();
            builder.Services.AddScoped<EmployeeHandler>();
            builder.Services.AddScoped<MenuHandler>();

            // Add Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}