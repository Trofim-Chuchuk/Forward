using System;
using Forward.Motor;
using Forward.Motors;

namespace Forward.Stands {
    public class MaxPower:СommonStand {
        public double EnginePower { get; set; } = new();
        public double Speed { get; set; } = new();
        
        /// <summary>
        /// Симуляция максимальной мощности.
        /// </summary>
        /// <param name="engine">Тестируемый мотор</param>
        public void Simulation(IEngine engine){
            
            int index = 0;
            bool Working = true;
            engine.TemperatureEngine = engine.TemperatureEnvironment;
        
            
            double m = engine.M[0]; 
            double a =Acceleration(m, engine.I);
            double currentSpeed = engine.V[0];
            engine.TimeWork = 0;

            while (Working) {

                engine.TimeWork++;
                currentSpeed+= a;
                
                if (index <engine. M.Length - 2) {
                    index += currentSpeed < engine.V[index + 1] ? 0 : 1;
                }
                
                m = LinearInterpolation(index, currentSpeed, engine);
                engine.TemperatureEngine+= HeatingRate(engine) + CoolingRate(engine,index);
                a = Acceleration(m, engine.I);
                
                var power = Power(m, currentSpeed);
                if (power>EnginePower) {
                    EnginePower = power;
                    Speed = currentSpeed;
                }
                
                double eps = engine.OverheatTemperature - engine.TemperatureEngine;
                Working = eps > AbsolutError && engine.TimeWork < MaxTime;
                if (!Working) {
                    Console.WriteLine($"Максимальная мощность {EnginePower} кВт");
                    Console.WriteLine($"Скорость {Speed}  радиан/сек");
                    break;
                }
            }
        }
    }
    
    
     
    
}