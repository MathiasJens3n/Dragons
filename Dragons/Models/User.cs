namespace Dragons.Models
{
    public class User
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}