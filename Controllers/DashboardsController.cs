using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using AspnetCoreMvcFull.Services;

namespace AspnetCoreMvcFull.Controllers;

public class DashboardsController : Controller
{
  private readonly UserService _userService;

  public DashboardsController(UserService userService)
  {
    _userService = userService;
  }

  public IActionResult Index()
  {
    var Users = _userService.GetAllUsers();
    return View(Users);
  }

  [HttpGet]
  public IActionResult IndexWithStatus(bool success, string message)
  {
    if (success)
      TempData["SuccessMessage"] = message;
    else
      TempData["ErrorMessage"] = message;
    return RedirectToAction("Index");
  }

  [HttpPost]
  public async Task<IActionResult> EditUserName(int id, string name)
  {
    if (await _userService.UpdateUserNameAsync(id, name))
    {
      TempData["SuccessMessage"] = "User name updated successfully!";
    }
    else
    {
      TempData["ErrorMessage"] = "Error updating user name.";
    }
    return RedirectToAction("Index");
  }

  [HttpPost]
  public IActionResult DeleteUser(int id)
  {
    bool result = _userService.DeleteUser(id);

    if (result)
    {
      TempData["SuccessMessage"] = "User deleted successfully!";
    }
    else
    {
      TempData["ErrorMessage"] = "Error deleting user.";
    }

    return RedirectToAction("Index");
  }
}
