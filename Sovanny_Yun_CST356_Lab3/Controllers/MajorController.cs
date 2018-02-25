using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sovanny_Yun_CST356_Lab3.Data;
using Sovanny_Yun_CST356_Lab3.Data.Entities;
using Sovanny_Yun_CST356_Lab3.Models.View;
using Sovanny_Yun_CST356_Lab3.Services;

namespace Sovanny_Yun_CST356_Lab3.Controllers
{
    public class MajorController : Controller
    {
        private readonly IMajorService _majorService;
        public MajorController(IMajorService majorserv)
        {
            _majorService = majorserv;
        }
        // GET: Major
        public ActionResult Index(int userId)
        {
            ViewBag.UserId = userId;                // Pass-in all id for each user
            var majors = GetMajorsForUser(userId);

            return View(majors);
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(MajorViewModel majorViewModel)
        {
            if (ModelState.IsValid)
            {
                _majorService.Create(majorViewModel);
                return RedirectToAction("Index", new { UserId = majorViewModel.UserId });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var major = _majorService.GetMajor(id);

            return View(major);
        }

        [HttpPost]
        public ActionResult Edit(MajorViewModel majorViewModel)
        {
            if (ModelState.IsValid)
            {
                _majorService.Edit(majorViewModel);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {

            var userId = _majorService.DeleteMajor(id);


            return RedirectToAction("Index", new { UserId = userId });
        }


        private ICollection<MajorViewModel> GetMajorsForUser(int userId)
        {
            var majorViewModels = new List<MajorViewModel>();

            var majors = _majorService.GetAllMajors().Where(major => major.UserId == userId).ToList();

            foreach (var major in majors)
            {
                majorViewModels.Add(major);
            }
            return majorViewModels;
        }
    }
}