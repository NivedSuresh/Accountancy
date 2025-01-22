using Application.Handlers;
using Application.Services;
using Domain.Repositories;
using Infrastructure.Persistence.DbContext;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

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

