using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Areas.Admin.Controllers;
[Area("Admin")]
public class SliderController : Controller
{

    private readonly ProniaDbContext _context;
    public SliderController(ProniaDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var Sliders = await _context.Sliders.ToListAsync();
        var Shippings = await _context.Shippings.ToListAsync();

        HomeViewModel viewModel = new HomeViewModel()
        {
            Sliders = Sliders,
            Shippings = Shippings
        };
        return View(viewModel);
    }
    public IActionResult Create()
    {
        return View();

    }
    [HttpPost]
    public async Task<IActionResult> Create(Slider slider)
    {
        await _context.Sliders.AddAsync(slider);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }
    public IActionResult Detail(int id)
    {
        return View();
    }
}

