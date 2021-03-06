﻿using System;
using CollectionLibrary;
using System.Collections.Generic;

namespace Routing
{
    public class Session
    {
        private static readonly Session instance = new Session();
 
        private  IDictionary<string, User> _registerSessions;

        private Session()
        {
            _registerSessions = new Dictionary<string, User>();
        }        

        public static Session Instance
        {
            get { return instance; }
        }

        public IDictionary<string, User> RegisterSessions
        {
            get { return _registerSessions; }
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
            set
            {
                if (_registerSessions.ContainsKey(sessionId))
                {
                    _registerSessions[sessionId] = value;
                }
            }           
        }



    }


}
