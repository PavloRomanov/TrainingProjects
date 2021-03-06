﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;
using Model.Entity;
using Model.Servise;

namespace Routing.Pages
{
    public class ViewClient : BasePage
    {
        public ViewClient(AbstractServiceFactory sf)
            :base(sf)
        {
        }

        protected override string AddBody(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            Response response;
            StringBuilder body = new StringBuilder("<h1>ViewClient</h1>");
            try
            {
                IClientService cs = serviceFactory.CreateClientService();
                Guid id = new Guid(form["id"]);

                Client client = cs.GetElement(id);
                                
                body.Append(Environment.NewLine);
                body.Append("<p><b>Name:</b>").Append(client.Name).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Surname:</b>").Append(client.Surname).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Address:</b>").Append(client.Address).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Phone number::</b>").Append(client.Phone).Append("</p>");
                body.Append(Environment.NewLine);                
                body.Append(Environment.NewLine);
                body.Append("<a href='UpdateClient?id=").Append(id).Append("'>Update Client</a>");
               
            }
            catch (Exception)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                return "";
            }

            return body.ToString();
        }
    }
    
}
