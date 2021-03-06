﻿using System;
using System.Runtime.Serialization;
using Model.Entity;
using System.Data;
using System.Collections.Generic;

namespace Model.Servise
{
    public class ManagerService : BaseService<Manager>, IManagerService
    {
        public ManagerService(string path)
            : base(path)
        {
        }


        public Manager GetElementByLogin(string login)
        {
            Manager manager;
            lock (access)
            {
                DeSerialContract();

                foreach(var item in allhashmodels)
                {
                    if(item.Value.Login == login)
                    {
                        manager = item.Value;
                        return manager;
                    }
                }                
            }
            return null;
        }
    }
}
