﻿namespace StructuralDesign.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using StructuralDesign.Data;
    using StructuralDesign.Web.ViewModels;
    using System.Linq;
    using StructuralDesign.Web.ViewModels.Home;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Data;
    using System;
    using Microsoft.AspNetCore.Hosting;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService countsService;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(IGetCountsService countsService,
            IWebHostEnvironment hostingEnvironment)
        {
            this.countsService = countsService;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            Debug.WriteLine(hostingEnvironment.EnvironmentName);
            var countsDto = this.countsService.GetCounts();
            var viewModel = new IndexViewModel
            {
                CountOfBooks = countsDto.CountOfBooks,
                CountOfCategories = countsDto.CountOfCategories,
                CountOfProjects = countsDto.CountOfProjects,
                CountOfRegistratedUsers = countsDto.CountOfRegistratedUsers,
                CountOfSections = countsDto.CountOfSections,
            };

            return this.View(viewModel);
        }

        public IActionResult DataDemo(int id, string name, DateTime time)
        {
            return this.Json(new { id, name, time });
        }
        public IActionResult AJAXDemo()
        {
            return this.View();
        }

        public IActionResult AjaxDemoData()
        {
            return this.Json(new[]
            {
                new { Name= "Niki2", Date = DateTime.UtcNow.ToString("O") },
                new { Name = "Mit", Date = DateTime.UtcNow.AddDays(1).ToString("O")},
                new { Name = "Mit2", Date = DateTime.UtcNow.AddDays(2).ToString("O")},
            });
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
