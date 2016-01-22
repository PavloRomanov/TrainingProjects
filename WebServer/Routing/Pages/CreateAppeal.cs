
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
                
                htmlForm.AddTag(new HtmlTag("p", "Client:"));
                ClientServiсe cs = new ClientServiсe("client.txt");
                HashDictionary<Guid, Client> clients = cs.GetAll();
                MyList<string> optionsclient = new MyList<string>();
                foreach (var c in clients)
                {
                    var temp1 = c.Value.Name + " " + c.Value.Surname;
                    optionsclient.Add(temp1);
                }
                htmlForm.AddTag(new TagSelect("", "nameclient", optionsclient));
                //--------------------------------------------------------------

                htmlForm.AddTag(new HtmlTag("p", "The reason for petition:"));
                MyList<string> optionsappeal = new MyList<string>();
                var appeals = Enum.GetValues(typeof(ClientAppeal));

                foreach (var v in appeals )
                {
                   var temp2 = (string.Format("{0} {1}", (int)v, Enum.GetName(typeof(ClientAppeal), v)));
                   optionsappeal.Add(temp2);
                }
                htmlForm.AddTag(new TagSelect("", "reason", optionsappeal));
                //-------------------------------------------------------------------------------------
                htmlForm.AddTag(new HtmlTag("p", "Comment:"));
                htmlForm.AddTag(new HtmlTag("textarea", "")).SetAdditionalAttributes("name", "'comment'")//?
                    .SetAdditionalAttributes("cols", "'70'")
                    .SetAdditionalAttributes("rows", "'3'");
                htmlForm.AddTag(new HtmlTag("p", "References:"));
                htmlForm.AddTag(new HtmlTag("textarea", ""));
                //-----------------------------------------------------------------------
                htmlForm.AddTag(new HtmlTag("p", "The problem is solved?"));
                htmlForm.AddInput("Yes", "", InputType.Radio);
                htmlForm.AddInput("No", "", InputType.Radio);
                //-----------------------------------------------------------------------------
                htmlForm.AddTag(new HtmlTag("p", "Serviced manager:"));
                ManagerService ms = new ManagerService(".txt");
                HashDictionary<Guid, Manager> managers = ms.GetAll();
                MyList<string> optionsmanager = new MyList<string>();
                foreach (var man in managers)
                {
                    var temp3 = man.Value.Name + " " + man.Value.Surname;
                    optionsmanager.Add(temp3);
                }
                htmlForm.AddTag(new TagSelect("", "namemanager", optionsmanager));
                



            }

            StringBuilder body = new StringBuilder("<body bgcolor='#07FFFF'>");
            body.Append(Environment.NewLine);
            body.Append("<form method='POST'>");
            body.Append(Environment.NewLine);
            body.Append(htmlForm.ToString());
            body.Append(Environment.NewLine);
            //=======================================================================================================        

           /* body.Append("<p><b>Comment</b><Br>");
            body.Append(Environment.NewLine);
            body.Append("<textarea name='comment' cols='70' rows='3'></textarea></p>");
            body.Append(Environment.NewLine);
            body.Append("<p><b>References</b><Br>");
            body.Append(Environment.NewLine);
            body.Append("<textarea name='references' cols='70' rows='5'></textarea></p>");
            body.Append(Environment.NewLine);

            body.Append("<p><b>The problem is solved?</b></p>");
            body.Append(Environment.NewLine);
            body.Append("<input type='radio'name='solve' value='yes'>Yes<Br>");
            body.Append(Environment.NewLine);
            body.Append("<input type='radio'name='solve' value='no'>No<Br>");
            body.Append(Environment.NewLine);*/

            body.Append("</form>");
            body.Append(Environment.NewLine);
            body.Append("</body>");
            body.Append(Environment.NewLine);

            return body.ToString();
        }



        public override Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
        {
            Response response;
            try
            {

                Appeal appealclient = new Appeal(Guid.NewGuid(), new Guid(form["nameclient"]), new Guid(form["namemanager"]));

                appealclient.ClientAppeal = (ClientAppeal)Convert.ToInt32(form["reason"]);
                appealclient.Comment = form["comment"];
                appealclient.References = form["references"];
                if (form["solve"] == "yes")
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