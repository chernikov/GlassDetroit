using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/items", () =>
{
    using (var context = new Context())
    {
        var list = context.Items.ToList();
        var json = JsonConvert.SerializeObject(list);
        return json;
    }
});

app.MapGet("/item", async (context) =>
    {   
        context.Response.ContentType = "text/html; charset=utf-8";        
        await context.Response.SendFileAsync("html/index.html");    
    });

app.MapGet("/home", async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    var stringBuilder = new System.Text.StringBuilder("<table>");
    using (var db = new Context())
    {
        foreach (var item in db.Items)
        {
            stringBuilder.Append($"<tr><td>{item.FirstName}</td><td>{item.LastName}</td></tr>");
        }
    }
    stringBuilder.Append("</table>");
    await context.Response.WriteAsync(stringBuilder.ToString());   
});


app.MapPost("/items", async (Item item) =>
    {
        using (var context = new Context())
        {
            context.Items.Add(item);
            context.SaveChanges();
        }
        return "OK";
    });


//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.SendFileAsync("html/index.html");
//});

app.Run();
