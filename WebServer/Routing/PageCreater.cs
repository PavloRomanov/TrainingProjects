using System;

using System.Collections.Generic;
using CollectionLibrary;
using Routing.Pages;
using Model.Servise;
using Model.Entity;

namespace Routing
{
    public class PageCreater
    {
        private static readonly PageCreater instance = new PageCreater();
        public Dictionary<string, IBasePage> pages;
        //AbstractServiceFactory serviceFactory = new FileServiceFactory();
        AbstractServiceFactory serviceFactory = new SQLServiceFactory();
        
        private PageCreater()
        {
            pages = new Dictionary<string, IBasePage>();
            pages.Add("Index", new Index());
            pages.Add("CreateClient", new CreateClient(serviceFactory));
            pages.Add("DeleteClient", new DeleteClient(serviceFactory));
            pages.Add("UpdateClient", new UpdateClient(serviceFactory));
            pages.Add("ClientsList", new ClientsList(serviceFactory));
            pages.Add("ViewClient", new ViewClient(serviceFactory));
            pages.Add("LogIn", new LogIn(serviceFactory));
            pages.Add("LogOut", new LogOut());
            pages.Add("CreateManager", new CreateManager(serviceFactory));
            pages.Add("ManagersList", new ManagersList(serviceFactory));
            pages.Add("ViewManager", new ViewManager(serviceFactory));
            pages.Add("UpdateManager", new UpdateManager(serviceFactory));
            pages.Add("DeleteManager", new DeleteManager(serviceFactory));
            pages.Add("CreateAppeal", new CreateAppeal(serviceFactory));
            pages.Add("AppealList", new AppealList(serviceFactory));
            pages.Add("ViewAppeal", new ViewAppeal(serviceFactory));
            pages.Add("DeleteAppeal", new DeleteAppeal(serviceFactory));
            pages.Add("CreateForm", new CreateForm(serviceFactory));
            pages.Add("FormList", new FormList(serviceFactory));
            pages.Add("ViewForm", new ViewForm(serviceFactory));
            pages.Add("DeleteForm", new DeleteForm(serviceFactory));
            pages.Add("Contact", new Contact());
            pages.Add("NotFoundError", new NotFoundError());

            
        }

        public static PageCreater Instance
        {
            get { return instance; }
        }

        private IBasePage FindPage(string path)
        {
            IBasePage page;
           
                try
                {
                    page = pages[path];

                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message + "метод FindPage класса PageCreater");
                    return pages["NotFoundError"];
                }          
            
            return page;  
        }       
    
        public Response PrepareResponse(string path, string method, IDictionary<string, string> param, string sessionId)
        {
            IBasePage page;
            Response response;

            if (Session.Instance.RegisterSessions.ContainsKey(sessionId))               
            {                
                User user = Session.Instance[sessionId];
                if(user.Authorized)
                {
                    page = FindPage(path);
                    response = (method == "GET") ? page.Get(param, sessionId) : page.Post(param, sessionId);
                }
                else
                {
                    if (path == "LogIn" || path == "Index")
                    {
                        page = FindPage(path);
                        response = (method == "GET") ? page.Get(param, sessionId) : page.Post(param, sessionId);
                    }
                    else
                    {
                        page = FindPage("LogIn");
                        response = page.Get(param, sessionId);
                    }
                }
            }
            else
            {
                Session.Instance.Add(sessionId, new User());
                page = FindPage("Index");
                response = page.Get(param, sessionId);
                response.SessionId = sessionId;
            }

           /* if (path == "LogOut")
                sessionId = null;

                page = FindPage(path);

            response = (method == "GET") ? page.Get(param, sessionId) : page.Post(param, sessionId);*/
            
            return response; 
        }

    }
}
