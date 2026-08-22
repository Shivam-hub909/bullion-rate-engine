using BullionRateEngine.Hubs;
using BullionRateEngine.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSignalR(); 
builder.Services.AddHostedService<GoldPriceBackgroundService>(); 

builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", policy => policy
        .WithOrigins("http://localhost:5173") 
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

var app = builder.Build();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();
app.MapHub<RateHub>("/rateHub"); 
app.Run();
