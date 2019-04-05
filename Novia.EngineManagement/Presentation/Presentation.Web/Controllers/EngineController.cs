using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novia.EngineManagement.Application.Abstractions;
using Novia.EngineManagement.Application.Abstractions.Dtos;

namespace Novia.EngineManagement.Presentation.Web.Controllers
{
    public class EngineController : Controller
    {
        private IEngineManagement mEngineManagement;

        public EngineController(IEngineManagement EngineManagement)
        {
            mEngineManagement = EngineManagement;
        }

        // GET: Engine
        public IActionResult Index()
        {
            var theEngines = mEngineManagement.ListAll();
            return View(theEngines);
        }

        // GET: Engine/Details/5
        public ActionResult Details(int id)
        {
            var theEngine = mEngineManagement.FindById(id);
            return View(theEngine);
        }

        // GET: Engine/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Engine/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(EngineDto newEngineDto)
        {
            try
            {
                mEngineManagement.Add(
                    newEngineDto.Name,
                    newEngineDto.Volume,
                    newEngineDto.Power,
                    newEngineDto.Price
                    );
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Engine/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            EngineDto theEngineDto = mEngineManagement.FindById(id);
            return View(theEngineDto);
        }

        // POST: Engine/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(EngineDto theEngineToEditDto)
        {
            try
            {
                mEngineManagement.Modify(theEngineToEditDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Engine/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            EngineDto theEngineDto = mEngineManagement.FindById(id);
            return View(theEngineDto);
        }

        // POST: Engine/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(EngineDto theEngineToDeleteDto)
        {
            try
            {
                mEngineManagement.Remove(theEngineToDeleteDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}