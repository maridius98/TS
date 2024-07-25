public class Recipe
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string ImageURL { get; set; }
    public string Description { get; set; } = "";
    public string[] Category { get; set; } = [];
    public required string CookingType { get; set; }
    public required string Budget { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; } = [];
    public required Cuisine Cuisine { get; set; }
    public required Chef Chef { get; set; }
    public ICollection<BaseUser> LikedBy { get; set; } = [];
}