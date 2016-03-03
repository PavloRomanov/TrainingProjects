
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
            HtmlForm htmlForm = new HtmlForm(AllRequestMethods.RequestMethod.POST, "CreateAppeal", errors);
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Client:")
                .SetAttribut("class", "lable");
            //ClientService cs = new ClientService("client.txt");
           // Dictionary<Guid, Client> clients = cs.GetAll();
            SQLClientService scs = new SQLClientService("Clients");
            Dictionary<Guid, Client> clients = scs.GetAll();
            HtmlBaseTag selecclient = htmlForm.AddTag("select").SetAttribut("name", "clientId")
                 .SetAttribut("class", "select")
                 .SetAttribut("size", "1");
            foreach (KeyValuePair<Guid, Client> element in clients)
            {
                selecclient.AddTag("option", element.Value.Name + " " + element.Value.Surname)
                   .SetAttribut("value", element.Key.ToString());
            }

            htmlForm.AddTag("br");
            //--------------------------------------------------------------

            htmlForm.AddTag("lable", "The reason for petition:")
                 .SetAttribut("class", "lable");         
           
            HtmlBaseTag selectWork = htmlForm.AddTag("select").SetAttribut("name", "reason")
                   .SetAttribut("class", "select")
                   .SetAttribut("size", "1");
            foreach (KeyValuePair<AllAppeals.ClientAppeal, int> element in  AllAppeals.GetALL())
            {
                selectWork.AddTag("option", element.Key.ToString())
                   .SetAttribut("value", element.Value.ToString());
            }

            htmlForm.AddTag("br");
            //-------------------------------------------------------------------------------------
            htmlForm.AddTag("lable", "Comment:")
                .SetAttribut("class", "lable");
            htmlForm.AddTag("textarea", "")
                .SetAttribut("class", "inputtextarea")
                .SetAttribut("name", "comment")
                .SetAttribut("cols", "50")
                .SetAttribut("rows", "3");
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "References:")
                .SetAttribut("class", "lable");
            htmlForm.AddTag("textarea", "")
                .SetAttribut("class", "inputtextarea")
                .SetAttribut("name", "references")
                .SetAttribut("cols", "50")
                .SetAttribut("rows", "5");
            htmlForm.AddTag("br");
            //-----------------------------------------------------------------------
            htmlForm.AddTag("lable", "The problem is solved?")
                 .SetAttribut("class", "lable");
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Yes")
                 .SetAttribut("class", "lableradio");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Radio, "solve1", "yes"))
                .SetAttribut("class", "inrutradio");
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "No")
                .SetAttribut("class", "lableradio");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Radio, "solve2", "no"))
                .SetAttribut("class", "inrutradio");
            htmlForm.AddTag("br");
            //-----------------------------------------------------------------------------
            htmlForm.AddTag("lable", "Serviced manager:")
                .SetAttribut("class", "lable");
           // ManagerService ms = new ManagerService("manager.txt");
           // Dictionary<Guid, Manager> managers = ms.GetAll();
            SQLManagerService sms = new SQLManagerService("Managers");
            Dictionary<Guid, Manager> managers = sms.GetAll();
            HtmlBaseTag selectmanager = htmlForm.AddTag("select").SetAttribut("name", "managerId")
                   .SetAttribut("class", "select")
                   .SetAttribut("size", "1");
            foreach (KeyValuePair<Guid, Manager> element in managers)
            {
                selectmanager.AddTag("option", element.Value.Name + " " + element.Value.Surname)
                   .SetAttribut("value", element.Key.ToString());
            }
            htmlForm.AddTag("br");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Reset, "Reset", "Clin"))
                .SetAttribut("class", "buttonclin");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Submit, "Submit", "Submit"))
                .SetAttribut("class", "buttonsubmit");
            htmlForm.AddTag("br");

            StringBuilder body = new StringBuilder();
            body.Append(Environment.NewLine);
            body.Append(htmlForm.ToString(errors));

            return body.ToString();
        }



        public override Response Post(IDictionary<string, string> form, string sessionId = null)
        {
            Response response;
            try
            {              
                Appeal appealclient = new Appeal(Guid.NewGuid(), new Guid(form["clientId"]), new Guid(form["managerId"]));

                appealclient.ClientAppeal = (AllAppeals.ClientAppeal)Convert.ToInt32(form["reason"]);
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