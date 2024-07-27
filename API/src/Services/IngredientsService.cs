using Microsoft.EntityFrameworkCore;

public class IngredientsService
{
    private readonly MyDbContext _context;

    public IngredientsService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<Ingredient> Create(IngredientDTO dto)
    {
        if (await _context.Ingredients.AnyAsync(x => x.Name == dto.Name))
        {
            throw new Exception("Ingredient already exists");
        }
        
        Ingredient ingredient = new Ingredient
        {
            Name = dto.Name,
            Category = dto.Category,
            Budget = dto.Budget,
        };
        return ingredient;
    }
} 