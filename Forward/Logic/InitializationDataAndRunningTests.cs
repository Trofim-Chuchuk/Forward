using System;
using System.IO;
using Forward.Motors;
using Forward.Motors.InternalCombustion;
using Forward.Stands;
using Newtonsoft.Json;

namespace Forward.Motor {
    public class InitializationDataAndRunningTests {
        public InternalCombustionEngine InternalCombustionEngine { get; set; }
        public TimeToOverheating TimeToOverheating { get; set; } = new TimeToOverheating();
        public MaxPower MaxPower { get; set; } = new();
        
        public InitializationDataAndRunningTests(string pathJson,double temperatureEnvironment ){
            try {
                var data = JsonConvert.DeserializeObject<InternalCombustionEngine>(File.ReadAllText(pathJson));
                if (data != null) {
                    InternalCombustionEngine = data;
                    InternalCombustionEngine.TemperatureEnvironment = temperatureEnvironment;
                }
                else {
                   Console.WriteLine("В папке при десирелизации не оказалось данных");
                   throw new Exception();
                }
                
            }
            catch (Exception e) {
                throw new Exception("что то пошло не так с десирелизацией");
            }
        }

        public void ImplementationStandOne(in IEngine engine){
            TimeToOverheating.Simulation(engine);
        }
        
        public void ImplementationStandTwo(in IEngine engine){
            MaxPower.Simulation(engine);
        }
        
        
        
        
        
        
        
    }
}