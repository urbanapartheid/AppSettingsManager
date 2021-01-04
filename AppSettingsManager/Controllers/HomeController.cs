﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppSettingsManager.Models;
using Microsoft.Extensions.Configuration;

namespace AppSettingsManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            ViewBag.SendGridKey = _config.GetValue<string>("SendGridKey");
            ViewBag.TwilioAuthToken = _config.GetValue<string>("Twilio:AuthToken");
            var test = _config.GetSection("Twilio").GetValue<string>("AuthToken");
            ViewBag.TwilioAccountSid = _config.GetValue<string>("Twilio:AccountSid");
            ViewBag.BottomLevelSetting = _config.GetValue<string>("FirstLevelSetting:SecondLevelSetting:BottomLevelSetting");
            var test2 = _config.GetSection("FirstLevelSetting").GetSection("SecondLevelSetting").GetValue<string>("BottomLevelSetting");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
