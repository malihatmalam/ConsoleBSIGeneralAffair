using BSIGeneralAffair.API.BLL;
using BSIGeneralAffair.API.BLL.DTOs.Validation;
using BSIGeneralAffair.API.BLL.Interfaces;
using BSIGeneralAffair.API.Data;
using BSIGeneralAffair.API.Data.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestAPIBSIGeneralAffair.Helpers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// add jwt to Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestAPIBSIGeneralAffair", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
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
            new string[] { }
        }
    });
});

// Database Connection appdbcontext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString"));
});
// END Database Connection appdbcontext

// DI
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<IProposalData, ProposalData>();
builder.Services.AddScoped<IProposalBLL, ProposalBLL>();
builder.Services.AddScoped<IAssetData, AssetData>();
builder.Services.AddScoped<IAssetBLL, AssetBLL>();
builder.Services.AddScoped<IApprovalData, ApprovalData>();
builder.Services.AddScoped<IApprovalBLL, ApprovalBLL>();
builder.Services.AddScoped<IHomepageData, HomepageData>();
builder.Services.AddScoped<IHomepageBLL, HomepageBLL>();
// END DI

// automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddValidatorsFromAssemblyContaining<ProposalCreateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<ProposalUpdateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<ApprovalCreateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginValidation>();
// END automapper

// JWT Authentication
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
// END JWT Authentication

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
