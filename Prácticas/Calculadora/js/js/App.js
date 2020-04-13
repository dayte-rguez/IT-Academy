class App {
    constructor() {
        this.FirstNumber = null;
        /* Allow CurrentOperation to be nullable, so when any math operation sign is pressed, 
         * it will be possible to know wheter there is an operation in progress (CurrentOperation not null) 
         * or not (CurrentOperation is null)*/
        this.CurrentOperation = null;
        this.RunningOp = false; // Initialize operation status flag
    }

    //#region Math Functions

    TryReadCurrentNumber() {
        /* Create and object to return both the number and if the function 
         * succeeded to read it*/
        let input = { IsSuccess: false, Value: null }

        input.Value = Number(TbResult.value);
        /* A fastest alternative to convert string to number
         * input.value = TbResult.value * 1; */
        input.IsSuccess = input.Value !== NaN;

        return input;
    }

    ApplyCurrentOp(aSecondNum) {
        switch (this.CurrentOperation) {
            case Operations.Add:
                /* Add and get ready for next operation*/
                this.FirstNumber += aSecondNum;
                TbResult.value = this.FirstNumber;
                break;
            case Operations.Subs:
                /* Substract and get ready for next operation*/
                this.FirstNumber -= aSecondNum;
                TbResult.value = this.FirstNumber;
                break;
            case Operations.Mult:
                /* Multiply and get ready for next operation*/
                this.FirstNumber *= aSecondNum;
                TbResult.value = this.FirstNumber;
                break;
            case Operations.Div:
                /* Divide and get ready for next operation */
                this.FirstNumber /= aSecondNum;
                TbResult.value = this.FirstNumber;
                break;
            default:
                break;
        }
    }

    CalcInProgress() {
        /* Try to read second number 
         * The let statement declares variables that are limited to a scope of a block statement, 
         * or expression on which it is used. 
         * Its use is more recommended than the use of var
         * */
        let conversionResult = this.TryReadCurrentNumber();
        if (conversionResult.IsSuccess) {
            /* Keep calculating conditions*/
            this.RunningOp = true;
            /* Update label with operation progress */
            LbProgressOp.innerHTML += conversionResult.Value;
            /* Calculate */
            this.ApplyCurrentOp(conversionResult.Value);
        }
    }

    DoTheMath(aOperation) {
        let conversionResult = this.TryReadCurrentNumber();
        if (conversionResult.IsSuccess) {
            this.FirstNumber = conversionResult.Value;
            switch (aOperation) {
                case "add":
                    this.CurrentOperation = Operations.Add;
                    break;
                case "subs":
                    this.CurrentOperation = Operations.Subs;
                    break;
                case "mult":
                    this.CurrentOperation = Operations.Mult;
                    break;
                case "div":
                    this.CurrentOperation = Operations.Div;
                    break;
                default:
                    break;
            }
            /* Update label with first number */
            LbProgressOp.innerHTML = conversionResult.Value;

            /* Flag operation in progress */
            this.RunningOp = true;
        }
    }

    Sum() {
        this.DoTheMath("add");
    }

    Substraction() {
        this.DoTheMath("subs");
    }

    Multiplication() {
        this.DoTheMath("mult");
    }

    Division() {
        this.DoTheMath("div");
    }

    //#endregion Math Functions

    //#region Calculator number buttons
    PressNum(aNum) {
        /* When calculating, clean the textbox to receive the digits of second number */
        if (this.RunningOp) {
            TbResult.value = aNum;
            this.RunningOp = false; //Allow to add more digits
        } else {
            TbResult.value += aNum; //
        }
    }

    //#endregion Calculator number buttons

    //#region Calculator function buttons

    PressCalc() {
        let conversionResult = this.TryReadCurrentNumber();
        if (conversionResult.IsSuccess) {
            /* Prepare for next operation: flag a brand new calculation can take place*/
            this.RunningOp = false;
            /* Update label with operation progress */
            LbProgressOp.innerHTML += " " + conversionResult.Value + " = ";
            /* Calculate */
            this.ApplyCurrentOp(conversionResult.Value);
            /* Clean current operation since operation is finished */
            this.CurrentOperation = null;
        }
    }

    PressAdd() {
        /* If an operation is in progress, get the previous result and store it in FirstNumber */
        if (this.CurrentOperation !== null) {
            this.CalcInProgress();
            this.CurrentOperation = Operations.Add;
        } else {
            this.Sum();
        }
        /* Update label with the operation */
        LbProgressOp.innerHTML += " + ";
    }

    PressSubs() {
        /* If an operation is in progress, get the previous result and store it in FirstNumber */
        if (this.CurrentOperation !== null) {
            this.CalcInProgress();
            this.CurrentOperation = Operations.Subs;
        } else {
            this.Substraction();
        }
        /* Update label with the operation */
        LbProgressOp.innerHTML += " - ";
    }

    PressMult() {
        /* If an operation is in progress, get the previous result and store it in FirstNumber */
        if (this.CurrentOperation !== null) {
            this.CalcInProgress();
            this.CurrentOperation = Operations.Mult;
        } else {
            this.Multiplication();
        }
        /* Update label with the operation */
        LbProgressOp.innerHTML += " * ";
    }

    PressDiv() {
        /* If an operation is in progress, get the previous result and store it in FirstNumber */
        if (this.CurrentOperation !== null) {
            this.CalcInProgress();
            this.CurrentOperation = Operations.Div;
        } else {
            this.Division();
        }
        /* Update label with the operation */
        LbProgressOp.innerHTML += " / ";
    }

    //#endregion Calculator function buttons
}

let app = new App();

/* Don't use 0 as an enumeration number. Unless it's used for something that has not been set.
 * JS treats false || undefined || null || 0 || "" || '' || NaN all as the same value 
 * when compared using == */
let Operations = {
    Add: 1,
    Subs: 2,
    Mult: 3,
    Div: 4
};