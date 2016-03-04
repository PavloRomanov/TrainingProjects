using System;
using System.Runtime.Serialization;
using Model.Entity;

namespace Model.Servise
{
    public class FormServiсe : BaseService<Form>, IFormService
    {
        public FormServiсe(string path)
            : base(path)
        {

        }
    }
}
