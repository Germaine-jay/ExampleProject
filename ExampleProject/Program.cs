using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = MicrosoftAccountDefaults.AuthenticationScheme;
})
      .AddCookie()
  .AddMicrosoftAccount(option =>
  {
      //IConfigurationSection microsoftAuthNSection = builder.Configuration.GetSection("Authentication:Microsoft");
      option.ClientSecret = "XSC8Q~lQWoLkM7NbfLYifVym59QbZZuKdbdMhbzw";
      option.ClientId = "171bc807-00c0-4dc1-af87-af462a27c4f1";
      option.CallbackPath = "/api/ExternalLogin/microsoft-callback";
      //option.SignInScheme = MicrosoftAccountDefaults.AuthenticationScheme;
      //option.AuthorizationEndpoint = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize";
  }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseForwardedHeaders();
app.UseAuthorization();
app.UseRouting();
app.UseCors();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.MapControllers();

app.Run();
