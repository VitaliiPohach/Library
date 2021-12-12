using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;

        private readonly IBooks _books;
        public BooksController(IBooks books, IWebHostEnvironment appEnvironment)
        {
            _books = books;
            _appEnvironment = appEnvironment;
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


        public async Task<IActionResult> Archive(int id)
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

        public IActionResult GetFile()
        {
           
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Books.csv");
          
            string file_type = "application/csv";

            string file_name = "Books.csv";

            return PhysicalFile(file_path, file_type, file_name);
        }

        public async Task<IActionResult> SaveFile()
        {
            IList<Book> books = new List<Book>();
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files/Books.csv");

            books = await _books.GetAllAsync();
            _books.SaveToFile(file_path);
             
            return RedirectToAction(nameof(Index));
        }

    }
}
