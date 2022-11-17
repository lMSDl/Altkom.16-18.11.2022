namespace Models
{
    public class Child
    {
        public string? Name { get; set; }

        public int Age { get; set; }

        public string? NullableString { get; set; }
        public string DefaultString { get; set; } = "";

        public float DefaultNumber { get; set; }

        public Parent? Parent { get; set; }
    }
}