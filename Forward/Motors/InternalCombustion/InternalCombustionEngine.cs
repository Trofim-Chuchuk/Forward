using System;

namespace Forward.Motors.InternalCombustion  {
    
    public class InternalCombustionEngine:IEngine {
        
        /// <summary>
        /// Момент инерции.
        /// </summary>
        public  double I { get; set; }
        
        /// <summary>
        /// Крутящий момент.
        /// </summary>
        public int[] M { get; set; }
        
        /// <summary>
        /// Cкорость вращения.
        /// </summary>
        public int[] V { get; set; }
        
        /// <summary>
        /// Температура перегрева.
        /// </summary>
        public double OverheatTemperature { get; set; }
        
        /// <summary>
        /// Коэффициент зависимости скорости нагрева от крутящего момента.
        /// </summary>
        public double Hm { get; set; }
        
        /// <summary>
        /// Коэффициент зависимости скорости нагрева от скорости вращения коленвала.
        /// </summary>
        public double Hv { get; set; }
        
        /// <summary>
        /// Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды.
        /// </summary>
        public double C { get; set; }
        
        
        public int TimeWork { get; set; }
        public double TemperatureEnvironment { get; set; }
        public double TemperatureEngine { get; set; }   
        
       
    }
}