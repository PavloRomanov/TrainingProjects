using System;
using System.Security.Cryptography.X509Certificates;
using CollectionLibrary;
using System.Text;
using System.Threading.Tasks;
using Model.Servise;
using Model.Entity;

namespace Routing.Pages
{
   public class CreateForm : BasePage
    {
        public CreateForm()
            : base()
        {

        }

        public override Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
        {
            Response response;
            try
            {

                Form formclient = new Form(Guid.NewGuid(),new Guid(form["clientId"]), new Guid(form["managerId"]));
                formclient.F1 = FormsClient.Are_you_satisfied_with_the_service;
                formclient.Comment = form["comment1"];
                /*formclient.F2 = FormsClient.Are_you_satisfied_with_the_speed_of_the_Internet;
                formclient.Comment = form["comment2"];
                formclient.F3 = FormsClient.Do_you_like_the_service_manager;
                formclient.Comment = form["comment3"];
                formclient.F4 = FormsClient.Do_you_use_the_Internet_and_TV;
                formclient.Comment = form["comment4"];
                formclient.F5 = FormsClient.Do_you_want_to_participate_in_the_loyalty_program;
                formclient.Comment = form["comment5"];*/
                      
                if (form["f1"] == "yes")
                {
                   formclient.Answer = "Yes";
                }
                else
                {
                    formclient.Answer = "No";
                }

                FormServiсe formser = new FormServiсe("forms.txt");
                formser.Add(formclient);
            }
            catch (Exception ex)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                Console.WriteLine(ex.Message);
                return response;
            }

            response = new Response("", TypeOfAnswer.Redirection, "FormList");

            return response;
        }
        protected override string Title { get { return "Form client's"; } }
        protected override string AddBody(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors)
        {
            StringBuilder body = new StringBuilder("<body bgcolor='#ff6347'>");
            body.Append(Environment.NewLine);
            body.Append("<form method='POST'>");
            body.Append(Environment.NewLine);
            body.Append("<p><b>Name client:</b></p>");
            body.Append(Environment.NewLine);
            body.Append("<p><select name='clientId' size='1'>");
            body.Append(Environment.NewLine);

            ClientServiсe cs = new ClientServiсe("client.txt");
            HashDictionary<Guid, Client> clients = cs.GetAll();

            foreach (var c in clients)
            {
                body.Append("<option value='").Append(c.Key).Append("'>").Append(c.Value.Name + " " + c.Value.Surname).Append("</option>");
                body.Append(Environment.NewLine);
            }

            body.Append("</select></p></br>");
            body.Append(Environment.NewLine);

            body.Append("<p><b>Are you satisfied with the service?</b><br/>");
            body.Append(Environment.NewLine);
            body.Append("<input type='radio' name='f1' value='yes'>> Yes</br>");
            body.Append(Environment.NewLine);
            body.Append("<input type='radio' name='f1' value='no'>> No</br>");
            body.Append(Environment.NewLine);
            body.Append("<p><b>Comment</b><br/>");
            body.Append(Environment.NewLine);
            body.Append("<textarea name='comment1' cols='70' rows='3'></textarea></p>");
            body.Append(Environment.NewLine);



           /* body.Append("<p><b>Are you satisfied with the speed of the Internet?</b><br>");
            body.Append(Environment.NewLine);
            body.Append("<input type='radio' name='f2' value='yes'> Yes</br>");
            body.Append(Environment.NewLine);
            body.Append("<input type='radio' name='f2' value='no'>> No</br>");
            body.Append(Environment.NewLine);
            body.Append("<p><b>Comment</b><br/>");
            body.Append(Environment.NewLine);
            body.Append("<textarea name='comment2' cols='70' rows='3'></textarea></p>");
            body.Append(Environment.NewLine);

            body.Append("<p><b>Do you like the service?</b><br/>");
            body.Append(Environment.NewLine);
            body.Append("<input type='radio' name='f3' value='yes'>> Yes</br>");
            body.Append(Environment.NewLine);
            body.Append("<input type='radio' name='f3' value='no'>> No</br>");
            body.Append(Environment.NewLine);
            body.Append("<p><b>Comment</b><br/>");
            body.Append(Environment.NewLine);
            body.Append("<textarea name='comment3' cols='70' rows='3'></textarea></p>");
            body.Append(Environment.NewLine);


            body.Append("<p><b>Do you use the Internet and TV?</b><br/>");
            body.Append(Environment.NewLine);
            body.Append("<input type='radio' name='f4' value='yes'>> Yes</br>");
            body.Append(Environment.NewLine);
            body.Append("<input type='radio' name='f4' value='no'>> No</br>");
            body.Append(Environment.NewLine);
            body.Append("<p><b>Comment</b><br/>");
            body.Append(Environment.NewLine);
            body.Append("<textarea name='comment4' cols='70' rows='3'></textarea></p>");
            body.Append(Environment.NewLine);


            body.Append("<p><b>Do you want to participate in the loyalty program?</b><br/>");
            body.Append(Environment.NewLine);
            body.Append("<input type='radio' name='f5' value='yes'>> Yes</br>");
            body.Append(Environment.NewLine);
            body.Append("<input type='radio' name='f5' value='no'>> No</br>");
            body.Append(Environment.NewLine);
            body.Append("<p><b>Comment</b><br/>");
            body.Append(Environment.NewLine);
            body.Append("<textarea name='comment5' cols='70' rows='3'></textarea></p>");
            body.Append(Environment.NewLine);*/


            body.Append("<p><b>Filled manager:</b><br/>");
            body.Append(Environment.NewLine);
            body.Append("<td><p><select name='managerId' size='1'>");
            body.Append(Environment.NewLine);
            ManagerServise ms = new ManagerServise("manager.txt");
            HashDictionary<Guid, Manager> managers = ms.GetAll();

            foreach (var man in managers)
            {
                body.Append("<option value='").Append(man.Key).Append("'>").Append(man.Value.Name + " " + man.Value.Surname).Append("</option>");
                body.Append(Environment.NewLine);
            }

            body.Append("</select></p></br>");

            body.Append("<p><input type='reset' value='Clear'></p>");
            body.Append(Environment.NewLine);
            body.Append(Environment.NewLine);
            body.Append("<p><input type='submit' value='Sand'></p>");
            body.Append(Environment.NewLine);
            body.Append("</form>");
            body.Append(Environment.NewLine);
            body.Append("</body>");
            body.Append(Environment.NewLine);

            return body.ToString();
        }

  
    }
}
