using System;
using System.Runtime.Serialization;
using Model.Entity;

namespace Model.Servise
{
    public class FormServiсe : FileService<Form>
    {
        public FormServiсe(string path)
            : base(path)
        {

        }
    }
}
