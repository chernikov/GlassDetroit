using Newtonsoft.Json;

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

app.MapPost("/items", async (Item item) =>
    {
        using (var context = new Context())
        {
            context.Items.Add(item);
            context.SaveChanges();
        }
        return "OK";
    });

app.Run();
