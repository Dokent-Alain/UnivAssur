using Microsoft.OpenApi.Models;
using System.Reflection;
using UnivAssurance.webAPI.Logging;
using NLog;
using UnivAssurance.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using UnivAssurance.webAPI.Authentification;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);// Sert à charger tous ce qui est fichier de configuration.
builder.Services.AddControllers();
builder.Services.AddDbContext<UnivAssurance.webAPI.Authentification.AuthentificationDbConext>(option =>{
    option.UseSqlServer(builder.Configuration.GetConnectionString("AuthentificationDbContext"));
});
builder.Services.AddEndpointsApiExplorer();//Les services
builder.Services.AddCors(o =>o.AddPolicy("Souscription Cors" , p =>p.WithOrigins("aaaa","junior")));
string Pathfichier = $"{Directory.GetCurrentDirectory()}./bin/Debug/net6.0/Nlog.config";
LogManager.LoadConfiguration(Pathfichier);
builder.Configuration.GetSection("CorsOrigin").Get<string>();
builder.Services.AddSingleton<Ilog ,Log>();
builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
.AddEntityFrameworkStores<AuthentificationDbConext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
.AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "http://localhost:5097" ,
                    ValidIssuer = "http://localhost:5097" ,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"))
                };
            });
//Ajout du service 
builder.Services.AddDbContext<SouscriptionDbContext>(option =>{
    option.UseSqlServer(builder.Configuration.GetConnectionString("AbonnementCs"));
});
builder.Services.AddSwaggerGen(c=>{c.SwaggerDoc("v1",new OpenApiInfo{Title = "Gestion des souscriptions", 
Version = "1.0.0" ,
 Description ="Gestion des souscriptions"});
  string nomFichier = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
 string fichierXml = Path.Combine(AppContext.BaseDirectory , nomFichier);
c.IncludeXmlComments(fichierXml);});//Chargement de la configuration en une application.C'est ce qui rend fonctionnel le fait d'utiliser les controllers.
var app = builder.Build();
 string cs = builder.Configuration.GetSection("CorsOrigin").Get<string>();
 string[] CorsOrigin = cs.Split(new char [','], StringSplitOptions.RemoveEmptyEntries);
//app.MapGet("/", () => "Hello World!");//permet de determiner une route.

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("Souscription Cors");
app.UseSwagger();
app.UseSwaggerUI(c =>{c.RoutePrefix = string.Empty;
c.SwaggerEndpoint("/Swagger/v1/Swagger.Json","v1");});

app.MapControllers();
app.Run();
//Configuration pour le deploiement
//var host = new WebHostBuilder()