using System;
using System.Runtime.Serialization;
using Model.Entity;

namespace Model.Servise
{
    public class ManagerServise : BaseService<Manager>
    {
        public ManagerServise(string path)
            : base(path)
        {
        }

        public Manager GetElementByLogin(string login, string password)
        {
            Manager manager;
            lock (access)
            {
                DeSerialContract();

                foreach(var item in hashElement)
                {
                    if(item.Value.Login == login & item.Value.Password == password)
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
