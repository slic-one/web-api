using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Tovar : IEntity
    {
    
        public int id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public byte[] img { get; set; }
        public string Description { get; set; }
        public int idCategory { get; set; }

        //public virtual Category Category { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
    }
}
