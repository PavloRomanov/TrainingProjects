using System;
using System.Runtime.Serialization;
using System.IO;
using Model.Entity;
using CollectionLibrary;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace Model.Servise
{
    public abstract class BaseService<T> : IService<T> where T : ModelBase
    {
        protected Dictionary<Guid, T> allhashmodels;
        protected Object access;
        private string fileName;        

        public BaseService(string path)
        {
            if (path == "")
                throw new ArgumentException("No way !!!");
            allhashmodels = new Dictionary<Guid, T>();
            access = new Object();
            fileName = path;
        }

        public virtual T GetElement(Guid key)
        {
            T rez;
            lock (access)
            {
                DeSerialContract();

                if (!allhashmodels.ContainsKey(key))
                    throw new ArgumentException("Object not found");
                else
                {
                    rez = allhashmodels[key];
                }
            }
            return rez;
        }

        public virtual void Add(T model)
        {            
            lock (access)
            {
                DeSerialContract();
                allhashmodels.Add(model.Id, model);
                SerialContract();
            }
        }

       public virtual void Delete(Guid id)  
        {
            lock (access)
            {
                DeSerialContract();
                if (allhashmodels.Remove(id))
                {
                    SerialContract();
                }
                else
                {
                    throw new ArgumentException("Object not found");
                }
            }
        }

        public virtual void Update(T model)
        {
            if (model.Id == null)
                throw new ArgumentNullException();
            lock (access)
            {
                DeSerialContract();

                foreach (var element in allhashmodels)
                {
                    if (allhashmodels.ContainsKey(model.Id))
                    {
                        if (element.Key == model.Id)
                        {
                            allhashmodels[element.Key] = model;
                            break;
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Object not found");
                    }                  
                }
                SerialContract();
            }
        }

        public void SerialContract()
        {
            using (FileStream writing = new FileStream(fileName, FileMode.Create))
            {
                DataContractSerializer serial = new DataContractSerializer(typeof(Dictionary<Guid, T>));
                serial.WriteObject(writing, allhashmodels);
                Console.WriteLine("Object serialized !!!");
                writing.Flush();
            }
        }

        public void DeSerialContract()
        {
            if (!File.Exists(fileName))
            {
                allhashmodels = new Dictionary<Guid, T>();
                return;
            }

            try
            {
                using (FileStream reading = new FileStream(fileName, FileMode.Open))
                {
                    DataContractSerializer deserial = new DataContractSerializer(typeof(Dictionary<Guid, T>));
                    allhashmodels = (Dictionary<Guid, T>)deserial.ReadObject(reading);
                    Console.WriteLine("DeSerialContract() pass ");
                }
            }

            catch (FileNotFoundException)
            {
            }
        }
 
        public virtual Dictionary<Guid, T> GetAll()
        {
            this.DeSerialContract();
            return allhashmodels;
        }

       
    }
}
