using System;
using System.Collections.Generic;
using Forward.Motors;

namespace Forward.Stands {
    public class TimeToOverheating {
        public double EnginePower { get; set; } = new();
        public double Speed { get; set; } = new();
        public bool WWW { get; set; } = false;
        public double AbsoluteError { get; set; } = 10e-1;
        public bool Working { get; set; }
        public int MaxTime { get; set; } = 10000;
         
        public double HeatingRate(IEngine engine) 
            => engine.C  * (engine.TemperatureEnvironment - engine.TemperatureEngine);
        
        public double CoolingRate(IEngine engine,int index) 
            => engine.M[index] * engine.Hm + Math.Pow(engine.V[index], 2) * engine.Hv;

        public TimeToOverheating(){
            
        }
        public void LaunchSimulation(IEngine engine){
            
            int index = 0;
            bool Working = true;

            double power;
            
            engine.TimeWork = 0;
            engine.TemperatureEngine = engine.TemperatureEnvironment;
            
            double m = engine.M[0]; 
            double a = m / engine.I;
            double currentSpeed = engine.V[0];

            while (Working) { 
                engine.TimeWork++;
                currentSpeed+= a;
                
                if (index <engine. M.Length - 2) {
                    index += currentSpeed < engine.M[index + 1] ? 0 : 1;
                }
            
                // Апроксимация 
                double one = currentSpeed - engine.V[index];
                double two = engine.V[index + 1] - engine.V[index];
                double three = engine.M[index + 1] - engine.M[index];
                m =  one / two * three +engine.M[index];
                engine.TemperatureEngine+= HeatingRate(engine) + CoolingRate(engine,index);
               
               
                a = m / engine.I;
                
                power= m * currentSpeed/1000;

                if (power>EnginePower) {
                    EnginePower = power;
                    Speed = currentSpeed;
                }
                
                
                double eps = engine.OverheatTemperature - engine.TemperatureEngine;
                Working = eps > AbsoluteError && engine.TimeWork < MaxTime;
                if (!Working) {
                    WWW = true;
                    Console.WriteLine("Расчетные результаты критической температуры:\n" +
                                      ((engine.TimeWork < MaxTime) 
                                          ? "Двигатель не прошел проверку, время =" + engine.TimeWork
                                          : "Двигатель прошел испытание"));
                    break;
                }
            }
        }

        public void VVV(){
            if (WWW) {
                Console.WriteLine($"Максимальная мощность {EnginePower} кВт");
                Console.WriteLine($"Скорость {Speed}");
            }
            else {
                Console.WriteLine($"Замеров не было");
            }
           
        }
        
    }
}