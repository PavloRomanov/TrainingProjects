using System;
using Model.Entity;

namespace Model.Servise
{
    public class ClientFileService : FileService<Client>
    {
        public ClientFileService(string path)
            : base(path)
        {
        }
    }
}
