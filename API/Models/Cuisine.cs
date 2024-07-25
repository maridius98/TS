public class Cuisine
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = "";
    public ICollection<Recipe> Recipes { get; set; } = [];
}