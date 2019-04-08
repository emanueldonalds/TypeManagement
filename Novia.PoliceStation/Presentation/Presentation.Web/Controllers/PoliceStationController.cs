using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novia.PoliceStationManagement.Application.Abstractions;
using Novia.PoliceStationManagement.Application.Abstractions.Dtos;

namespace Novia.PoliceStationManagement.Presentation.Web.Controllers
{
    public class PoliceStationController : Controller
    {
        private IPoliceStationManagement mPoliceStationManagement;

        public PoliceStationController(IPoliceStationManagement PoliceStationManagement)
        {
            mPoliceStationManagement = PoliceStationManagement;
        }

        // GET: PoliceStation
        public IActionResult Index()
        {
            var thePoliceStations = mPoliceStationManagement.ListAll();
            return View(thePoliceStations);
        }

        // GET: PoliceStation/Details/5
        public ActionResult Details(int id)
        {
            var thePoliceStation = mPoliceStationManagement.FindById(id);
            return View(thePoliceStation);
        }

        // GET: PoliceStation/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PoliceStation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(PoliceStationDto newPoliceStationDto)
        {
            try
            {
                mPoliceStationManagement.Add(
                    newPoliceStationDto.Name,
                    newPoliceStationDto.Address,
                    newPoliceStationDto.Workers,
                    newPoliceStationDto.Chief
                    );
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PoliceStation/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            PoliceStationDto thePoliceStationDto = mPoliceStationManagement.FindById(id);
            return View(thePoliceStationDto);
        }

        // POST: PoliceStation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(PoliceStationDto thePoliceStationToEditDto)
        {
            try
            {
                mPoliceStationManagement.Modify(thePoliceStationToEditDto);
                // I want to return the user to the details page instead of the list page
                return RedirectToAction(nameof(Details), thePoliceStationToEditDto);
            }
            catch
            {
                return View();
            }
        }

        // GET: PoliceStation/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            PoliceStationDto thePoliceStationDto = mPoliceStationManagement.FindById(id);
            return View(thePoliceStationDto);
        }

        // POST: PoliceStation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(PoliceStationDto thePoliceStationToDeleteDto)
        {
            try
            {
                mPoliceStationManagement.Remove(thePoliceStationToDeleteDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}