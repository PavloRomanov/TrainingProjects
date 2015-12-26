using System;
using System.Runtime.Serialization;
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
