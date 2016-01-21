using System;
using CollectionLibrary;

namespace Routing
{
    public static class Session
    {
        private static int count = 0;
        public static string sessionId;
        public static MyHashTable<string, User> registerSessions = new MyHashTable<string, User>();

        public static void Add(User user)
        {
            count++;
            sessionId = count.ToString();
            registerSessions.Add(sessionId, user);
        }

    }


    /*public  class Session
    {
        private static readonly Session instance = new Session();

        public MyHashTable<Guid, User> registerSessions;

        private Session()
        {
            registerSessions = new MyHashTable<Guid, User>();
        }

        public static Session Instance
        {
            get { return instance; }
        }

        public void Add(Guid sessionId, User user)
        {
            registerSessions.Add(sessionId, user);    
        }


        public static void Add(MyHashTable<string, string> cookies, User user)
        {
           
        }

    }*/
}
