using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompendiumIdentity.Models
{
    public class Project
    {
        public int ProjectID { get; set; }

        public string Name { get; set; }

        public virtual ApplicationUser user { get; set; }
        public ICollection<Feature> feature { get; set; }
    }
}