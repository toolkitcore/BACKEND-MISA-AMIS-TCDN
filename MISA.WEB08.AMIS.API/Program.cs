using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using MISA.WEB08.AMIS;
using MISA.WEB08.AMIS.BL;
using MISA.WEB08.AMIS.DL;
using MISA.WEB08.AMIS.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v2",
        Title = "MISA.WEB08.TCDN.AMIS.API",
        Description = "Api được sử dụng để thêm sửa xóa dữ liệu nhân viên",
        Contact = new OpenApiContact
        {
            Name = "Đặng Việt Anh",
            Email = "vietdang0407@gmail.com",
            Url = new Uri("https://www.facebook.com/anhdv47"),
        },
    });
});
builder.Services.AddRouting(option => option.LowercaseUrls = true); // enforce lowercase routing

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Dependency Injection
builder.Services.AddScoped<IEmployeeBL, EmployeeBL>(); // DI EmployeeBL vào IEmployeeBL
builder.Services.AddScoped<IEmployeeDL, EmployeeDL>();// DI EmployeeDL vào IEmployeeDL

builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>)); // DI BaseDL vào IBaseDL
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>)); // DI BaseBL vào IBaseBL

DatabaseContext.ConnectionString = builder.Configuration.GetConnectionString("MySqlConnectionString");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseMiddleware(typeof(ErrorHandleMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
