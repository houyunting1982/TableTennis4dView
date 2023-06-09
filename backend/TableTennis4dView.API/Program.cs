using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using TableTennis4dView.Application.Commands.User.Create;
using TableTennis4dView.Application.Common.Interfaces;
using TableTennis4dView.Application.Mapper;
using TableTennis4dView.Infrastructure;
using TableTennis4dView.Infrastructure.Data;
using TableTennis4dView.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// For authentication
var _key = builder.Configuration["Jwt:Key"];
var _issuer = builder.Configuration["Jwt:Issuer"];
var _audience = builder.Configuration["Jwt:Audience"];
var _expirtyMinutes = builder.Configuration["Jwt:ExpiryMinutes"];


// Configuration for token
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = _audience,
        ValidIssuer = _issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
        ClockSkew = TimeSpan.FromMinutes(Convert.ToDouble(_expirtyMinutes))

    };
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Dependency injection with key
builder.Services.AddSingleton<ITokenGenerator>(new TokenGenerator(_key, _issuer, _audience, _expirtyMinutes));


// Include Infrastructur Dependency
builder.Services.AddInfrastructure(builder.Configuration);



// Configuration for Sqlite
//builder.Services.AddDbContext<AppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register dependencies
builder.Services.AddMediatR(typeof(CreateUserCommandHandler).GetTypeInfo().Assembly);



builder.Services.AddCors(c =>
{
    c.AddPolicy("CorsPolicy", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{

    // To enable authorization using swagger (Jwt)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer {token}\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
                {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}

                    }
                });

});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<TableTennis4dViewAppContext>();
    context.Database.EnsureCreated();
    //context.Database.Migrate();
}

//app.UseHttpsRedirection();

// Must be betwwen app.UseRouting() and app.UseEndPoints()
// maintain middleware order

app.UseCors("CorsPolicy");

// Added for authentication
// Maintain middleware order
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
