public class BaseUser
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
}

public class User : BaseUser
{
    public ICollection<Recipe> Liked { get; set; } = [];
}

public class Chef : BaseUser
{
    public ICollection<Recipe> Recipes { get; set; } = [];
}