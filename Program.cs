using Microsoft.EntityFrameworkCore;
using PrimeAutoMobiles_API.Data;
using PrimeAutoMobiles_API.Services;
namespace PrimeAutoMobiles_API

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
           builder.Services.AddScoped<VehicleService>();
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<ServiceRecordService>();
            builder.Services.AddScoped<ServiceAdvisorService>();
            builder.Services.AddScoped<WorkItemService>();
            builder.Services.AddScoped<BillOfMaterialService>();
            builder.Services.AddScoped<UserService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //configure DbContext here:
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

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
