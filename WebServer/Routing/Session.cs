using System;
using CollectionLibrary;

namespace Routing
{
    public static class Session
    {
        public static MyHashTable<Guid, User> registerSessions = new MyHashTable<Guid, User>();

        public static void Add(Guid sessionId, User user)
        {
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
