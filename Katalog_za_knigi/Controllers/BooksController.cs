using Katalog_za_knigi.DTOs;
using Katalog_za_knigi.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Katalog_za_knigi.Controllers
{
    public class BooksController(IBookService bookService, ICategoryService categoryService) : Controller
    {
        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await bookService.GetAllAsync());
        }

        [Route("Books/Search/{name}")]
        public IActionResult Search(string title)
        {
            return View(bookService.GetByTitle(title));
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await bookService.GetByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            book.Categories = await categoryService.GetAllAsync();
            return View(book);
        }

        [Authorize]
        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            var categories = await categoryService.GetAllAsync();
            var bookInfo = new BookDTO()
            {
                Categories = categories!
            };
            return View(bookInfo);
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Price,Description,ImageUrl,CategoryId")] BookDTO bookDto)
        {
            if (ModelState.IsValid)
            {
                await bookService.CreateAsync(bookDto);
                return RedirectToAction(nameof(Index));
            }
            return View(bookDto);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = await bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var categories = await categoryService.GetAllAsync();
            book.Categories = categories;

            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Price,Description,ImageUrl,CategoryId")] BookDTO bookDto)
        {
            if (id != bookDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await bookService.UpdateAsync(bookDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CatExistsAsync(bookDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            bookDto.Categories = await categoryService.GetAllAsync();
            return View(bookDto);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await bookService.GetByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await bookService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CatExistsAsync(int id)
        {
            var item = await bookService.GetByIdAsync(id);
            return item != null;
        }
    }
}
