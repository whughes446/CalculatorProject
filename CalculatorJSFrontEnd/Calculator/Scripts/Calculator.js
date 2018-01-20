var CalculatorModel = (function () {
    function CalculatorModel() {
        this.Display = document.getElementById("CalculatorDisplay");
        this.ResetCalculator();
    }
    CalculatorModel.prototype.Calculate = function (operation) {
        this.CurrentCalculatorDisplay = Number(this.Display.value);
        if (operation != "CE") {
            // If no previous operation has been performed, store off current operation and calculator value to be evalatuated later
            if (this.LastOperation === "" || this.ClearDisplayOnNewEntry === "Y") {
                this.LastDisplayValue = this.CurrentCalculatorDisplay;
                this.LastOperation = operation;
            }
            else if (this.LastOperation === "+") {
                this.CurrentCalculatorDisplay = this.LastDisplayValue + this.CurrentCalculatorDisplay;
                this.LastDisplayValue = this.CurrentCalculatorDisplay;
            }
            else if (this.LastOperation === "-") {
                this.CurrentCalculatorDisplay = this.LastDisplayValue - this.CurrentCalculatorDisplay;
                this.LastDisplayValue = this.CurrentCalculatorDisplay;
            }
            else if (this.LastOperation === "*") {
                this.CurrentCalculatorDisplay = this.LastDisplayValue * this.CurrentCalculatorDisplay;
                this.LastDisplayValue = this.CurrentCalculatorDisplay;
            }
            else if (this.LastOperation === "/") {
                this.CurrentCalculatorDisplay = this.LastDisplayValue / this.CurrentCalculatorDisplay;
                this.LastDisplayValue = this.CurrentCalculatorDisplay;
            }
            if (operation === "=") {
                this.LastOperation = "";
            }
            else {
                this.LastOperation = operation;
            }
            this.ClearDisplayOnNewEntry = "Y";
        }
        else {
            this.ResetCalculator();
        }
        this.Display.value = this.CurrentCalculatorDisplay.toString();
    };
    CalculatorModel.prototype.ResetCalculator = function () {
        this.CurrentCalculatorDisplay = 0;
        this.LastOperation = "";
        this.LastDisplayValue = 0;
        this.ClearDisplayOnNewEntry = "N";
    };
    CalculatorModel.prototype.AddDigitToDisplay = function (numericvalue) {
        if (this.Display.value === "0" || this.ClearDisplayOnNewEntry === "Y") {
            this.Display.value = numericvalue.toString();
        }
        else {
            this.Display.value = this.Display.value + numericvalue.toString();
        }
        this.ClearDisplayOnNewEntry = "N";
    };
    return CalculatorModel;
}());
var CalculatorState = new CalculatorModel();
//function AddDigitToDisplay(numericvalue: number) {
//    var display = <HTMLInputElement>document.getElementById("CalculatorDisplay");
//    var clearentry = <HTMLInputElement>document.getElementById("ClearDisplayOnNewEntry");
//    if (display.value === "0" || clearentry.value === "Y") {
//        display.value = numericvalue.toString();
//        clearentry.value = "N";
//    }
//    else {
//        display.value = display.value + numericvalue.toString();
//        clearentry.value = "N";
//    }
//} 
//# sourceMappingURL=Calculator.js.map