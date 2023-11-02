using FlowerSpot.Api.Modules;
using FlowerSpot.Api.Modules.Swagger;
using FlowerSpot.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContextModule(configuration);
services.AddIdentityModule(configuration);
services.AddServicesModule();
services.AddAutoMapperModule();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerModule();

var app = builder.Build();
using (var scope =
  app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<FlowerSpotDbContext>())
    context!.Database.Migrate();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flowers API"); });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();