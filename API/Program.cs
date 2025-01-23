using System.Text.Json.Serialization;
using Application.Commands;
using Application.DTOs;
using Application.Handlers;
using Application.Services;
using ArchitectureTestApp.Middleware;
using Domain.Exceptions;
using Domain.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence.DbContext;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<CreateCompanyCommand>, CreateCompanyValidator>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList(); // Gather all error messages

        var firstMessage = errors.FirstOrDefault() ?? "One or more validation errors occurred."; 
        var errorDTO = new ErrorResponseDTO(firstMessage, ErrorCode.INVALID_PAYLOAD, null);

        return new BadRequestObjectResult(errorDTO);
    };
});



//DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<DbContext, ApplicationDbContext>();

//Services
builder.Services.AddScoped<CompanyService>();

//Repos
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

//MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCompanyCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCompanyQueryHandler).Assembly));



var app = builder.Build();


app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection(); //If this is used, it should be before Routing and Authorization
app.UseRouting();
app.UseAuthorization();
app.MapControllers();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    //Enable Migration for DB testing
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var pendingMigrations = dbContext.Database.GetPendingMigrations();
    
        if (pendingMigrations.Any())
        {
            dbContext.Database.Migrate();
        }
    }

}

app.Run();

