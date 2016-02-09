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
  public  class UpdateManager : BasePage
    {
        protected override string Title { get { return "Update Manager"; } }

        public override Response Post(IDictionary<string, string> form, string sessionId = null)
        {
            Response response;
            try
            {
                ManagerService ms = new ManagerService("manager.txt");
                Guid id = new Guid(form["id"]);
                Manager manager = new Manager(id, form["name"], form["surname"], form["address"], form["phone"], form["login"], form["password"]);
                manager.Work = (WorkExperience)Convert.ToInt32(form["experience"]);
                ms.Update(manager);
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

        protected override string AddBody(IDictionary<string, string> form, string sessionId = null,IDictionary<string, string> errors = null)
        {
            Response response;
            try
            {
                ManagerService ms = new ManagerService("manager.txt");
                Guid id = new Guid(form["id"]);
                Manager manager = ms.GetElement(id);
                HtmlForm htmlForm = new HtmlForm(AllRequestMethods.RequestMethod.POST, "UpdateManager", errors);
                htmlForm.SetAttribut("novalidate", "novalidate");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Hidden, "id", manager.Id.ToString()));
                htmlForm.AddTag("lable", "Name :");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "name", manager.Name))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "forname");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Surname :");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "surname", manager.Surname))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters");
                htmlForm.AddTag("span").SetAttribut("id", "forsurname");


                //-----------------------------------------------------------------------------
                //var ew = form["experience"];  
                var ew = new Dictionary<string,string>();            
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "WorkExperience: ");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlSelect("experience",ew));//?????????????
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Address :");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "address", manager.Address))
                    .SetAttribut("maxlength", "50")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "foraddress");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Phone :");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "phone", manager.Phone))
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "forphone");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Login :");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "login", manager.Login))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "forlogin");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Password :");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "password", manager.Password))
                    .SetAttribut("maxlength", "15")
                   .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "forpassword");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Reset, "Reset", "Clin"));
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Submit, "Submit", "Submit"));
                StringBuilder body = new StringBuilder(Environment.NewLine);
                body.Append(AddGreeting(sessionId));
                body.Append(Environment.NewLine);
                body.Append(htmlForm.ToString(errors));
                body.Append(Environment.NewLine);

                return body.ToString();
            }
            catch (Exception)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                return "";
            }
        }

    }
}
