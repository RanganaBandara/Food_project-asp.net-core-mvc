using Food_project.Models;
using Food_project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food_project.Controllers

{
	public class MenuController : Controller
	{
		private readonly FoodContext _context;

		public MenuController(FoodContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index(string SearchString)
		{
			var dishes = from d in _context.Dishes
					   select d;
			if (!string.IsNullOrEmpty(SearchString))
			{
				dishes = dishes.Where(d => d.Name.Contains(SearchString));
                return View(await dishes.ToListAsync());

            }
            return View(await dishes.ToListAsync());
		}

		public async Task<IActionResult> DetailsView(int ? id)
		{
			var dish=await _context.Dishes
				.Include(di=> di.Dishingrediants)
				.ThenInclude(i=>i.Ingrediant)
				.FirstOrDefaultAsync(x=>x.Id==id);

			if (dish == null)
			{
				return NotFound();
			}
			return View(dish);
		}
	

	}
}
