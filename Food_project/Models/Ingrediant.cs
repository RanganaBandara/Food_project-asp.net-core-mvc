namespace Food_project.Models
{
	public class Ingrediant
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public List<Dishingrediant>? Dishingrediants { get; set; }
	}
}
