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

    public class TovarController : ApiController
    {
        //Клас обгортка для бази даних
        private UnitOfWork uow = new UnitOfWork(new SQLServerContext("MyConnection"));

        // http://localhost:8889/api/tovar

        // ** На метод GET ** //
        public Tovar Get(int id)
        {
            try
            {
                return uow.Tovars.Get(id);
            }
            catch (Exception e) { return null; } // Якщо немає категорії
        }

        public IEnumerable<Tovar> GetAll()
        {
            return uow.Tovars.GetAll();
        }

        // ** На метод POST (Створення) ** //
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Post(Tovar obj)
        {
            try
            {
                uow.Tovars.Create(obj);
                return Request.CreateResponse(HttpStatusCode.Created); //  Code: 201
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError); // Code: 500
            }
        }

        // ** На метод Put (Редагування) ** //
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Put(Tovar obj)
        {
            try
            {
                uow.Tovars.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable); // Code: 406
            }
        }

        // ** На метод Delete (Видалення) ** //
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Delete(int id)
        {
            return (uow.Tovars.Delete(id)) ?
                 Request.CreateResponse(HttpStatusCode.OK) : //200
                 Request.CreateResponse(HttpStatusCode.NotFound); // Code: 404
        }
    }
}
