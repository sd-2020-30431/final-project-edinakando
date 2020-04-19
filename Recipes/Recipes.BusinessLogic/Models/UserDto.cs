using System;

namespace Recipes.BusinessLogic.Models
{
    public class UserDto
    {
        public Int32 ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public UserTypeDto Type { get; set; }

        public Boolean IsChef()
        {
            if (Type == UserTypeDto.chef)
            {
                return true;
            }

            return false;
        }
    }
}
