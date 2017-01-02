using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace DAL
{
   public class Category:IEntity
    {
        public int id { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<Tovar> Tovars { get; set; }
    }
}
