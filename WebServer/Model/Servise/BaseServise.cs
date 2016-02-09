using System;
using System.Runtime.Serialization;
using System.IO;
using Model.Entity;
using CollectionLibrary;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace Model.Servise
{
    public class BaseService<T> where T : ModelBase
    {
        protected Dictionary<Guid, T> hashElement;
        protected Object access;
        private string fileName;

        public BaseService(string path)
        {
            if (path == "")
                throw new ArgumentException("No way !!!");
            hashElement = new Dictionary<Guid, T>();
            access = new Object();
            fileName = path;
        }

        public T GetElement(Guid key)
        {
            T rez;
            lock (access)
            {
                DeSerialContract();

                if (!hashElement.ContainsKey(key))
                    throw new ArgumentException("Object not found");
                else
                {
                    rez = hashElement[key];
                }
            }
            return rez;
        }

        public void Add(T model)
        {            
            lock (access)
            {
                DeSerialContract();
                hashElement.Add(model.Id, model);
                SerialContract();
            }
        }

       public void Delete(Guid id)  
        {
            lock (access)
            {
                DeSerialContract();
                if (hashElement.Remove(id))
                {
                    SerialContract();
                }
                else
                {
                    throw new ArgumentException("Object not found");
                }
            }
        }

        public void Update(T model)
        {
            if (model.Id == null)
                throw new ArgumentNullException();
            lock (access)
            {
                DeSerialContract();

                foreach (var element in hashElement)
                { 
                    if(hashElement.ContainsKey(model.Id))
                    {
                        if (element.Key == model.Id)
                        {
                            hashElement[element.Key] = model;
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
                serial.WriteObject(writing, hashElement);
                Console.WriteLine("Object serialized !!!");
            }
        }

        public void DeSerialContract()
        {
            if (!File.Exists(fileName))
            {
                hashElement = new Dictionary<Guid, T>();
                return;
            }

            try
            {
                using (FileStream reading = new FileStream(fileName, FileMode.Open))
                {
                    DataContractSerializer deserial = new DataContractSerializer(typeof(Dictionary<Guid, T>));
                    hashElement = (Dictionary<Guid, T>)deserial.ReadObject(reading);
                    Console.WriteLine("DeSerialContract() pass ");
                }
            }

            catch (FileNotFoundException)
            {
            }
        }
 
        public Dictionary<Guid, T> GetAll()
        {
            this.DeSerialContract();
            return hashElement;
        }

       
    }
}
