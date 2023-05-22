namespace GlassDetroitMVC.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string? Total { get; set; }

        public string? Date { get; set; }

        public string? Description { get; set; }

        public Person Person { get; set; } = null!;

        public SubOrder SubOrders { get; set; }


    }
}