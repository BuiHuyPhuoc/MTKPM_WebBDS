using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using webbds.Class;
using webbds.Models;
using System.Linq.Dynamic.Core;
namespace webbds.Controllers
{
    public class SearchController : Controller
    {
        private BDS_TestEntities db = new BDS_TestEntities();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchProject(string keyWord, string area)
        {
            string[] token = area.Split('-');
            Nullable<double> minArea;
            Nullable<double> maxArea;
            if (area == "null" || area == "")
            {
                minArea = null;
                maxArea = null;
            } else
            {
                minArea = Convert.ToDouble(token[0]);
                maxArea = Convert.ToDouble(token[1]);
            }
            var nameSpec = new NameSpecification(keyWord);
            var areaSpec = new AreaSpecification(minArea, maxArea);

            var combinedSpec = nameSpec & areaSpec;
            var projects = db.BatDongSans.Where(combinedSpec.ToExpression()).ToList();
            if (projects.Count == 0)
            {
                // Xử lý khi không tìm thấy dự án
                ViewBag.Message = "Không tìm thấy dự án phù hợp";
                return View("NotFound"); // Tạo view "NotFound" để hiển thị thông báo không tìm thấy dự án
            }
            else
            {
                return View(projects);
            }
        }
    }
}