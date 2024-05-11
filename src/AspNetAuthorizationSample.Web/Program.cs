using Microsoft.AspNetCore.Authentication.JwtBearer;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                  options.Audience = "http://host.docker.internal:5001";
                  options.Authority = "http://host.docker.internal:5002";
                  options.RequireHttpsMetadata = false;
                });
builder.Services.AddAuthorization();

WebApplication app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!")
   .RequireAuthorization();

app.Run();
