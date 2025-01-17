using Microsoft.AspNetCore.Http.Features;
using MusicService.Buisness.Abstruct;
using MusicService.DataAccess.Repository;
using MusicService.Buisness.Concrete;
using MusicService.Web_API.Services.Abstruct;
using MusicService.Web_API.Services.Concrete;
using StackExchange.Redis;
using Microsoft.EntityFrameworkCore;
using MusicService.DataAccess.Data;
using IdentityService.DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:3000", "http://localhost:3001")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
});

builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = int.MaxValue;
    options.MultipartHeadersLengthLimit = int.MaxValue;
});

builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
ConnectionMultiplexer.Connect(new ConfigurationOptions
{
    EndPoints = { { "", 0 } },
    User = "",
    Password = "",

}));

builder.Services.AddScoped<IMusicDal, MusicDal>();
builder.Services.AddScoped<IRedisService, RedisService>();
builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();

//var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MusicAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
        
        );


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowReactApp");

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
