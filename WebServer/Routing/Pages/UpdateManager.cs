using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;
using Model.Entity;
using Model.Servise;
namespace Routing.Pages
{
  public  class UpdateManager : BasePage
    {
        protected override string Title { get { return "Update Manager"; } }

        public override Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
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

        protected override string AddBody(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors)
        {
            Response response;
            StringBuilder body = new StringBuilder("<body bgcolor='#ad5f2f'>");
            try
            {
                ManagerService ms = new ManagerService("manager.txt");
                Guid id = new Guid(form["id"]);

                Manager manager = ms.GetElement(id);

                body.Append("<form method='POST' action='UpdateManager'>");
                body.Append(Environment.NewLine);
                body.Append("<input type = 'hidden' name = 'id' value ='").Append(manager.Id).Append("'/>");
                body.Append(Environment.NewLine);
                body.Append("<p>Name:</p>");
                body.Append(Environment.NewLine);
                body.Append("<input type = 'text' name = 'name' value = '").Append(manager.Name).Append("'/>");
                body.Append(Environment.NewLine);
                body.Append("<p>Surname:</p>");
                body.Append(Environment.NewLine);
                body.Append("<input type = 'text' name = 'surname' value = '").Append(manager.Surname).Append("'/>");
                body.Append(Environment.NewLine);
                

//-----------------------------------------------------------------------------
                body.Append("<p>WorkExperience:</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><select name='experience' size='1'>");
                body.Append(Environment.NewLine);

                var values = Enum.GetValues(typeof(WorkExperience));
                foreach (var v in values)
                {
                    var option = string.Format("<option value='{0}'>{1}</option>", (int)v, Enum.GetName(typeof(WorkExperience), v));
                    body.Append(option);
                    body.Append(Environment.NewLine);
                }
                body.Append("</select></p></br>");




              
                body.Append(Environment.NewLine);
                body.Append("<p>Address:</p>");
                body.Append(Environment.NewLine);
                body.Append("<input type = 'text' name = 'address' value = '").Append(manager.Address).Append("'/>");
                body.Append(Environment.NewLine);
                body.Append("<p>Phone:</p>");
                body.Append(Environment.NewLine);
                body.Append("<input type = 'text' name = 'phone'  value = '").Append(manager.Phone).Append("'/>");
                body.Append(Environment.NewLine);
                body.Append("<p>Login:</p>");
                body.Append(Environment.NewLine);
                body.Append("<input type = 'text' name = 'login' value = '").Append(manager.Login).Append("'/>");
                body.Append(Environment.NewLine);
                body.Append("<p>Pasword:</p>");
                body.Append(Environment.NewLine);
                body.Append("<input type = 'text' name = 'password' value = '").Append(manager.Password).Append("'/>");
                body.Append(Environment.NewLine);
                body.Append("<p><br></p>");
                body.Append("<input type = 'submit' value = 'Submit'/>");
                body.Append(Environment.NewLine);
                body.Append("</form>");

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
