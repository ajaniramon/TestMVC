using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestMVC.Models
{
    public class UserModel : EntityModel<Guid>
    {
        
        public string Nickname { get; set; }
        public string Password { get; set; }
    }

  
}