function AddDigitToDisplay (numericvalue) {
    var display = document.getElementById("CalculatorDisplay");
    var clearentry = document.getElementById("ClearDisplayOnNewEntry");
    if (display.value === "0" || clearentry.value === "Y")
    {
        display.value = numericvalue.toString();
        clearentry.value = "N";
    }
    else 
    {
        display.value = display.value + numericvalue.toString();
        clearentry.value = "N";
    }
}