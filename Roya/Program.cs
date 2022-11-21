using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Roya.helper;
using Roya_BLL.interFaces;
using Roya_BLL.Repositries;
using Roya_DDL.Entities;
using Roya_DDL.Entities.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RoyaContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("RoyaDb"));
});


builder.Services.AddScoped(typeof(IGenercRepositry<>), typeof(GenericRepositry<>));
builder.Services.AddAutoMapper(typeof(mappingprofile));
builder.Services.AddIdentity<User, IdentityRole>(option =>
{

}).AddEntityFrameworkStores<RoyaContext>().AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);


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
