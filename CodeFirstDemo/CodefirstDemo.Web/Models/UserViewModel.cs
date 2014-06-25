using System.Collections.Generic;

namespace CodefirstDemo.Web.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GroupName { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} ", FirstName, LastName);
            }
        }
    }
}