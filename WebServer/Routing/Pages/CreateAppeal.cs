
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

        protected override string AddBody(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            HtmlForm htmlForm = new HtmlForm(MethodsRequest.RequestMethod.POST, "CreateAppeal", errors);

            if (errors != null && errors.Count > 0)
            {
//---?

            }
            else
            {
                
                htmlForm.AddTag("lable", "Client:");
                htmlForm.AddTag("br");
                ClientServiсe cs = new ClientServiсe("client.txt");
                Dictionary<Guid, Client> clients = cs.GetAll();
                Dictionary<string,string> optionsclient = new Dictionary<string, string>();
                foreach (var c in clients)
                {
                    var fullnameclient = c.Value.Name + " " + c.Value.Surname;
                    optionsclient.Add(c.Value.Id.ToString(), fullnameclient);
                }
                htmlForm.AddTag(new HtmlSelect("clientId", optionsclient))
                    .SetAttribut("size", "1");
                htmlForm.AddTag("br");
                //--------------------------------------------------------------

                htmlForm.AddTag("lable", "The reason for petition:");
                htmlForm.AddTag("br");
                Dictionary<string, string> optionsappeal = new Dictionary<string, string>();
                var appeals = Enum.GetValues(typeof(ClientAppeal));
                 foreach (var v in appeals )
                 {
                    var appealclient =  v.ToString();
                    optionsappeal.Add(((int)v).ToString(), appealclient);
                }
                htmlForm.AddTag(new HtmlSelect("reason", optionsappeal))
                    .SetAttribut("size", "1");
                htmlForm.AddTag("br");
                //-------------------------------------------------------------------------------------
                htmlForm.AddTag("lable", "Comment:");
                htmlForm.AddTag("br");
                htmlForm.AddTag("textarea", "")
                    .SetAttribut("name", "comment")
                    .SetAttribut("cols", "70")
                    .SetAttribut("rows", "3");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "References:");
                htmlForm.AddTag("br");
                htmlForm.AddTag("textarea", "")
                    .SetAttribut("name", "references")
                    .SetAttribut("cols", "70")
                    .SetAttribut("rows", "5");
                htmlForm.AddTag("br");
                //-----------------------------------------------------------------------
                htmlForm.AddTag("lable", "The problem is solved?");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(TypeInputcs.InputType.Radio, "solve1", "yes"));
                htmlForm.AddTag("lable", "Yes");
                htmlForm.AddTag(new HtmlInput(TypeInputcs.InputType.Radio, "solve2", "no"));
                htmlForm.AddTag("lable", "No");
                htmlForm.AddTag("br");
                //-----------------------------------------------------------------------------
                htmlForm.AddTag("lable", "Serviced manager:");
                htmlForm.AddTag("br");
                ManagerService ms = new ManagerService("manager.txt");
                Dictionary<Guid, Manager> managers = ms.GetAll();
                Dictionary<string, string> optionsmanager = new Dictionary<string, string>();
               
                foreach (var man in managers)
                {
                    var fullnamemanager = man.Value.Name + " " + man.Value.Surname;
                    optionsmanager.Add(man.Value.Id.ToString(), fullnamemanager);
                
                }
                htmlForm.AddTag(new HtmlSelect("managerId", optionsmanager))
                    .SetAttribut("size", "1");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(TypeInputcs.InputType.Reset, "Reset", "Clin"));
                htmlForm.AddTag(new HtmlInput(TypeInputcs.InputType.Submit, "Submit", "Submit"));
            }

            StringBuilder body = new StringBuilder();
            body.Append(Environment.NewLine);
            body.Append(htmlForm.ToString(errors));
         
            return body.ToString();
        }



        public override Response Post(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null)
        {
            Response response;
            try
            {              
                Appeal appealclient = new Appeal(Guid.NewGuid(), new Guid(form["clientId"]), new Guid(form["managerId"]));

                appealclient.ClientAppeal = (ClientAppeal)Convert.ToInt32(form["reason"]);
                appealclient.Comment = form["comment"];
                appealclient.References = form["references"];

                if (form.ContainsKey("solve1") == form.ContainsKey("solve2"))
                {
                    appealclient.Rez = "no";
                }
                else
                {
                    if (form.ContainsKey("solve1"))
                    {
                        appealclient.Rez = form["solve1"];
                    }
                    else
                    {
                        appealclient.Rez = form["solve2"];
                    }
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