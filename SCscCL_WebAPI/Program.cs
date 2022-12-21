var builder = WebApplication.CreateBuilder(args);
var ApiName = "SCscCL_WebAPI";



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
        var xmlPath = Path.Combine(basePath, $"{ApiName}.WebApi.xml");
        c.IncludeXmlComments(xmlPath, true);

        var xmlModelPath = Path.Combine(basePath, $"{ApiName}.Models.xml");
        c.IncludeXmlComments(xmlModelPath);

        var xmlEntityPath = Path.Combine(basePath, $"{ApiName}.Entities.xml");
        c.IncludeXmlComments(xmlEntityPath);
    }
    catch (Exception ex)
    {
        log.Error("xml 丢失，请检查并拷贝。\n" + ex.Message);
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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
