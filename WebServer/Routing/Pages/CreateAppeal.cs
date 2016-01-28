﻿
using System;
using CollectionLibrary;
using System.Text;
using System.Threading.Tasks;
using Model.Servise;
using Model.Entity;
using System.Collections.Generic;
using Routing.Pages.Helpers;

namespace Routing.Pages
{
    public class CreateAppeal : BasePage
    {
        public CreateAppeal()
            : base()
        {
        }

        protected override string Title { get { return "Create Appeal"; } }

        protected override string AddBody(MyHashTable<string, string> form, string sessionId = null, MyHashTable<string, string> errors = null)
        {
            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "CreateAppeal", errors);

            if (errors != null && errors.Count > 0)
            {
//---?

            }
            else
            {
                
                htmlForm.AddTag("p", "Client:");
                ClientServiсe cs = new ClientServiсe("client.txt");
                HashDictionary<Guid, Client> clients = cs.GetAll();
                MyList<string> optionsclient = new MyList<string>();
                foreach (var c in clients)
                {
                    var temp1 = c.Value.Name + " " + c.Value.Surname;
                    optionsclient.Add(temp1);
                }
                htmlForm.AddSelect("nameclient", optionsclient)
                    .SetAttribut("size", "1");
                //--------------------------------------------------------------

                htmlForm.AddTag("p", "The reason for petition:");
                MyList<string> optionsappeal = new MyList<string>();
                var appeals = Enum.GetValues(typeof(ClientAppeal));

                foreach (var v in appeals )
                {
                   var temp2 = (string.Format("{0} {1}", (int)v, Enum.GetName(typeof(ClientAppeal), v)));
                   optionsappeal.Add(temp2);
                }
                htmlForm.AddSelect("reason", optionsappeal)
                    .SetAttribut("size", "1");
                //-------------------------------------------------------------------------------------
                htmlForm.AddTag("p", "Comment:");
                htmlForm.AddTag("textarea", "")
                    .SetAttribut("name", "comment")
                    .SetAttribut("cols", "70")
                    .SetAttribut("rows", "3");
                htmlForm.AddTag("p", "References:");
                htmlForm.AddTag("textarea", "")
                    .SetAttribut("name", "references")
                    .SetAttribut("cols", "70")
                    .SetAttribut("rows", "5");
                //-----------------------------------------------------------------------
                htmlForm.AddTag("p", "The problem is solved?");
                htmlForm.AddInput("solve1", "yes", InputType.Radio);
                htmlForm.AddInput("solve2", "no", InputType.Radio);
                //-----------------------------------------------------------------------------
                htmlForm.AddTag("p", "Serviced manager:");
                ManagerService ms = new ManagerService("manager.txt");
                HashDictionary<Guid, Manager> managers = ms.GetAll();
                MyList<string> optionsmanager = new MyList<string>();
                foreach (var man in managers)
                {
                    var temp3 = man.Value.Name + " " + man.Value.Surname;
                    optionsmanager.Add(temp3);
                }
                htmlForm.AddSelect("namemanager", optionsmanager)
                    .SetAttribut("size", "1");
            }

            StringBuilder body = new StringBuilder("<body bgcolor='#07FFFF'>");
            body.Append(Environment.NewLine);
            body.Append("<form method='POST'>");
            body.Append(Environment.NewLine);
            body.Append(htmlForm.ToString());
            body.Append(Environment.NewLine);                         
            body.Append("</form>");
            body.Append(Environment.NewLine);
            body.Append("</body>");
            body.Append(Environment.NewLine);

            return body.ToString();
        }



        public override Response Post(MyHashTable<string, string> form, string sessionId = null)
        {
            Response response;
            try
            {

                Appeal appealclient = new Appeal(Guid.NewGuid(), new Guid(form["nameclient"]), new Guid(form["namemanager"]));

                appealclient.ClientAppeal = (ClientAppeal)Convert.ToInt32(form["reason"]);
                appealclient.Comment = form["comment"];
                appealclient.References = form["references"];
                if (form["solve1"] == "yes")
                {
                    appealclient.Rez = "Problem solved";
                }
                else
                {
                    appealclient.Rez = "Problem  not solved";
                }

                AppealServiсe aser = new AppealServiсe("appealclient.txt");
                aser.Add(appealclient);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response = new Response("", TypeOfAnswer.ServerError, "");
                Console.WriteLine(ex.Message);
                return response;
            }

            response = new Response("", TypeOfAnswer.Redirection, "AppealList");

            return response;
        }
    }
}