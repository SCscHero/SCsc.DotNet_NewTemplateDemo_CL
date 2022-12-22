using SCscCL_WebAPI.Model;

namespace SCscCL_WebAPI.Extension.CustomMiddlewares
{
    public static class SwaggerMildd
    {
        public static void UseSwaggerMildd(this IApplicationBuilder app, Func<Stream> streamHtml)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                typeof(ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version =>
                {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{"SCscCL_WebAPI"} {version}");
                });

                if (streamHtml.Invoke() == null)
                {
                    var msg = "index.html的属性，必须设置为嵌入的资源";
                    Console.WriteLine(msg);
                    throw new Exception(msg);
                }

                c.IndexStream = streamHtml;

                // 路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
                c.RoutePrefix = "";
            });
        }

    }
}
