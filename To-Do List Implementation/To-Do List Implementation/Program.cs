using Microsoft.EntityFrameworkCore;
using To_Do_List_Implementation.Application.Interfaces;
using To_Do_List_Implementation.Application.Services;
using To_Do_List_Implementation.Data.Interfaces;
using To_Do_List_Implementation.Data.Repositories;
using To_Do_List_Implementation.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoContext>(options =>   
options.UseSqlite(builder.Configuration.GetConnectionString("TodoContext")));

#region Services
builder.Services.AddScoped<ITodoItemService, TodoItemService>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion

#region Repositories
builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion

var app = builder.Build();

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
