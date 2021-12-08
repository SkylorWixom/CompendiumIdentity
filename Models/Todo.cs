using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompendiumIdentity.Models
{
    public class Todo
    {
        public int TodoID { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        
       public virtual Feature Feature { get; set; }
    }
}