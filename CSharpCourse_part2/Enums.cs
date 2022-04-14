using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    //Перечисления неявно наследуются от int
    //(можно явно наследоваться от byte)
    //каждому элементу перечисления соответствует число
    //по умолчанию от 0 и далее
    public enum TrafficLight
    {
        Red,
        Yellow,
        Green
    }


    public enum Race
    {
        //явная ассоциация с числом (можно задать любые числа)
        Elf = 30,
        Ork = 40,
        Terrain = 20
    }
}
