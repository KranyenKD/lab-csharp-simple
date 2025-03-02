using System;
using ComplexAlgebra;

namespace Calculus
{
    /// <summary>
    /// A calculator for <see cref="Complex"/> numbers, supporting 2 operations ('+', '-').
    /// The calculator visualizes a single value at a time.
    /// Users may change the currently shown value as many times as they like.
    /// Whenever an operation button is chosen, the calculator memorises the currently shown value and resets it.
    /// Before resetting, it performs any pending operation.
    /// Whenever the final result is requested, all pending operations are performed and the final result is shown.
    /// The calculator also supports resetting.
    /// </summary>
    ///
    /// HINT: model operations as constants
    /// HINT: model the following _public_ properties methods
    /// HINT: - a property/method for the currently shown value
    /// HINT: - a property/method to let the user request the final result
    /// HINT: - a property/method to let the user reset the calculator
    /// HINT: - a property/method to let the user request an operation
    /// HINT: - the usual ToString() method, which is helpful for debugging
    /// HINT: - you may exploit as many _private_ fields/methods/properties as you like
    ///
    /// TODO: implement the calculator class in such a way that the Program below works as expected
    class Calculator
    {
        public const char OperationPlus = '+';
        public const char OperationMinus = '-';
        
        private char? _operation = null;
        private Complex _pendingResult = new Complex(0,0);
        private bool _hasOP = false;
        
        public Complex Value { get; set; }
        public char? Operation
        {
            get => _operation;
            set
            {
                
                if (this._hasOP)
                {
                    this.ComputeResult();
                }
                this._pendingResult = this.Value;
                this._operation = value;
                this._hasOP = true;
            }
        }
        
        

        public void ComputeResult()
        {
            switch (this._operation)
                {
                    case OperationMinus:
                    {
                        Console.WriteLine(this._pendingResult);
                        this._pendingResult = this._pendingResult.Minus(Value);
                        this.Value = this._pendingResult;
                        this._operation = null;
                        break;
                    }

                    case OperationPlus:
                    {
                        this._pendingResult = this._pendingResult.Plus(Value);
                        this.Value = this._pendingResult;
                        this._operation = null;
                        break;
                    }
                        
                }
        }

        public void Reset()
        {
            this._operation = null;
            this.Value = null;
            this._hasOP = false;
            this._pendingResult = new Complex(0,0);
        }
        public override string ToString()
        {
            return this.Value + "," + this.Operation;
        }
        // TODO fill this class
    }
}