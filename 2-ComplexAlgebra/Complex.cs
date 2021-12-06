using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method 
    public class Complex
    {
        // TODO: fill this class\
        public double Real = 0;
        public double Imaginary = 0;
        public double Modulus = 0;
        public double Phase = 0;
        public Complex(double a, double b)
        {
            this.Real = a;
            this.Imaginary = b;
            this.Modulus = this.GetModulus();
            this.Phase = this.GetPhase();

        }

        public override string ToString()
        {   
            if(this.Real == 0) return  " " + this.Imaginary + "i";
            if(this.Imaginary == 0) return  " " + this.Real;
            if(this.Imaginary == 1) return " " + this.Real +  "+ i";
            return " " + this.Real + " " + this.Imaginary + "i";
        }

        public double GetRealPart() => this.Real;
        
        public double GetImgPart() => this.Imaginary;
        
        public double GetModulus() => Math.Sqrt(Math.Pow(this.Real , 2) + Math.Pow(this.Imaginary , 2));

        public double GetPhase() => Math.Atan(this.Imaginary / this.Real);

        public Complex Plus(Complex a) => new Complex(this.GetRealPart() + a.GetRealPart() , this.GetImgPart() + a.GetImgPart() );
        
        public Complex Minus(Complex a) => new Complex(this.GetRealPart() - a.GetRealPart() , this.GetImgPart() - a.GetImgPart() );
        
        public Complex Complement() => new Complex(Real, -Imaginary);

        protected bool Equals(Complex other)
        {
            return Real == other.Real && Imaginary == other.Imaginary;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Complex) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }
    }
}