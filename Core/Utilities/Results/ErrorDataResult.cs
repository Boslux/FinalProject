using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //data mesaj ve durum
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        //data ve durum
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        //mesaj ve durum
        public ErrorDataResult(string message) : base(default, false, message)
        {


        }
        //sadece durum
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
