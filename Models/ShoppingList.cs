namespace Models
{
    public class ShoppingList : Entity
    {
        public DateTime DateTime { get; } = DateTime.Now;
        public string? Name { get; set; }
    }
}