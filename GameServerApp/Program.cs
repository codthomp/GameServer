using GameServerApp.Services;
using Microsoft.EntityFrameworkCore;
using GameServerApp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using GameServerApp.Models;

var builder = WebApplication.CreateBuilder(args);
// const string corsPolicyName = "ApiCORS";

var settings = new Settings();
builder.Configuration.Bind("Settings",settings);
builder.Services.AddSingleton(settings);
builder.Services.AddDbContext<GameDbContext>();
builder.Services.AddControllers().AddNewtonsoftJson(o => {o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;});
builder.Services.AddScoped<IHeroService,MockHeroService>();
builder.Services.AddScoped<IAuthenticationService,AuthenticationService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o => {
    o.TokenValidationParameters = new TokenValidationParameters() {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.BearerKey)),
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false
    };
});
builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy( policy =>
    {
        policy.WithOrigins("http://localhost:19007","http://localhost:19001","http://localhost:19002","http://10.0.0.249").AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // app.UseHsts();
}
// app.UseHttpsRedirection();
// app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
