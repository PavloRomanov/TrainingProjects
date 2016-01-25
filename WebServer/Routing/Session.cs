using System;
using CollectionLibrary;

namespace Routing
{
    public class Session
    {
        private static readonly Session instance = new Session();

        private uint _sessionId;        
        private  MyHashTable<uint, User> _registerSessions;

        private Session()
        {
            _sessionId = 0;
            _registerSessions = new MyHashTable<uint, User>();
        }

        public uint SessionId
        {
            get { return _sessionId; }
        }

        public static Session Instance
        {
            get { return instance; }
        }

        public void Add(User user)
        {
            _sessionId++;
            _registerSessions.Add(_sessionId, user);
        }

        public void Remove (string key)
        {
            uint sessionId = Convert.ToUInt32(key);
            _registerSessions.Remove(sessionId);
        }

        public User this[uint sessionId]
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
