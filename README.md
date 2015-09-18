# Pimatic.NET

Use the Factories in Pimatic.NET.ServiceClient to connect to various Pimatic components.

Simple implementation example:

    /// <summary>
    /// The SensorGateway calls the PimaticVariableFactory and reads out the values of all sensors.
    /// </summary>
    public class PimSensorGateway
    {
        private readonly GetVariablesMessage _variables;

        public PimSensorGateway()
        {
            _variables = new PimaticVariableFactory().GetVariables();
        }

        [Obsolete("The device dev_temp1 has been deleted from Pimatic")]
        public string GetValue_dev_temp1_temperature()
        {
            return _variables.variables.SingleOrDefault(s => s.name == "dev_temp1.temperature").value.ToString();
        }
    }
