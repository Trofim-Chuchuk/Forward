using System;
using Forward.Motors;

namespace Forward.Stands {
    public abstract class СommonStand {
        public double AbsolutError { get; set; } = 10e-1;
        public int MaxTime { get; set; } = 10000;
         
        public double HeatingRate(IEngine engine) 
            => engine.C  * (engine.TemperatureEnvironment - engine.TemperatureEngine);
        public double CoolingRate(IEngine engine,int index) 
            => engine.M[index] * engine.Hm + Math.Pow(engine.V[index], 2) * engine.Hv;
        public double LinearInterpolation(int index,double currentSpeed,IEngine engine){
            double one = currentSpeed - engine.V[index];
            double two = engine.V[index + 1] - engine.V[index];
            double three = engine.M[index + 1] - engine.M[index];
            return one / two * three + engine.M[index];
        } 
        public double Acceleration(double m, double i){
            return m / i;
        }
        public double Power(double m, double currentSpeed){
            return m * currentSpeed/1000;
        }
    }
}