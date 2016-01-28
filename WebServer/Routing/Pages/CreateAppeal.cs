
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

        protected override string AddBody(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors)
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
                MyHashTable<string,string> optionsclient = new MyHashTable<string, string>();
                foreach (var c in clients)
                {
                    var fullnameclient = c.Value.Name + " " + c.Value.Surname;
                    optionsclient.Add(c.Value.Id.ToString(), fullnameclient);
                }
                htmlForm.AddSelect("clientId", optionsclient)
                    .SetAttribut("size", "1");
                //--------------------------------------------------------------

                htmlForm.AddTag("p", "The reason for petition:");
                MyHashTable<string, string> optionsappeal = new MyHashTable<string, string>();
                var appeals = Enum.GetValues(typeof(ClientAppeal));
                foreach (var v in appeals )
                {
                   var appealclient = (string.Format("{0}"/*,Enum.GetName(typeof(ClientAppeal),*/, v));
                   optionsappeal.Add(v.ToString(), appealclient);
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
                htmlForm.AddTag("label", "Yes");
                htmlForm.AddInput("solve2", "no", InputType.Radio);
                htmlForm.AddTag("label", "No");
                //-----------------------------------------------------------------------------
                htmlForm.AddTag("p", "Serviced manager:");
                ManagerService ms = new ManagerService("manager.txt");
                HashDictionary<Guid, Manager> managers = ms.GetAll();
                MyHashTable<string, string> optionsmanager = new MyHashTable<string, string>();
               
                foreach (var man in managers)
                {
                    var fullnamemanager = man.Value.Name + " " + man.Value.Surname;
                    optionsmanager.Add(man.Value.Id.ToString(), fullnamemanager);
                
                }
                htmlForm.AddSelect("managerId", optionsmanager)
                    .SetAttribut("size", "1");
            }
            StringBuilder body = new StringBuilder("<body bgcolor='#ff6347'>");
            body.Append(Environment.NewLine);
            body.Append("<h1>Create Appeal</h1>");
            body.Append(htmlForm.ToString());
         
            return body.ToString();
        }



        public override Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
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