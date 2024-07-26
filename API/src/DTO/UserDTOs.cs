public class CreateUserDto 
{
    public int Id { get; set;}
    public required string Name { get; set;}
    public required string Email { get; set;}
    public required string Password { get; set; }
    public bool IsChef { get; set; } = false;
}