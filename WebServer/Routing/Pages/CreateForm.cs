using System;
using System.Collections.Generic;
using CollectionLibrary;
using System.Text;
using System.Threading.Tasks;
using Model.Servise;
using Model.Entity;
using Routing.Pages.Helpers;

namespace Routing.Pages
{
   public class CreateForm : BasePage
    {      
        protected override string Title { get { return "Form client's"; } }

        protected override string AddBody(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null, System.Collections.Generic.IDictionary<string, string> errors = null)
        {
            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "CreateForm", errors);
            htmlForm.AddTag("lable", "Name client:");
            ClientServiсe cs = new ClientServiсe("client.txt");
            HashDictionary<Guid, Client> clients = cs.GetAll();
            System.Collections.Generic.IDictionary<string,string> formclient = new CollectionLibrary.IDictionary<string, string>();
            foreach (var c in clients)
            {
                var temp1 = c.Value.Name + " " + c.Value.Surname;
                formclient.Add(c.Value.Id.ToString(), temp1);
            }
            htmlForm.AddSelect("clientId", formclient)
                .SetAttribut("size", "1");
            htmlForm.AddTag("br");
            //----------------------------------------------------------------------------------           
            htmlForm.AddTag("lable", "Are you satisfied with the service?");
            htmlForm.AddTag("br");
            htmlForm.AddTag(new HtmlInput(InputType.Radio, "form1", "yes"));
            htmlForm.AddTag("lable", "Yes");
            htmlForm.AddTag(new HtmlInput(InputType.Radio, "form2", "no"));
            htmlForm.AddTag("lable", "No");
            //----------------------------------------------------------------
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Comment:");
            htmlForm.AddTag("br");
            htmlForm.AddTag("textarea", "")
                .SetAttribut("name", "comment1")
                .SetAttribut("cols", "70")
                .SetAttribut("rows", "3");
            //-------------------------------------------------------
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Are you satisfied with the speed of the Internet?");
            htmlForm.AddTag("br");
            htmlForm.AddTag(new HtmlInput(InputType.Radio, "form3", "yes"));
            htmlForm.AddTag("lable", "Yes");
            htmlForm.AddTag(new HtmlInput(InputType.Radio, "form4", "no"));
            htmlForm.AddTag("lable", "No");
            htmlForm.AddTag("br");

            htmlForm.AddTag("lable", "Comment:");
            htmlForm.AddTag("br");
            htmlForm.AddTag("textarea", "")
                .SetAttribut("name", "comment2")
                .SetAttribut("cols", "70")
                .SetAttribut("rows", "3");

            //---------------------------------------------------------------------------------------------------
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

            htmlForm.AddTag("br");
            htmlForm.AddTag("p", "Filled manager:");
            ManagerService ms = new ManagerService("manager.txt");
            HashDictionary<Guid, Manager> managers = ms.GetAll();
            CollectionLibrary.IDictionary<string,string> formmanager = new CollectionLibrary.IDictionary<string, string>();
           
            foreach (var man in managers)
            {
                var temp3 = man.Value.Name + " " + man.Value.Surname;
                formmanager.Add(man.Value.Id.ToString(),temp3);
            }
            htmlForm.AddSelect("managerId", formmanager)
                .SetAttribut("size", "1");
            htmlForm.AddTag("br");
            htmlForm.AddTag(new HtmlInput(InputType.Reset, "Reset", "Clin"));
            htmlForm.AddTag(new HtmlInput(InputType.Submit, "Submit", "Submit"));
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

                Form formclient = new Form(Guid.NewGuid(), new Guid(form["clientId"]), new Guid(form["managerId"]));
                formclient.F1 = FormsClient.Are_you_satisfied_with_the_service;
                formclient.Comment = form["comment1"];
                formclient.F2 = FormsClient.Are_you_satisfied_with_the_speed_of_the_Internet;
                formclient.Comment = form["comment2"];
                /*formclient.F3 = FormsClient.Do_you_like_the_service_manager;
                formclient.Comment = form["comment3"];
                formclient.F4 = FormsClient.Do_you_use_the_Internet_and_TV;
                formclient.Comment = form["comment4"];
                formclient.F5 = FormsClient.Do_you_want_to_participate_in_the_loyalty_program;
                formclient.Comment = form["comment5"];*/

                if (form.ContainsKey("form1"))
                {
                    formclient.Answer1 = form["form1"];
                }
                else
                {
                    formclient.Answer1 = form["form2"];
                }

                if (form.ContainsKey("form3"))
                {
                    formclient.Answer2 = form["form3"];
                }
                else
                {
                    formclient.Answer2 = form["form4"];
                }
                FormServiсe formser = new FormServiсe("forms.txt");
                formser.Add(formclient);
                response = new Response("", TypeOfAnswer.Redirection, "FormList");
            }
            catch (Exception ex)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                Console.WriteLine(ex.Message );
                return response;
            }

           // response = new Response("", TypeOfAnswer.Redirection, "FormList");

            return response;
        }
    }
}
