using Katalog_za_knigi.DTOs;
using Katalog_za_knigi.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Katalog_za_knigi.Controllers
{
    public class ReadersController(IReaderService readerService) : Controller
    {
        // GET: Readers
        public async Task<IActionResult> Index()
        {
            return View(await readerService.GetAllAsync());
        }

        [Route("Readers/Search/{name}")]
        public IActionResult Search(string name)
        {
            return View(readerService.GetByName(name));
        }

        // GET: Readers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await readerService.GetByIdAsync(id.Value);
            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        [Authorize]
        // GET: Readers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Readers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,IsStudent")] ReaderDTO readerDto)
        {
            if (ModelState.IsValid)
            {
                await readerService.CreateAsync(readerDto);
                return RedirectToAction(nameof(Index));
            }
            return View(readerDto);
        }

        // GET: Readers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await readerService.GetByIdAsync(id.Value);
            if (reader == null)
            {
                return NotFound();
            }
            return View(reader);
        }

        // POST: Readers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,IsStudent")] ReaderDTO readerDto)
        {
            if (id != readerDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await readerService.UpdateAsync(readerDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CatExistsAsync(readerDto.Id))
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
            return View(readerDto);
        }

        // GET: Readers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await readerService.GetByIdAsync(id.Value);
            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        // POST: Readers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await readerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CatExistsAsync(int id)
        {
            var item = await readerService.GetByIdAsync(id);
            return item != null;
        }
    }
}
