using System;
using CollectionLibrary;

namespace Routing
{
    public class Session
    {
        private static readonly Session instance = new Session();
 
        private  MyHashTable<string, User> _registerSessions;

        private Session()
        {
            _registerSessions = new MyHashTable<string, User>();
        }
        

        public static Session Instance
        {
            get { return instance; }
        }

        public void Add(string sessionId, User user)
        {
            _registerSessions.Add(sessionId, user);
        }

        public void Remove (string sessionId)
        {            
            _registerSessions.Remove(sessionId);
        }

        public User this[string sessionId]
        {
            get
            {
                if(_registerSessions.ContainsKey(sessionId))
                {
                    return _registerSessions[sessionId];
                }
                return null;
            }           
        }



    }


}
