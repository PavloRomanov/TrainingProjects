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

        public override Response Post(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null)
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
                var ew = new Dictionary<string,string>() ;
                Manager manager = ms.GetElement(id);
                HtmlForm htmlForm = new HtmlForm(MethodsRequest.RequestMethod.POST, "UpdateManager", errors);
                htmlForm.AddTag(new HtmlInput(TypeInputcs.InputType.Hidden, "id", manager.Id.ToString()));
                htmlForm.AddTag(new HtmlInput(TypeInputcs.InputType.Text, "name", manager.Name));
                htmlForm.AddTag(new HtmlInput(TypeInputcs.InputType.Text, "surname", manager.Surname));



                //-----------------------------------------------------------------------------
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "WorkExperience: ");
                htmlForm.AddTag(new HtmlSelect("experience",ew));
                htmlForm.AddTag("br");                  
                htmlForm.AddTag(new HtmlInput(TypeInputcs.InputType.Text, "address", manager.Address));
                htmlForm.AddTag(new HtmlInput(TypeInputcs.InputType.Text, "phone", manager.Phone));
                htmlForm.AddTag(new HtmlInput(TypeInputcs.InputType.Text, "login", manager.Login));
                htmlForm.AddTag(new HtmlInput(TypeInputcs.InputType.Text, "password", manager.Password));
                htmlForm.AddTag(new HtmlInput(TypeInputcs.InputType.Reset, "Reset", "Clin"));
                htmlForm.AddTag(new HtmlInput(TypeInputcs.InputType.Submit, "Submit", "Submit"));
                StringBuilder body = new StringBuilder();
                body.Append("<form method='POST' action='UpdateManager'>");
                body.Append(Environment.NewLine);
                body.Append(htmlForm.ToString());
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
