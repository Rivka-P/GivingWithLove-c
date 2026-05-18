
using Bl;
using Bl.BLApi;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IBl, BlManager>();// new blmanager
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));



            var app = builder.Build();
            app.UseCors("MyPolicy");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
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


//using System.Text.Json.Serialization;
//using Dal.Models;
//using Microsoft.EntityFrameworkCore;
//var builder = WebApplication.CreateBuilder(args);
//// Register DbContext as scoped (one per request)
//builder.Services.AddDbContext<DbManager>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//// Configure controllers and ignore reference cycles (temporary; prefer DTOs)
//builder.Services.AddControllers().AddJsonOptions(opts =>
//{
//    opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//    opts.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
//});
//var app = builder.Build();
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

//app.MapControllers();
//app.Run();
