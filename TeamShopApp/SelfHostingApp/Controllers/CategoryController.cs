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

    public class CategoryController : ApiController
    {
        //Клас обгортка для бази даних
        private UnitOfWork uow = new UnitOfWork(new SQLServerContext("MyConnection"));

        // http://localhost:8889/api/category

        // ** На метод GET ** //

        public Category Get(int id)
        {
            try
            {
                return uow.Categories.Get(id);
            }
            catch (Exception e)
            { return null; } // Якщо немає категорії
        }

        public IEnumerable<Category> GetAll()
        {
            return uow.Categories.GetAll();
        }

        // ** На метод POST (Створення) ** //
        // http://localhost:8889/api/category 
        /* 
          ЩОб додати:
            У заголовку: 
                Content-Type: application/json

            У тілі:
             об'єкт json. приклад: {"Name": "Нова категорія"} (достатньо імені, ід буде автоматично додано)
        */
        public HttpResponseMessage Post([FromBody]Category obj)
        {
            try
            {
                if (obj == null)
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable); //406 погані дані

                uow.Categories.Create(obj);
                return Request.CreateResponse(HttpStatusCode.Created); //  Code: 201
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError); // Code: 500
            }
        }

        // ** На метод Put (Редагування) ** //
        public HttpResponseMessage Put([FromBody]Category obj)
        {
            try
            {
                uow.Categories.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable); // Code: 406
            }
        }

        // ** На метод Delete (Видалення) ** //
        //Послати запит методом DELETE на адресу: http://localhost:8889/api/category/(id)

        public HttpResponseMessage Delete(int id)
        {

            return (uow.Categories.Delete(id)) ? 
                Request.CreateResponse(HttpStatusCode.OK) : //200
                Request.CreateResponse(HttpStatusCode.NotFound); // Code: 404
        }
    }
}
