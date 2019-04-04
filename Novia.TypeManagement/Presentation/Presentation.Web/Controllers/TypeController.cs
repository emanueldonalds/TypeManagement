using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novia.TypeManagement.Application.Abstractions;
using Novia.TypeManagement.Application.Abstractions.Dtos;

namespace Novia.TypeManagement.Presentation.Web.Controllers
{
    public class TypeController : Controller
    {
        private ITypeManagement mTypeManagement;

        public TypeController(ITypeManagement typeManagement)
        {
            mTypeManagement = typeManagement;
        }

        // GET: Type
        public IActionResult Index()
        {
            var theTypes = mTypeManagement.ListAll();
            return View(theTypes);
        }

        // GET: Type/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Type/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TypeDto newTypeDto)
        {
            try
            {
                mTypeManagement.Add(
                    newTypeDto.Name,
                    newTypeDto.Volume,
                    newTypeDto.Power,
                    newTypeDto.Price
                    );
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Type/Edit/5
        public ActionResult Edit(int id)
        {
            TypeDto theTypeDto = mTypeManagement.FindById(id);
            return View(theTypeDto);
        }

        // POST: Type/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TypeDto theTypeToEditDto)
        {
            try
            {
                mTypeManagement.Modify(theTypeToEditDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Type/Delete/5
        public ActionResult Delete(int id)
        {
            TypeDto theTypeDto = mTypeManagement.FindById(id);
            return View(theTypeDto);
        }

        // POST: Type/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TypeDto theTypeToDeleteDto)
        {
            try
            {
                mTypeManagement.Remove(theTypeToDeleteDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}