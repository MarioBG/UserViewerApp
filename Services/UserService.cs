using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Services
{
  public class UserService
  {
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
      _context = context;
    }

    public List<User> GetAllUsers()
    {
      return _context.Users.ToList();
    }

    public async Task<bool> UpdateUserNameAsync(int userId, string newName)
    {
      var user = await _context.Users.FindAsync(userId);
      if (user == null) return false;

      user.name = newName;
      await _context.SaveChangesAsync();
      return true;
    }

    public bool DeleteUser(int userId)
    {
      var user = _context.Users.Find(userId);
      if (user == null) return false;

      _context.Users.Remove(user);
      _context.SaveChanges();
      return true;
    }
  }
}
