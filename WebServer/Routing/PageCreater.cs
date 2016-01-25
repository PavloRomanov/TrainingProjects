using System;
using System.Text;
using System.Collections.Generic;
using CollectionLibrary;
using Routing.Pages;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Routing
{
    public class PageCreater
    {
        private static readonly PageCreater instance = new PageCreater();
        public MyHashTable<string, IBasePage> pages;
        

        private PageCreater()
        {
            pages = new MyHashTable<string, IBasePage>();
            pages.Add("Index", new Index());
            pages.Add("CreateClient", new CreateClient());
            pages.Add("DeleteClient", new DeleteClient());
            pages.Add("UpdateClient", new UpdateClient());
            pages.Add("ClientsList", new ClientsList());
            pages.Add("ViewClient", new ViewClient());
            pages.Add("LogIn", new LogIn());
            pages.Add("LogOut", new LogOut());
            pages.Add("CreateManager", new CreateManager());
            pages.Add("ManagersList", new ManagersList());
            pages.Add("ViewManager", new ViewManager());
            pages.Add("UpdateManager", new UpdateManager());
            pages.Add("DeleteManager", new DeleteManager());
            pages.Add("CreateAppeal", new CreateAppeal());
            pages.Add("CreateForm", new CreateForm());
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
                    Console.WriteLine(ex.Message);
                    return pages["NotFoundError"];
                }          
            
            return page;  
        }       
    
        public Response PrepareResponse(string path, string method, MyHashTable<string, string> param, MyHashTable<string, string> cookies)
        {
            IBasePage page;
            Response response;


            if (path == "Index")
            {
                page = FindPage("Index");
                response = page.Get(param, cookies);
            }
            else if(cookies == null || !cookies.ContainsKey(" sessionId"))
            {
                page = FindPage("LogIn");
                response = page.Get(param, cookies);
            }
            else
            {
                page = FindPage(path);
                response = (method == "GET") ? page.Get(param, cookies) : page.Post(param, cookies);
            }

            return response; 
        }

    }
}
