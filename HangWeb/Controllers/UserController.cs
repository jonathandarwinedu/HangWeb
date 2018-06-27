using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HangWeb.Models;
using HangWeb.Service;

namespace HangWeb.Controllers
{
    public class UserController : Controller
    {        
       
        public ActionResult _LogIn()
        {
            return PartialView("_LogInModal");
        }

        [HttpPost]
        public ActionResult doLogin(UserLogIn userLogIn)
        {
            if (ModelState.IsValid == true)
            {
                User result = new UserService().getLogIn(userLogIn);

                if (result.Name != null)
                {
                    Session["User"] = result.Name;
                    Session["Role"] = result.Role;
                    Session["IDUser"] = result.IDUser;
                    Session["Point"] = result.Point;

                    if (result.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    return Redirect("/Home/Index?success");
                }
            }
            
            return Redirect("/Home/Index?failed");

        }

        public ActionResult _Register()
        {
            return PartialView("_RegisterModal");
        }

        [HttpPost]
        public ActionResult doRegister(User user, string confirmPassword)
        {
            if (ModelState.IsValid == true)
            {
                List<User> users = new UserService().getAllUser();
                if(users.Exists(model => model.Username == user.Username))
                {
                    return Redirect("/Home/Index?exists");
                }

                if (user.Password == confirmPassword)
                {
                    // MASUK KE SERVICE
                    bool result = new UserService().InsertRegister(user);
                    if(result == true)
                    {
                        return Redirect("/Home/Index?regisSuccess");
                    }
                    else
                    {
                        return Redirect("/Home/Index?regisFailed");
                    }
                    
                }else
                {
                    return Redirect("/Home/Index?p");
                }
                
            }
            else
            {
                return Redirect("/Home/Index/user?m");
            }            
        }

        public ActionResult LogOut()
        {
            Session.Remove("User");
            Session.Remove("Role");
            Session.Remove("IDUser");
            Session.Remove("Point");
            return RedirectToAction("Index", "Home");
        }
    }
}