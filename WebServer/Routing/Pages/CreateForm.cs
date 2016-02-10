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
            HtmlForm htmlForm = new HtmlForm(AllRequestMethods.RequestMethod.POST, "CreateForm", errors);
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Name client: ")
                .SetAttribut("class", "lable");
            ClientServiсe cs = new ClientServiсe("client.txt");
            Dictionary<Guid, Client> clients = cs.GetAll();
            Dictionary<string, string> formclient = new Dictionary<string, string>();
            foreach (var c in clients)
            {
                var allnameclient = c.Value.Name + " " + c.Value.Surname;
                formclient.Add(c.Value.Id.ToString(), allnameclient);
            }
            htmlForm.AddTag(new HtmlSelect("clientId", formclient))
                .SetAttribut("class", "select")
                .SetAttribut("size", "1");
            htmlForm.AddTag("br");
            //----------------------------------------------------------------------------------           
            htmlForm.AddTag("lable", "Are you satisfied with the service?")
                 .SetAttribut("class", "lablequestion");
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Yes")
                 .SetAttribut("class", "lableradio");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Radio, "form1", "yes"));
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "No")
                .SetAttribut("class", "lableradio");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Radio, "form2", "no"));
            //----------------------------------------------------------------
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Comment:")
                .SetAttribut("class", "lable");
            htmlForm.AddTag("textarea", "")
                .SetAttribut("class", "inputtextarea")
                .SetAttribut("name", "comment1")
                .SetAttribut("cols", "70")
                .SetAttribut("rows", "3");
            //-------------------------------------------------------
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Are you satisfied with the speed of the Internet?")
                 .SetAttribut("class", "lablequestion");
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Yes")
               .SetAttribut("class", "lableradio");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Radio, "form3", "yes"));
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "No")
                .SetAttribut("class", "lableradio");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Radio, "form4", "no"));
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Comment:")
                .SetAttribut("class", "lable");
            htmlForm.AddTag("textarea", "")
                .SetAttribut("class", "inputtextarea")
                .SetAttribut("name", "comment2")
                .SetAttribut("cols", "70")
                .SetAttribut("rows", "3");

            //---------------------------------------------------------------------------------------------------

            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", " Do you like the service manager?")
                .SetAttribut("class", "lablequestion");
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Yes")
                      .SetAttribut("class", "lableradio");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Radio, "form5", "yes"));
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "No")
               .SetAttribut("class", "lableradio");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Radio, "form6", "no"));
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Comment:")
                .SetAttribut("class", "lable");
            htmlForm.AddTag("textarea", "")
                .SetAttribut("class", "inputtextarea")
                .SetAttribut("name", "comment3")
                .SetAttribut("cols", "70")
                .SetAttribut("rows", "3");

            //---------------------------------------------------------------------------------------------------

            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Do you use the Internet and TV?")
                .SetAttribut("class", "lablequestion");
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Yes")
                .SetAttribut("class", "lableradio");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Radio, "form7", "yes"));
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "No")
                .SetAttribut("class", "lableradio");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Radio, "form8", "no"));
            htmlForm.AddTag("br");

            htmlForm.AddTag("lable", "Comment:")
                .SetAttribut("class", "lable");
            htmlForm.AddTag("textarea", "")
                .SetAttribut("class", "inputtextarea")
                .SetAttribut("name", "comment4")
                .SetAttribut("cols", "70")
                .SetAttribut("rows", "3");
            //---------------------------------------------------------------------------------------------------

            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Do you want to participate in the loyalty program?")
                .SetAttribut("class", "lablequestion");
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Yes")
                .SetAttribut("class", "lableradio");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Radio, "form9", "yes"));
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "No")
               .SetAttribut("class", "lableradio");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Radio, "form10", "no"));
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Comment:")
                .SetAttribut("class", "lable");
            htmlForm.AddTag("textarea", "")
                .SetAttribut("class", "inputtextarea")
                .SetAttribut("name", "comment5")
                .SetAttribut("cols", "70")
                .SetAttribut("rows", "3");
            htmlForm.AddTag("br");
            htmlForm.AddTag("lable", "Filled manager: ")
                 .SetAttribut("class", "lable");
            ManagerService ms = new ManagerService("manager.txt");
            Dictionary<Guid, Manager> managers = ms.GetAll();
            Dictionary<string, string> formmanager = new Dictionary<string, string>();

            foreach (var man in managers)
            {
                var allnamemanager = man.Value.Name + " " + man.Value.Surname;
                formmanager.Add(man.Value.Id.ToString(), allnamemanager);
            }
            htmlForm.AddTag(new HtmlSelect("managerId", formmanager))
                .SetAttribut("class", "select")
                .SetAttribut("size", "1");
            htmlForm.AddTag("br");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Reset, "Reset", "Clin"))
                .SetAttribut("class", "inputbutton");
            htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Submit, "Submit", "Submit"))
                .SetAttribut("class", "inputbutton");
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

                Form formclient = new Form(Guid.NewGuid(), new Guid(form["clientId"]), new Guid(form["managerId"]));
                formclient.F1 = FormsClient.Are_you_satisfied_with_the_service;
                formclient.Comment1 = form["comment1"];
                formclient.F2 = FormsClient.Are_you_satisfied_with_the_speed_of_the_Internet;
                formclient.Comment2 = form["comment2"];
                 formclient.F3 = FormsClient.Do_you_like_the_service_manager;
                 formclient.Comment3 = form["comment3"];
                 formclient.F4 = FormsClient.Do_you_use_the_Internet_and_TV;
                 formclient.Comment4 = form["comment4"];
                 formclient.F5 = FormsClient.Do_you_want_to_participate_in_the_loyalty_program;
                 formclient.Comment5 = form["comment5"];
                if (form.ContainsKey("form1") == form.ContainsKey("form2"))
                {
                    formclient.Answer1 = "yes";
                }
                else
                {
                    if (form.ContainsKey("form1"))
                    {
                        formclient.Answer1 = form["form1"];
                    }
                    else
                    {
                        formclient.Answer1 = form["form2"];
                    }
                }
                //----------------------------------------------
                if (form.ContainsKey("form3") == form.ContainsKey("form4"))
                {
                    formclient.Answer2 = "yes";
                }
                else
                {
                    if (form.ContainsKey("form3"))
                    {
                        formclient.Answer2 = form["form3"];
                    }
                    else
                    {
                        formclient.Answer2 = form["form4"];
                    }
                }
                //----------------------------------------------
                 if (form.ContainsKey("form5") == form.ContainsKey("form6"))
                 {
                     formclient.Answer3 = "yes";
                 }
                 else
                 {
                if (form.ContainsKey("form5"))
                 {
                     formclient.Answer1 = form["form5"];
                 }
                 else
                 {
                     formclient.Answer1 = form["form6"];
                 }
                 }
                 //----------------------------------------------
                 if (form.ContainsKey("form7") == form.ContainsKey("form8"))
                {
                    formclient.Answer4 = "yes";
                }
                else
                {
                 if (form.ContainsKey("form7"))
                 {
                     formclient.Answer1 = form["form7"];
                 }
                 else
                 {
                     formclient.Answer1 = form["form8"];
                 }
                 }
                 //----------------------------------------------
                 if (form.ContainsKey("form9") == form.ContainsKey("form10"))
                {
                    formclient.Answer5 = "yes";
                }
                else
                {
                 if (form.ContainsKey("form9"))
                 {
                     formclient.Answer1 = form["form9"];
                 }
                 else
                 {
                     formclient.Answer1 = form["form10"];
                 }
                 }
                FormServiсe formser = new FormServiсe("forms.txt");
                formser.Add(formclient);
            }
            catch (Exception ex)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                Console.WriteLine(ex.Message );
                return response;
            }

            response = new Response("", TypeOfAnswer.Redirection, "FormList");

            return response;
        }
    }
}
