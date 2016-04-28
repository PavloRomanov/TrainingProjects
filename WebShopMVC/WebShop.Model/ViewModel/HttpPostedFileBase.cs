using System;
using System.IO;

namespace WebShop.Model.ViewModel
{
    public class HttpPostedFileBase 
    {

        public  int ContentLength
        {
            get
            {
                if (InputStream == null)
                {
                    return 0;
                }
                else
                {
                    long length = InputStream.Length;
                    if (length > int.MaxValue)
                    {
                        return int.MaxValue;
                    }
                    else
                    {
                        return (int)length;
                    }
                }
            }
        }

        public  string ContentType
        {
            get
            {
                return
                this._ContentType;
            }
            set { _ContentType = value; }
        }
        private string _ContentType;

       
        private string _FileName;

        public  Stream InputStream
        {
            get
            {
                if (_Stream == null)
                {
                    if (File.Exists(_FileName))
                    {
                        _Stream = new FileStream(_FileName, FileMode.Open,
                       FileAccess.Read, FileShare.Read);
                    }
                    else
                    {
                        _Stream = new MemoryStream();
                    }
                }
                return _Stream;
            }
        }
        private Stream _Stream;

      

         
        public  void SaveAs(String filename)
        {
            File.WriteAllBytes(filename, File.ReadAllBytes(_FileName));
        } // SaveAs
    }

}
