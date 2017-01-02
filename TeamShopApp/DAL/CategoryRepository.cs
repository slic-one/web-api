using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace DAL
{
   public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(SQLServerContext context) : base(context)
        {
            
        }
    }
}
