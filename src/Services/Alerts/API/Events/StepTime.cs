﻿namespace Microsoft.MecSolutionAccelerator.Services.Alerts.Events
{
    public class StepTime
    {
        public string StepName { get; set; }
        public long StepStart { get; set; }
        public long StepStop { get; set; }
        public long StepDuration { get; set; }
    }
}
