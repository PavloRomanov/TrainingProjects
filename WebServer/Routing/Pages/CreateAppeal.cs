
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
            ClientServiсe cs = new ClientServiсe("client.txt");
            HashDictionary<Guid, Client> clients = cs.GetAll();
            MyHashTable<string, string> optionsclient = new MyHashTable<string, string>();
            foreach (var c in clients)
            {
                var fullnameclient = c.Value.Name + " " + c.Value.Surname;
                optionsclient.Add(c.Value.Id.ToString(), fullnameclient);
            }

            MyHashTable<string, string> optionsappeal = new MyHashTable<string, string>();
            var appeals = Enum.GetValues(typeof(ClientAppeal));
            foreach (var v in appeals)
            {
                var appealclient = Enum.GetName(typeof(ClientAppeal), v);
                optionsappeal.Add(v.ToString(), appealclient);
            }
            ManagerService ms = new ManagerService("manager.txt");
            HashDictionary<Guid, Manager> managers = ms.GetAll();
            MyHashTable<string, string> optionsmanager = new MyHashTable<string, string>();

            foreach (var man in managers)
            {
                var fullnamemanager = man.Value.Name + " " + man.Value.Surname;
                optionsmanager.Add(man.Value.Id.ToString(), fullnamemanager);

            }



            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "CreateAppeal", errors);

            if (errors != null && errors.Count > 0)
            {
                htmlForm.AddSelect("clientId", optionsclient, "Name client: ");
                htmlForm.AddSelect("reason", optionsappeal, "The reason for petition: ");
                htmlForm.AddTag("comment", form["comment"], "Comment: ");
                htmlForm.AddTag("references", form["references"], "References: ");
                htmlForm.AddTag("", "The problem is solved?");
                htmlForm.AddInput("solve1", form["solve1"], InputType.Radio, "Yes");
                htmlForm.AddTag("", form["s"], "Yes");
                htmlForm.AddInput("solve2", form["solve2"], InputType.Radio, "No");
                htmlForm.AddTag("", form["s"], "No");
                htmlForm.AddSelect("managerId", optionsmanager, "Serviced manager: ");

            }
            else
            {

                
                htmlForm.AddSelect("clientId", optionsclient, "Name client: ")
                    .SetAttribut("size", "1");
                //--------------------------------------------------------------
              
                htmlForm.AddSelect("reason", optionsappeal, "The reason for petition: ")
                    .SetAttribut("size", "1");
                //-------------------------------------------------------------------------------------
                htmlForm.AddTag("textarea", "", "Comment: ")
                    .SetAttribut("name", "comment")
                    .SetAttribut("cols", "70")
                    .SetAttribut("rows", "3");
                //-------------------------------------------------------------------------
                htmlForm.AddTag("textarea", "", "References: ")
                    .SetAttribut("name", "references")
                    .SetAttribut("cols", "70")
                    .SetAttribut("rows", "5");
                //-----------------------------------------------------------------------
                htmlForm.AddTag("p", "The problem is solved?");
                htmlForm.AddInput("solve1", "yes", InputType.Radio,"Yes");              
                htmlForm.AddInput("solve2", "no", InputType.Radio,"No");
                //-----------------------------------------------------------------------------
               
                htmlForm.AddSelect("managerId", optionsmanager, "Serviced manager: ")
                    .SetAttribut("size", "1");
            }
            StringBuilder body = new StringBuilder("<body bgcolor='#ff6347'>");
            body.Append(Environment.NewLine);
            body.Append("<h1>Create Appeal</h1>");
            body.Append(htmlForm.ToString());
         
            return body.ToString();
        }



        public override Response Post(MyHashTable<string, string> form, string sessionId = null)
        {
            Response response;
            try
            {
               
                Appeal appealclient = new Appeal(Guid.NewGuid(), new Guid(form["clientId"]), new Guid(form["managerId"]));

                appealclient.ClientAppeal = (ClientAppeal)Convert.ToInt32(form["reason"]);
                appealclient.Comment = form["comment"];
                appealclient.References = form["references"];               

                if (form.ContainsKey("solve1"))
                {
                    appealclient.Rez = form["solve1"];
                }
                else
                {
                    appealclient.Rez = form["solve2"];
                }
                AppealServiсe aser = new AppealServiсe("appealclient.txt");
                aser.Add(appealclient);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response = new Response("", TypeOfAnswer.ServerError, "");
                return response;
            }

            response = new Response("", TypeOfAnswer.Redirection, "AppealList");

            return response;
        }
    }
}