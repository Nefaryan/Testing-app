using Microsoft.EntityFrameworkCore;
using MonsterHunterBE.Data;
using MonsterHunterBE.Repository;
using MonsterHunterBE.Service;

namespace MonsterHunterBE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<MonsterService>(); // Register MonsterService
            builder.Services.AddScoped<MonsterRepository>();

            builder.Services.AddScoped<MonsterDropService>();
            builder.Services.AddScoped<MonsterDropRepository>();

            builder.Services.AddScoped<MonsterWeaknessService>();
            builder.Services.AddScoped<MonsterWeaknessRepository>();


            builder.Services.AddDbContext<MonsterHunterContex>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MHConnectionDB")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}