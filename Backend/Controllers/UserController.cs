﻿namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController(GDCDbContext context) : ControllerBase, IUserController
{
    private readonly GDCDbContext _context = context;

    [HttpGet]
    public async Task<ActionResult> GetUsersAsync()
    {
        var users = await _context.User.ToListAsync();

        return Ok(users);
    }

    [HttpGet]
    public async Task<ActionResult> GetUserAsync(string id)
    {
        var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);

        return Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult> GetShortUsersAsync()
    {
        var users = await _context.User.Select(x => new ShortUser(x.Id, x.Username)).ToListAsync();

        return Ok(users);
    }

    [HttpPost]
    public async Task<ActionResult> AddUserAsync(User user)
    {
        if(user is null) return BadRequest("Where is the User?");
        var dbUser = await _context.User.FirstOrDefaultAsync(x=> x.Id == user.Id);

        if (dbUser is not null) return BadRequest();
        
        await _context.User.AddAsync(user);
        await _context.SaveChangesAsync();

        return Ok(user);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUserAsync(User user)
    {
        if (user is null) return BadRequest("Where is the User?");
        
        var dbUser = await _context.User.FirstOrDefaultAsync(x => x.Id == user.Id);
        
        if (dbUser is null) return BadRequest();

        // Update User
        dbUser.Username = user.Username;
        dbUser.Banner = user.Banner;
        dbUser.Avatar = user.Avatar;
        dbUser.AccountType = user.AccountType;
        dbUser.Email = user.Email;
        dbUser.XUrl = user.XUrl;
        dbUser.DiscordUrl = user.DiscordUrl;
        dbUser.WebsiteUrl = user.WebsiteUrl;

        await _context.SaveChangesAsync();

        return Ok(user);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUserAsync(string userId)
    {
        var dbUser = await _context.User.FirstOrDefaultAsync(x => x.Id == userId);

        if (dbUser is null) return BadRequest();

        _context.User.Remove(dbUser);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
