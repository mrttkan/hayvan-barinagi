﻿using HayvanBarinagi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HayvanBarinagi.Controllers
{
    public class HomeController : Controller
    {
        private readonly HayvanBarinagiContext _context;

        public HomeController(HayvanBarinagiContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Hayvanlar = await _context.Hayvanlar.Where(h => !h.Sahiplendirildi).ToListAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}