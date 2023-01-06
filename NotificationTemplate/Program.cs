using NotificationTemplateDBAccess;
using NotificationTemplateServices;

var builder = WebApplication.CreateBuilder(args);

//This service is for NotificationTemplateDBAccess Library
builder.Services.ConfigNotificationTemplateDBAccess();

//This service is for NotificationTemplateService Library
builder.Services.ConfigNotificationTemplateService();

builder.Services.AddControllers();
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

app.MapControllers();

app.Run();
