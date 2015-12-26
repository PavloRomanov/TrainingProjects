using System;
using System.Runtime.Serialization;
using System.IO;
using Model.Entity;
using CollectionLibrary;
using System.Runtime.Serialization.Formatters.Binary;


namespace Model.Servise
{
    public class BaseService<T> where T : ModelBase
    {
        protected HashDictionary<Guid, T> hashElement;
        protected Object access;
        private string fileName;

        public BaseService(string path)
        {
            if (path == "")
                throw new ArgumentException("No way !!!");
            hashElement = new HashDictionary<Guid, T>();
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
                    //SerialContract();
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

       /* public void Delete(T model)  // можно передать просто ID
        {
            lock (access)
            {
                DeSerialContract();
                if (hashElement.Remove(model.Id))
                {
                    SerialContract();
                }
                else
                {
                    SerialContract();
                    throw new ArgumentException("Object not found");
                }
            }
        }*/

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
                    //SerialContract();
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
                    if (element.Key == model.Id)  //здесь изменение
                    {
                        hashElement[element.Key] = model;                                    
                        break;
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
                DataContractSerializer serial = new DataContractSerializer(typeof(HashDictionary<Guid, T>));

                serial.WriteObject(writing, hashElement);
                Console.WriteLine("Object serialized !!!");
            }
        }

        public void DeSerialContract()
        {
            if (!File.Exists(fileName))
            {
                hashElement = new HashDictionary<Guid, T>();
                return;
            }

            try
            {
                using (FileStream reading = new FileStream(fileName, FileMode.Open))
                {
                    DataContractSerializer deserial = new DataContractSerializer(typeof(HashDictionary<Guid, T>));
                    hashElement = (HashDictionary<Guid, T>)deserial.ReadObject(reading);
                    Console.WriteLine("DeSerialContract() pass ");
                }
            }

            catch (FileNotFoundException)
            {
            }
        }
 
        public HashDictionary<Guid, T> GetAll()
        {
            this.DeSerialContract();
            return hashElement;
        }

       
    }
}
