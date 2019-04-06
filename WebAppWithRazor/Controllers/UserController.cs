﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppWithRazor.Context;
using WebAppWithRazor.Models;

namespace WebAppWithRazor.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _context;

        public UserController()
        {
            _context = DatabaseContext.Create();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vmUser = new UserViewModel()
            {
                //Collection = _context.Users.ToList()
            };
            return View(vmUser);
        }

        [HttpGet]
        public IActionResult Result()
        {
            return PartialView("_ResultTable", _context.Users.ToList());
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var model = _context.Users.FirstOrDefault(u => u.Id == id);

            return View("Model", model);
        }

        [HttpPost]
        public IActionResult Save(UserModel model)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}