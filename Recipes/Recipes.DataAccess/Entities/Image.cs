using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.DataAccess.Entities
{
    public class Image
    {
        public Int32 Id { get; set; }
        public String Path { get; set; }

        [Column("recipe_id")]
        [ForeignKey("recipe_image_fk")]
        public Int32 RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}