using cvManagement.DataAccessLayer;
using cvManagement.Models;
using System.Linq;
using System.Web.Mvc;
namespace cvManagement.Controllers
{
    public class userProfileController : Controller
    {
        /// <summary>
        /// Hien thi man hinh insert Profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult InsertUserProfile()
        {
            return View();
        }

        /// <summary>
        /// Insert Profile
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InsertUserProfile(userProfile pro)
        {
            if (ModelState.IsValid)
            {
                UserProfileLayer upl = new UserProfileLayer();
                string result = upl.InsertData(pro);
                TempData["result1"] = result;
                ModelState.Clear();

                return RedirectToAction("ListUserProfile");
            }

            else
            {
                ModelState.AddModelError("", "Error in saving data");

                return View();
            }
        }

        /// <summary>
        /// Hien thi man hinh List Profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListUserProfile()
        {
            userProfile pro = new userProfile();
            UserProfileLayer objDB = new UserProfileLayer();
            pro.ListProfile = objDB.Selectalldata();

            return View(pro);
        }

        /// <summary>
        /// Search Profile by Name
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SearchProfileByName(string ID)
        {
            UserProfileLayer upl = new UserProfileLayer();
            userProfile pro = new userProfile
            {
                ListProfile = upl.SearchProfileByName(ID)
            };

            return View(pro);
        }
    }
}
