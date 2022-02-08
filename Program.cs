var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("<head><title>Http Request Details</title></head><body>");
                    await context.Response.WriteAsync("<h3>Headers</h3><table><tr><th align='left'>Id</th><th align='left'>Value</th></tr>");
                    foreach (var header in context.Request.Headers)
                    {
                        await context.Response.WriteAsync($"<tr><td>{header.Key}</td>");
                        await context.Response.WriteAsync($"<td>{header.Value}</td></tr>");
                    }
                    await context.Response.WriteAsync("</table></body>");
                });

app.Run();
