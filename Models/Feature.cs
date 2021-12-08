using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompendiumIdentity.Models
{
    public class Feature
    {
        public int FeatureID { get; set; }

        public string Name { get; set; }
        

        
        public virtual Project Project{get;set;}
        public ICollection<Todo> todo { get; set; }
    }
}