var builder = WebApplication.CreateBuilder(args);
var ApiName = "SCscCL_WebAPI";



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // ������ȫ���İ汾�����ĵ���Ϣչʾ
    typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
    {
        c.SwaggerDoc(version, new OpenApiInfo
        {
            Version = version,
            Title = $"{ApiName} �ӿ��ĵ�����{RuntimeInformation.FrameworkDescription}",
            Description = $"{ApiName} HTTP API " + version,
            Contact = new OpenApiContact { Name = ApiName, Email = "scschero@foxmail.com" },
            //License = new OpenApiLicense { Name = ApiName + " �ٷ��ĵ�", Url = new Uri("") }
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
        log.Error("xml ��ʧ�����鲢������\n" + ex.Message);
    }

    // ������ȨС��
    c.OperationFilter<AddResponseHeadersFilter>();
    c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

    // ��header�����token�����ݵ���̨
    c.OperationFilter<SecurityRequirementsOperationFilter>();

    // Jwt Bearer ��֤�������� oauth2
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
        Name = "Authorization",//jwtĬ�ϵĲ�������
        In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
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
