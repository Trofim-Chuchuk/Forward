using System;
using System.Collections.Generic;
using Forward.Motors;

namespace Forward.Stands {
    public class TimeToOverheating:СommonStand  {
        
        public void Simulation(IEngine engine){
            
            int index = 0;
            bool Working = true;
            
            engine.TemperatureEngine = engine.TemperatureEnvironment;
            double m = engine.M[0];
            double a = Acceleration(m, engine.I);
            double currentSpeed = engine.V[0];

            while (Working) {
                engine.TimeWork++;
                currentSpeed+= a;
                if (index <engine. M.Length - 2) {
                    index += currentSpeed < engine.V[index + 1] ? 0 : 1;
                }
                m = LinearInterpolation(index, currentSpeed, engine);
                engine.TemperatureEngine+= HeatingRate(engine) + CoolingRate(engine,index);
                a =Acceleration(m, engine.I);
                
                Working = ((engine.OverheatTemperature - engine.TemperatureEngine) > AbsolutError)
                          && engine.TimeWork < MaxTime;
                if (!Working) {
                    Console.WriteLine("Расчетные результаты критической температуры:\n" +
                                      ((engine.TimeWork < MaxTime) 
                                          ? "Двигатель не прошел проверку,время = " + engine.TimeWork + " сек"
                                          : "Двигатель прошел проверку"));
                    break;
                }
            }
        }

        

    }
}