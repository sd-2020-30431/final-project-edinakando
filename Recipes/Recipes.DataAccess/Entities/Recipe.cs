using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.DataAccess.Entities
{
    public class Recipe
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Instructions { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Image> Images { get; set; }

        [Column("user_id")]
        [ForeignKey("user_fk")]
        public Int32 UserId { get; set; }
        public User User { get; set; }
    }
}
