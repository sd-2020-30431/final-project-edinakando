using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.DataAccess.Entities
{
    public class Ingredient
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Quantity { get; set; }

        [Column("recipe_id")]
        [ForeignKey("recipe_ingredient_fk")]
        public Int32 RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
