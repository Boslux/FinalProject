using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        //data mesaj ve durum
        public SuccessDataResult(T data, string message):base(data,true,message)
        {
            
        }
        //data ve durum
        public SuccessDataResult(T data):base(data,true)
        {

        }
        //mesaj ve durum
        public SuccessDataResult(string message):base(default,true,message)
        {

         
        }
        //sadece durum
        public SuccessDataResult():base(default,true)
        {
            
        }
    }
}
