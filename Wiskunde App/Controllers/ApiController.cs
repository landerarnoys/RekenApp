using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;
using Wiskunde_App.DataAccess.Services;
using Wiskunde_App.Models;

namespace Wiskunde_App.Controllers
{
    public class APIController : ApiController
    {
        private IOefeningService service;
        public APIController()
        {

        }

        public APIController(IOefeningService service)
        {
            this.service = service;
        }


        [Route("alleoefeningen")]
        public HttpResponseMessage getAlleOefeningen()
        {
            HttpResponseMessage message = null;
            List<Oefeningen> oefening = service.getAlleOefeningen();
            try
            {
                message = new HttpResponseMessage(HttpStatusCode.OK);
                message.Content = new ObjectContent<List<Oefeningen>>(oefening, Configuration.Formatters[0], "application/json");
                return message;
            }
            catch (Exception ex)
            {
                message = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            return message;
        }



        [Route("oefening/{id}")]
        public HttpResponseMessage getOefeningById(int id)
        {
            HttpResponseMessage message = null;
            Oefeningen oefening = service.getOefeningById(id);
            try
            {
                message = new HttpResponseMessage(HttpStatusCode.OK);
                message.Content = new ObjectContent<Oefeningen>(oefening, Configuration.Formatters[0], "application/json");
                return message;
            }
            catch (Exception ex)
            {
                message = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            return message;
        }


        [Route("saveResultaat")]
        public HttpResponseMessage Post(Resultaten resultaten)
        {
            //userManagementService.GetUser(User.Identity.Name);
            Leerling testLeerling = new Leerling();
            testLeerling.Voornaam = "Lander";
            testLeerling.Familienaam = "Arnoys";
            testLeerling.ID = 1;
            resultaten.LeerlingID = testLeerling.ID;
            resultaten.LeerlingID = 1;
          
            
            service.addResultaat(resultaten);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
