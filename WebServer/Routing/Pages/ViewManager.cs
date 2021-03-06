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
    public class ViewManager : BasePage
    {
        public ViewManager(AbstractServiceFactory sf)
            :base(sf)
        {
        }
        protected override string AddBody(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            Response response;
            StringBuilder body = new StringBuilder("<h1>View Manager</h1>");
            try
            {
                IManagerService sms = serviceFactory.CreateManagerService();
                //ManagerService ms = new ManagerService("manager.txt");
                Guid id = new Guid(form["id"]);
                //Manager manager = ms.GetElement(id);
                Manager manager = sms.GetElement(id);
                body.Append(Environment.NewLine);
                body.Append("<p><b>Name:   </b>").Append(manager.Name).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Surname:   </b>").Append(manager.Surname).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Work:   </b>").Append(manager.Work).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Address:   </b>").Append(manager.Address).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Phone number:   </b>").Append(manager.Phone).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Login:   </b>").Append(manager.Login).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Password:   </b>").Append(manager.Password).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append(Environment.NewLine);
                body.Append("<a href='UpdateManager?id=").Append(id).Append("'>Update Manager</a>");

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

