namespace Food_project.Models
{
	public class Dishingrediant
	{
		public int DishId { get; set; }
		public Dish Dish { get; set; }

		public int IngregiantId { get; set; }
		public Ingrediant Ingrediant { get; set; }

	}
}
