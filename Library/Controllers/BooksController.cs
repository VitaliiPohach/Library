﻿using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BooksController : Controller
    {

        private readonly IBooks _books;
        public BooksController(IBooks books)
        {
            _books = books;
        }
        public async Task< IActionResult> Index()
        {
            return View(await _books.GetAllAsync());
        }

        public async Task<IActionResult> ShowAllSorted()
        {
            var books = await _books.GetAllAsync();


            return View("Index",books.OrderBy(b=>b.Title));
        }

        public async Task<IActionResult> ShowAllReserved()
        {
            var books = await _books.GetAllAsync();


            return View("Index", books.Where(b => b.IsReserved == true));
        }

        public async Task<IActionResult> ShowAllAvailable()
        {
            var books = await _books.GetAllAsync();


            return View("Index", books.Where(b => b.IsReserved == false));
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                return View(await _books.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Reservation(int id)
        {
            try
            {
                return View(await _books.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,  Book book)
        {
            try
            {
                await _books.EditAsync(book);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
