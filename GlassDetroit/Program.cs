using Microsoft.AspNetCore.Mvc;
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
            stringBuilder.Append($"" +
                $"<tr><td>{item.Id}</td>" +
                $"<tr><td>{item.FirstName}</td>" +
                $"<tr><td>{item.LastName}</td>" +
                $"<tr><td>{item.Phone}</td>" +
                $"<tr><td>{item.Title}</td>" +
                $"<tr><td>{item.Size}</td>" +
                $"<tr><td>{item.Price}</td>" +
                $"<tr><td>{item.Quantity}</td>" +
                $"<tr><td>{item.Total}</td>" +
                $"<tr><td>{item.Date}</td>" +
                $"<tr><td>{item.Description}</td>");
        }
    }
    stringBuilder.Append("</table>");
    await context.Response.WriteAsync(stringBuilder.ToString());   
});


app.MapPost("/item", async (HttpContext context) =>
{
    var item = new Item
    {
        Id = Int32.Parse(context.Request.Form["id"]),
        FirstName = context.Request.Form["FirstName"],
        LastName = context.Request.Form["LastName"],
        Phone = context.Request.Form["Phone"],
        Title = context.Request.Form["Title"],
        Size = context.Request.Form["Size"],
        Price = context.Request.Form["Price"],
        Quantity = context.Request.Form["Quantity"],
        Total = context.Request.Form["Total"],
        Date = context.Request.Form["Date"],
        Description = context.Request.Form["Description"]
      };
    using (var cnt = new Context())
    {
        cnt.Items.Add(item);
        cnt.SaveChanges();
    }
    return "OK";
});

app.Run();
