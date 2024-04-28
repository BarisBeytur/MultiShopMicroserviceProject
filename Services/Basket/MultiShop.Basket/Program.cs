using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;
using MultiShop.Basket.Settings;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// kullanicinin zorunlu olmasi gerektigi durumlar icin policy olusturuldu
var requireAuthorizePolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

// Sub claim'in maplemesi silindi sub'a kolay erisebilmek icin.
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["IdentityServerUrl"];
        options.Audience = "BasketResource";
        options.RequireHttpsMetadata = false;
    });


builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IBasketService, BasketService>();

// RedisSettings appsettings.json dosyasindan aliniyor
builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));

// RedisService singleton olarak ekleniyor
builder.Services.AddSingleton<RedisService>(sp =>
{
    // RedisService icin gerekli ayarlar aliniyor
    var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
    // RedisService olusturuluyor ve baglanti saglaniyor
    var redis = new RedisService(redisSettings.Host, redisSettings.Port);
    redis.Connect();
    return redis;
});


// zorunlu olmasi gereken policy eklendi
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
