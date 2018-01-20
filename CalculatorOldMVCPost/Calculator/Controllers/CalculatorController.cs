using CalculatorTrial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculatorTrial.Controllers
{
    public class CalculatorController : Controller
    {

        // GET: Calculator
        public ActionResult Index()
        {

            return View("Calculator", new CalculatorModel());
        }

        [HttpPost]
        public ActionResult Calculate(String CalculatorDisplay, String LastOperation, String LastDisplayValue, String ClearDisplayOnNewEntry, String OperationButton)
        {
            var CurrentCalculatorState = new CalculatorModel();
            CurrentCalculatorState.CurrentCalculatorDisplay = Convert.ToDouble(CalculatorDisplay);
            CurrentCalculatorState.LastOperation = LastOperation;
            CurrentCalculatorState.LastDisplayValue = Convert.ToDouble(LastDisplayValue);
            CurrentCalculatorState.ClearDisplayOnNewEntry = ClearDisplayOnNewEntry;

            var NewCalculatorState = EvaluateCalculatorExpression(CurrentCalculatorState, OperationButton);
            return View("Calculator", NewCalculatorState);
        }

        private CalculatorModel EvaluateCalculatorExpression(CalculatorModel CalculatorState, String Operation)
        {
            var NewCalculatorState = new CalculatorModel();
            if (Operation != "CE")
            {
                if (CalculatorState.LastOperation == "" || CalculatorState.ClearDisplayOnNewEntry == "Y")
                {
                    NewCalculatorState.CurrentCalculatorDisplay = CalculatorState.CurrentCalculatorDisplay;
                    NewCalculatorState.LastDisplayValue = CalculatorState.CurrentCalculatorDisplay;
                    NewCalculatorState.LastOperation = Operation;
                }

                    if (CalculatorState.LastOperation == "+")
                    {
                        NewCalculatorState.CurrentCalculatorDisplay = CalculatorState.LastDisplayValue + CalculatorState.CurrentCalculatorDisplay;
                        NewCalculatorState.LastDisplayValue = NewCalculatorState.CurrentCalculatorDisplay;
                    }
                    else if (CalculatorState.LastOperation == "-")
                    {
                        NewCalculatorState.CurrentCalculatorDisplay = CalculatorState.LastDisplayValue - CalculatorState.CurrentCalculatorDisplay;
                        NewCalculatorState.LastDisplayValue = NewCalculatorState.CurrentCalculatorDisplay;
                    }
                    else if (CalculatorState.LastOperation == "*")
                    {
                        NewCalculatorState.CurrentCalculatorDisplay = CalculatorState.LastDisplayValue * CalculatorState.CurrentCalculatorDisplay;
                        NewCalculatorState.LastDisplayValue = NewCalculatorState.CurrentCalculatorDisplay;
                    }
                    else if (CalculatorState.LastOperation == "/")
                    {
                        NewCalculatorState.CurrentCalculatorDisplay = CalculatorState.LastDisplayValue / CalculatorState.CurrentCalculatorDisplay;
                        NewCalculatorState.LastDisplayValue = NewCalculatorState.CurrentCalculatorDisplay;

                }
                if (Operation == "=")
                {
                    NewCalculatorState.LastOperation = "";
                    NewCalculatorState.ClearDisplayOnNewEntry = "N";
                }
                else
                {
                    NewCalculatorState.LastOperation = Operation;
                    NewCalculatorState.ClearDisplayOnNewEntry = "Y";
                }                
                
            }

            return NewCalculatorState;
        }
    }
}

