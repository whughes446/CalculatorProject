using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorTrial.Models
{
    public class CalculatorModel
    {
        public double CurrentCalculatorDisplay { get; set; }
        public string LastOperation { get; set; }
        public double LastDisplayValue { get; set; }
        public String ClearDisplayOnNewEntry { get; set; }

        public CalculatorModel()
        {
            this.CurrentCalculatorDisplay = 0;
            this.LastOperation = "";
            this.LastDisplayValue = 0;
            this.ClearDisplayOnNewEntry = "N";
        }
    }
}