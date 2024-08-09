using System;

public class Class1
{
	public Class1()
	{
		public static void Add(string num1, string num2)
		{
			double a;
			double b;

			if((!Double.TryParse(num1, out a)|| !Double.TryParse(num2, out b))) { return null; }
			return (a + b).ToString();
		}

        public static void Sub(string num1, string num2)
        {
            double a;
            double b;

            if (!Double.TryParse(num1, out a) || !Double.TryParse(num2, out b)) { return null; }
            return (a - b).ToString();
        }

        public static void Mul(string num1, string num2)
        {
            double a;
            double b;

            if (!Double.TryParse(num1, out a) || !Double.TryParse(num2, out b)) { return null; }
            return (a * b).ToString();
        }

        public static void Dev(string num1, string num2)
        {
            double a;
            double b;

            if (!Double.TryParse(num1, out a) || !Double.TryParse(num2, out b)) { return null; }
            return (a / b).ToString();
        }

        public static void Sqr(string num1)
        {
            double a;

            if(!double.TryParse(num1,out a)) { return; }
            return Math.Sqrt(a).ToString();
        }

        public static void Pow(string num1)
        {
            double a;

            if (!double.TryParse(num1, out a)) { return; }
            return Math.Pow(a, 2).ToString();
        }

        public static void OneDev(string num1)
        {
            double a;

            if (!double.TryParse(num1, out a)) { return; }
            return Math.OneDev(1 / a).ToString();
        }
    }
}
