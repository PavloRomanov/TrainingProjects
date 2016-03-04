using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;
using Model.Entity;
using Model.Servise;
using Routing.Pages.Helpers;

namespace Routing.Pages
{
    public class UpdateManager : BasePage
    {
        public UpdateManager(AbstractServiceFactory sf)
            :base(sf)
        {
        }

        protected override string Title { get { return "Update Manager"; } }

        public override Response Post(IDictionary<string, string> form, string sessionId = null)
        {
            Response response;
            try
            {
                //ManagerService ms = new ManagerService("manager.txt");
                IManagerService sms = serviceFactory.CreateManagerServise();
                Guid id = new Guid(form["id"]);
                Manager manager = new Manager(id, form["name"], form["surname"], form["address"], form["phone"], form["login"], form["password"]);
                manager.Work = (StageExperience.WorkExperience)Convert.ToInt32(form["experience"]);
                //ms.Update(manager);
                sms.Update(manager);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response = new Response("", TypeOfAnswer.ServerError, "");
                return response;
            }

            response = new Response("", TypeOfAnswer.Redirection, "ManagersList");

            return response;
        }

        protected override string AddBody(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            Response response;
            try
            {
                //ManagerService ms = new ManagerService("manager.txt");
                IManagerService sms = serviceFactory.CreateManagerServise();
                Guid id = new Guid(form["id"]);
                //Manager manager = ms.GetElement(id);
                Manager manager = sms.GetElement(id);
                HtmlForm htmlForm = new HtmlForm(AllRequestMethods.RequestMethod.POST, "UpdateManager", errors);
                htmlForm.SetAttribut("novalidate", "novalidate");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Hidden, "id", manager.Id.ToString()));
                htmlForm.AddTag("lable", "Name :")
                    .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "name", manager.Name))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("class", "inputtext")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "forname");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Surname :")
                   .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "surname", manager.Surname))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("class", "inputtext")
                    .SetAttribut("placeholder", "max length of 15 characters");
                htmlForm.AddTag("span").SetAttribut("id", "forsurname");

                
//-----------------------------------------------------------------------------

                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "WorkExperience: ")
                    .SetAttribut("class", "lable");
                HtmlBaseTag selectWork = htmlForm.AddTag("select").SetAttribut("name", "experience")
                    .SetAttribut("class", "select")
                    .SetAttribut("size", "1");
                foreach (KeyValuePair<StageExperience.WorkExperience, int> element in StageExperience.GetALL())
                {

                    if (element.Key.Equals(manager.Work))
                    {
                        selectWork.AddTag("option", element.Key.ToString())
                           .SetAttribut("selected")
                           .SetAttribut("value", element.Value.ToString());
                    }
                    else
                    {
                        selectWork.AddTag("option", element.Key.ToString())
                           .SetAttribut("value", element.Value.ToString());
                    }
                }

                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Address :")
                    .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "address", manager.Address))
                    .SetAttribut("maxlength", "50")
                    .SetAttribut("class", "inputtext")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "foraddress");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Phone :")
                    .SetAttribut("class", "lable");

                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "phone", manager.Phone))
                    .SetAttribut("class", "inputtext")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "forphone");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Login :")
                    .SetAttribut("class", "lable");

                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "login", manager.Login))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("class", "inputtext")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "forlogin");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Password :")
                    .SetAttribut("class", "lable");
              
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "password", manager.Password))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("class", "inputtext")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "forpassword");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Reset, "Reset", "Clin"))
                     .SetAttribut("class", "buttonclin");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Submit, "Submit", "Submit"))
                     .SetAttribut("class", "inputbutton");
                htmlForm.AddTag("br");
                StringBuilder body = new StringBuilder(Environment.NewLine);
                body.Append(AddGreeting(sessionId));
                body.Append(Environment.NewLine);
                body.Append(htmlForm.ToString(errors));
                body.Append(Environment.NewLine);

                return body.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response = new Response("", TypeOfAnswer.ServerError, "");
                return "";
            }
        }
    }
}
