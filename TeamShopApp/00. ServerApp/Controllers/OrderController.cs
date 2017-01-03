using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DAL;
using System.Net.Http;
using System.Net;

namespace SelfHostingApp
{
    [Authorize]
    public class OrderController : ApiController
    {
        private UnitOfWork uow = new UnitOfWork(new SQLServerContext("MyConnection"));

        // http://localhost:8889/api/order

        // ** На метод GET ** //
        [Authorize(Roles = "User,Admin")]
        public Order Get(int id)
        {
            try
            {
                return uow.Orders.Get(id);
            }
            catch (Exception e) { return null; }
        }

        [Authorize(Roles = "User,Admin")]
        public IEnumerable<Order> GetAll()
        {
            return uow.Orders.GetAll();
        }

        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Post(Order obj)
        {
            try
            {
                uow.Orders.Create(obj);
                return Request.CreateResponse(HttpStatusCode.Created); //  Code: 201
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError); // Code: 500
            }
        }

        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Put(Order obj)
        {
            try
            {
                uow.Orders.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable); // Code: 406
            }
        }

        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Delete(int id)
        {
            return (uow.Orders.Delete(id)) ?
                Request.CreateResponse(HttpStatusCode.OK) :
                Request.CreateResponse(HttpStatusCode.NotFound); // Code: 404
        }
    }
}
