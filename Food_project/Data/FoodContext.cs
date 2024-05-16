using Food_project.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_project.Data
{
	public class FoodContext:DbContext

	{
		public FoodContext(DbContextOptions<FoodContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Dishingrediant>().HasKey(di=>new
			{
				di.DishId,
				di.IngregiantId
			}
				
				);

			modelBuilder.Entity<Dishingrediant>().HasOne(d => d.Dish).WithMany(di => di.Dishingrediants).HasForeignKey(d => d.DishId);
			modelBuilder.Entity<Dishingrediant>().HasOne(i => i.Ingrediant).WithMany(di => di.Dishingrediants).HasForeignKey(i=>i.IngregiantId);

			modelBuilder.Entity<Dish>().HasData(

				new Dish {Id=1,Name="Pizza",ImageUrl= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRbtv-UwXqSWD55s_nAdxP7Wofwn3by_lhhQoXPff7O9g&s",price=1000 }

				);
			modelBuilder.Entity<Ingrediant>().HasData(
				new Ingrediant { Id=1,Name="Mozeralla"},
				new Ingrediant { Id=2,Name="prawns"}
				);
			modelBuilder.Entity<Dishingrediant>().HasData(
				new Dishingrediant { DishId=1,IngregiantId=1},
				new Dishingrediant { DishId = 1, IngregiantId = 2}
				);
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Dish> Dishes { get; set; }
		public DbSet<Ingrediant> Ingrediants { get; set; }
		public DbSet<Dishingrediant> Dishingrediants { get; set;}
	}
		
}
