using FluentValidation.AspNetCore;
using JiraApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using JiraApi.Validators;
using ToDoCosmos.BusinessLogic.Implementation;
using ToDoCosmos.BusinessLogic.Interfaces;
using ToDoCosmos.Infrastructure.Authentication;
using ToDoCosmos.Infrastructure;
using FluentValidation.Internal;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<CreateUserStoryDTOValidator>());


builder.Services.AddEndpointsApiExplorer();

 builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
}); 

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

//var cosmosConnectionString = builder.Configuration.GetConnectionString("AccountEndpoint=https://to-to-app.documents.azure.com:443/;AccountKey=2WC08KkMPPBoMgVUBkp4KWwTIGwlEokDbIEOR7T40DgCXk1nAzPHmY2hSmSiqcjzeVAFRK5wmmKsACDbWXq9qg==;");
var cosmosConnectionString = "AccountEndpoint = https://to-to-app.documents.azure.com:443/;AccountKey=2WC08KkMPPBoMgVUBkp4KWwTIGwlEokDbIEOR7T40DgCXk1nAzPHmY2hSmSiqcjzeVAFRK5wmmKsACDbWXq9qg==;";
builder.Services.AddDbContext<JiraContext>(opt => opt.UseCosmos(cosmosConnectionString,  "ToDoAPI"));

builder.Services.AddScoped<IUStoryService, UserStoryService>();
builder.Services.AddScoped<IUStoryRepository, JiraUStoryRepository>();
builder.Services.AddScoped<ISubtaskService, SubtaskService>();
builder.Services.AddScoped<ISubtaskRepository, JiraSubtaskRepository>();
builder.Services.AddScoped<IUserService, ToDoCosmos.BusinessLogic.Implementation.UserService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();



/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters.ValidateAudience = false;
        options.TokenValidationParameters.ValidateIssuer = false;
        options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtToken")["Key"]));
       
    }); 

*/
  



builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();