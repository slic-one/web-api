using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace DAL
{
    public class Order:IEntity
    {
        public int id { get; set; }
        public int idTovar { get; set; }
        public int idUser { get; set; }
        public DateTime DateOrder { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public bool IsCompleted { get; set; }

        public virtual Tovar Tovar { get; set; }
    }
}
