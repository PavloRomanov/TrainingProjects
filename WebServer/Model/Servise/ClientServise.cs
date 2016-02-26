using System;
using System.Runtime.Serialization;
using System.Data.Common;
using System.Data.SqlClient;
using Model.Entity;

namespace Model.Servise
{
    public class ClientServiсe : BaseService<Client>
    {
        public ClientServiсe(string path)
            : base(path)
        {
        }


    }
}
