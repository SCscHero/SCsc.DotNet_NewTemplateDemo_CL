
using System;
using Microsoft.OpenApi.Models;
using SCscCL_WebAPI.Model;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Runtime.InteropServices;
using SCscCL_WebAPI.Extension.CustomMiddlewares;
using SCscCL_WebAPI;

var builder = WebApplication.CreateBuilder(args);
var ApiName = "SCscCL_WebAPI";
var basePath = AppContext.BaseDirectory;



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // 遍历出全部的版本，做文档信息展示
    typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
    {
        c.SwaggerDoc(version, new OpenApiInfo
        {
            Version = version,
            Title = $"{ApiName} 接口文档——{RuntimeInformation.FrameworkDescription}",
            Description = $"{ApiName} HTTP API " + version,
            Contact = new OpenApiContact { Name = ApiName, Email = "scschero@foxmail.com" },
            //License = new OpenApiLicense { Name = ApiName + " 官方文档", Url = new Uri("") }
        });
        c.OrderActionsBy(o => o.RelativePath);
    });

    try
    {
        var xmlPath = Path.Combine(basePath, $"SCscCL_WebAPI.xml");
        c.IncludeXmlComments(xmlPath, true);
    }
    catch (Exception ex)
    {
        Console.WriteLine("xml missing!");
    }

    // 开启加权小锁
    c.OperationFilter<AddResponseHeadersFilter>();
    c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

    // 在header中添加token，传递到后台
    c.OperationFilter<SecurityRequirementsOperationFilter>();

    // Jwt Bearer 认证，必须是 oauth2
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
        Name = "Authorization",//jwt默认的参数名称
        In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
        Type = SecuritySchemeType.ApiKey
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // 将swagger首页，设置成我们自定义的页面，记得这个字符串的写法：{项目名.index.html}


    //TODO:??????????//
        //GetType().GetTypeInfo().Assembly.
    app.UseSwaggerMildd(() => new WeatherForecast().GetType().GetTypeInfo().Assembly.GetManifestResourceStream("SCscCL_WebAPI.index.html"));

}
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseStatusCodePages();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
