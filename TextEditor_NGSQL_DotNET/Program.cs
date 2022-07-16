using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TextEditor_NGSQL_DotNET.Context;
using TextEditor_NGSQL_DotNET.Extensions;
using TextEditor_NGSQL_DotNET.Helper;
using TextEditor_NGSQL_DotNET.Mapper;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TxtEditorDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
      builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); });
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

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TextEditor_NGSQL_DotNET v1"));
}

if (app.Services.GetService<IHttpContextAccessor>() != null)
{
    HttpContextHelper.Accessor = app.Services.GetRequiredService<IHttpContextAccessor>();
}

app.UseCors(x => x
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
