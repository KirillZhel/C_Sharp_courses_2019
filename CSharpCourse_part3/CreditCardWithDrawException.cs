using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part3
{
    //создание нестандартных исключений
    //обязаны наследовать от Exception
    internal class CreditCardWithDrawException : Exception
    {
        //пробрасываются и обрабатываются абсолютно так же, как и обычные
    }
}
