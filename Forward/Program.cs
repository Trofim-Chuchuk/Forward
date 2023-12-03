using System;
using Forward.Motor;

namespace Forward {
    class Program {
        static void Main(string[] args){
            Console.WriteLine("Введите температуру окружающей среды");
            try {
                var temp = Convert.ToDouble(Console.ReadLine());
                if (temp > 10000 || temp <= -273) {
                    throw new Exception();
                }
                var InitializationData = new InitializationData("../../../Data.json",temp);
                InitializationData.Realiz(InitializationData.InternalCombustionEngine);
                Console.ReadLine();
            }
            catch (FormatException) {
                throw new Exception("Ввели не коректные данные в температуру окружающей среды");
            }
            catch (Exception e) {
                throw new Exception("Температура не должна привышать 10000 по цельсию и ниже -273 по цельсию");
            }
          
        }
    }
}