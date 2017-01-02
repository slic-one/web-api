using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork:IDisposable
    {
        bool disposed = false;
        SQLServerContext context;

        private TovarRepository TR;
        private OrderRepository OR;
        private CategoryRepository CR;

        public UnitOfWork(SQLServerContext context)
        {
            this.context = context;
        }

        public TovarRepository Tovars
        {
            get
            {
                return (TR == null) ? TR = new TovarRepository(context):TR;
            }
        }

        public OrderRepository Orders
        {
            get
            {
                if (OR == null)
                    OR = new OrderRepository(context);
                return OR;
            }
        }
        public CategoryRepository Categories
        {
            get
            {
                if (CR == null)
                    CR = new CategoryRepository(context);
                return CR;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                    this.disposed = true;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
