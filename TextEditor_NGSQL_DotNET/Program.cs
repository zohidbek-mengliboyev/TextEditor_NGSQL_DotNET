using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TextEditor_NGSQL_DotNET.Context;
using TextEditor_NGSQL_DotNET.Extensions;
using TextEditor_NGSQL_DotNET.Helper;
using TextEditor_NGSQL_DotNET.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TxtEditorDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TextEditorWithDotNET"));
});

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TextEditor_NGSQL_DotNET", Version = "v1" });
});

builder.Services.AddHttpContextAccessor();

//Mapper servces
builder.Services.AddAutoMapper(typeof(MappingProfile));

//custom services
builder.Services.AddCustomServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TextEditor_NGSQL_DotNET v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
