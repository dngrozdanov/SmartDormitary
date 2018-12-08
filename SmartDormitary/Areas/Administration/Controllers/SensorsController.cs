﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartDormitary.Areas.Administration.Models;
using SmartDormitary.Data.Models;
using SmartDormitary.Services.Contracts;

namespace SmartDormitary.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Administration")]
    public class SensorsController : Controller
    {
        private readonly ISensorsService sensorsService;
        private readonly ISensorTypesService sensorTypesService;
        private readonly IUsersService usersService;

        public SensorsController(IUsersService usersService, ISensorsService sensorsService,
            ISensorTypesService sensorTypesService)
        {
            this.usersService = usersService;
            this.sensorsService = sensorsService;
            this.sensorTypesService = sensorTypesService;
        }

        [TempData] public string StatusMessage { get; set; }

        // GET: Administration/Sensors
        public async Task<IActionResult> Index()
        {
            var sensorsInclude = await sensorsService.GetAllSensorsAsync();
            return View(sensorsInclude);
        }

        // GET: Administration/Sensors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var sensor = await sensorsService.GetSensorByGuidAsync(id);
            if (sensor == null) return NotFound();

            var sensorView = new SensorViewModel(sensor);
            return View(sensorView);
        }

        // GET: Administration/Sensors/Create
        public async Task<IActionResult> Create()
        {
            ViewData["SensorTypes"] =
                new SelectList(await sensorTypesService.GetAllSensorTypesAsync(), "Id", "Description");
            ViewData["Users"] = new SelectList(await usersService.GetAllUsersAsync(), "Id", "UserName");
            return View();
        }

        // POST: Administration/Sensors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SensorViewModel sensor)
        {
            if (ModelState.IsValid)
            {
                var newModel = new Sensor
                {
                    Id = Guid.NewGuid(),
                    Name = sensor.Name,
                    Description = sensor.Description,
                    RefreshTime = sensor.RefreshTime,
                    IsPublic = sensor.IsPublic,
                    CreatedOn = DateTime.Now,
                    Latitude = sensor.Latitude,
                    Longitude = sensor.Longitude,
                    MinAcceptableValue = sensor.MinAcceptableValue,
                    MaxAcceptableValue = sensor.MaxAcceptableValue,
                    TickOff = sensor.TickOff,
                    SensorTypeId = sensor.SensorTypeId,
                    UserId = sensor.UserId
                };

                await sensorsService.RegisterSensorAsync(newModel);
                StatusMessage = "Successfully saved the changes.";
                return RedirectToAction(nameof(Details), new {id = newModel.Id});
            }

            ViewData["SensorTypes"] = new SelectList(await sensorTypesService.GetAllSensorTypesAsync(), "Id",
                "Description", sensor.SensorTypeId);
            ViewData["Users"] = new SelectList(await usersService.GetAllUsersAsync(), "Id", "UserName", sensor.UserId);
            StatusMessage = "Error: Something went wrong...";
            return View(sensor);
        }

        // GET: Administration/Sensors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var sensor = await sensorsService.GetSensorByGuidAsync(id);
            if (sensor == null) return NotFound();

            ViewData["SensorTypes"] = new SelectList(await sensorTypesService.GetAllSensorTypesAsync(), "Id",
                "Description", sensor.SensorTypeId);
            ViewData["Users"] = new SelectList(await usersService.GetAllUsersAsync(), "Id", "UserName", sensor.UserId);
            var sensorView = new SensorViewModel(sensor);
            return View(sensorView);
        }

        // POST: Administration/Sensors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SensorViewModel sensor)
        {
            if (id != sensor.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var newModel = new Sensor
                    {
                        Id = sensor.Id,
                        Name = sensor.Name,
                        Description = sensor.Description,
                        RefreshTime = sensor.RefreshTime,
                        IsPublic = sensor.IsPublic,
                        CreatedOn = sensor.CreatedOn,
                        Latitude = sensor.Latitude,
                        Longitude = sensor.Longitude,
                        //Value = sensor.Value,
                        MinAcceptableValue = sensor.MinAcceptableValue,
                        MaxAcceptableValue = sensor.MaxAcceptableValue,
                        TickOff = sensor.TickOff,
                        SensorTypeId = sensor.SensorTypeId,
                        UserId = sensor.UserId
                    };

                    await sensorsService.UpdateSensorAsync(newModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await sensorsService.SensorExists(sensor.Id) == false)
                        return NotFound();
                    throw;
                }

                StatusMessage = "Successfully saved the changes.";
                return RedirectToAction(nameof(Edit), new {id});
            }

            ViewData["SensorTypes"] = new SelectList(await sensorTypesService.GetAllSensorTypesAsync(), "Id",
                "Description", sensor.SensorTypeId);
            ViewData["Users"] = new SelectList(await usersService.GetAllUsersAsync(), "Id", "UserName", sensor.UserId);
            StatusMessage = "Error: Something went wrong...";
            return View(sensor);
        }

        // GET: Administration/Sensors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var sensor = await sensorsService.GetSensorByGuidAsync(id);
            if (sensor == null) return NotFound();

            var sensorView = new SensorViewModel(sensor);
            return View(sensorView);
        }

        // POST: Administration/Sensors/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await sensorsService.DeleteSensorsAsync(id);
            StatusMessage = "Successfully deleted the sensor.";
            return RedirectToAction(nameof(Index));
        }
    }
}