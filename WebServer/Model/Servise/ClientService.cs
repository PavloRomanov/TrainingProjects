using System;
using Model.Entity;

namespace Model.Servise
{
    public class ClientService : BaseService<Client>
    {
        public ClientService(string path)
            : base(path)
        {
        }
    }
}
