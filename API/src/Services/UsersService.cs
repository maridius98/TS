using Microsoft.EntityFrameworkCore;

public class UserService
{
    private readonly MyDbContext _context;

    public UserService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<BaseUser> Create(CreateUserDto dto)
    {
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
        {
            throw new Exception("Email already in use");
        }
        if (await _context.Users.AnyAsync(u => u.Name == dto.Name))
        {
            throw new Exception("Name already in use");
        }

        BaseUser user;
        if (dto.IsChef)
        {
            user = new Chef 
            { 
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
            };
        }
        else
        {
            user = new User 
            { 
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
            };       
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<int> RecipeAdd(int chefId, int recipeId)
    {
        var chef = await _context.FindAsync<Chef>(chefId, false, false);
        if (chef != null) {
            var updatedChef = chef.Recipes.Append(await _context.FindAsync<Recipe>(recipeId, false, false));
            _context.Update(updatedChef);
            return 204;
        }
        return 400;
    }

    public async Task<int> LikeRecipe(int userId, int recipeId)
    {
        var user = await _context.FindAsync<User>(userId, false, false);
        if (user != null) {
            var updatedUser = user.Liked.Append(await _context.FindAsync<Recipe>(recipeId, false, false));
            _context.Update(updatedUser);
            return 204;
        }
        return 400;
    }
    

    // Other methods...
}