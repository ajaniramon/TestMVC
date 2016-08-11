using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC.Models
{
    public class SuscriptionModel : EntityModel<Guid>
    {
     public virtual string Email { get; set; }
     public virtual DateTime Date { get; set; }

    }
}