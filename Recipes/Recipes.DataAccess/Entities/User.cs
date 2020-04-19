using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.DataAccess.Entities
{
    public class User
    {
        public Int32 ID { get; set; }

        [Column("first_name")]
        public String FirstName { get; set; }

        [Column("last_name")]
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

        [ForeignKey("role_id")]
        public Role Role { get; set; }
    }
}
