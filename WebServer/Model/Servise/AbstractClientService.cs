using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Model.Entity;

namespace Model.Servise
{
    public abstract class AbstractClientService :  IClientService
    {
        public abstract Client GetElement(Guid key);
        public abstract Dictionary<Guid, Client> GetAll();
        public abstract void Add(Client model);
        public abstract void Delete(Guid id);
        public abstract void Update(Client model);

        protected abstract Client InitializeNewEntity(SqlDataReader reader);
        protected abstract Dictionary<Guid, Client> InitializeListNewEntitys(SqlDataReader reader); 
        public abstract Client FillFieldsOfModels(SqlDataReader reader);   
       
    }
}
