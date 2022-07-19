using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));
// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");
app.UseAuthorization();
//app.Use(async (context, next) =>
//{
//    Console.WriteLine($"Logic before executing the next delegate in the Use method \n");
//    await context.Response.WriteAsync("Hello from the middleware component.");
//    await next.Invoke();
//    Console.WriteLine($"Logic after executing the next delegate in the Use method \n");
//});
//app.Map("/usingmapbranch", builder =>
//{
//    builder.Use(async (context, next) =>
//    {
//        Console.WriteLine(@"Map branch logic in the Use method before the next
//        delegate");
//        await next.Invoke();
//        Console.WriteLine(@"Map branch logic in the Use method after the next
//        delegate");
//    });
//    builder.Run(async context =>
//    {
//        Console.WriteLine($"Map branch response to the client in the Run method");
//        await context.Response.WriteAsync("Hello from the map branch.");
//    });
//});
//app.MapWhen(context => context.Request.Query.ContainsKey("testquerystring"), builder
//=>
//{
//    builder.Run(async context =>
//    {
//        await context.Response.WriteAsync("Hello from the MapWhen branch.");
//    });
//});
//app.Run(async context =>
//{
//    Console.WriteLine($"Writing the response to the client in the Run method \n");
//  //  context.Response.StatusCode = 200;
//    await context.Response.WriteAsync("Hello from the middleware component. \n");
//});
app.MapControllers();

app.Run();

