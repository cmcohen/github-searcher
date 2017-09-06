using GitHubSearcher.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitHubSearcher.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetUserInfo(string username)
        {
            var gh = new GitHubSearcherApi();
            var user = gh.GetUser(username);
            var repos = gh.GetUserRepos(username);
            return Json(new
            {
               name = user.Name,
               location = user.Location,
               followers = user.Followers,
               repos = repos.Select(r => new
               {
                   name = r.Name,
                   description = r.Description,
                   language = r.Language,
                   stars = r.Stars,
                   watchers = r.Watchers
               })             
            }, JsonRequestBehavior.AllowGet);
        }
    }

}