using Exo.WebApi.Context;
using Exo.WebApi.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ProjectContext, ProjectContext>();
builder.Services.AddTransient<ProjectRepository, ProjectRepository>();
builder.Services.AddTransient<UserRepository, UserRepository>();
builder.Services.AddControllers();

builder.Services.AddCors(Options =>
{
    Options.AddPolicy("CorsPolicy", builder => 
    {
        builder.WithOrigins("http://localhost:7102")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {

        ValidateIssuer = true,

        ValidateAudience = true,

        ValidateLifetime = true,

        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("project-key-authentication")),

        ClockSkew = TimeSpan.FromMinutes(30),

        ValidIssuer = "Exo.WebApi",

        ValidAudience = "Exo.WebApi"
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();

app.UseCors("CorsPolicy");

