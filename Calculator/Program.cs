// Generic Calculator class
class Calculator<T>
{
    // Delegates for arithmetic operations
    public delegate T AddDelegate(T a, T b);
    public delegate T SubtractDelegate(T a, T b);
    public delegate T MultiplyDelegate(T a, T b);
    public delegate T DivideDelegate(T a, T b);

    // Methods using delegates to perform arithmetic operations
    public T Add(T a, T b, AddDelegate addDelegate)
    {
        return addDelegate(a, b);
    }

    public T Subtract(T a, T b, SubtractDelegate subtractDelegate)
    {
        return subtractDelegate(a, b);
    }

    public T Multiply(T a, T b, MultiplyDelegate multiplyDelegate)
    {
        return multiplyDelegate(a, b);
    }

    public T Divide(T a, T b, DivideDelegate divideDelegate)
    {
        if (EqualityComparer<T>.Default.Equals(b, default(T)))
        {
            Console.WriteLine("Cannot divide by zero.");
            return default(T);
        }
        return divideDelegate(a, b);
    }
}

class Program
{
    static void Main()
    {
        // Example usage

        // For integers
        Calculator<int> intCalculator = new Calculator<int>();

        Calculator<int>.AddDelegate intAdd = (a, b) => a + b;
        Calculator<int>.SubtractDelegate intSubtract = (a, b) => a - b;
        Calculator<int>.MultiplyDelegate intMultiply = (a, b) => a * b;
        Calculator<int>.DivideDelegate intDivide = (a, b) =>
        {
            if (b == 0)
            {
                Console.WriteLine("Cannot divide by zero.");
                return 0;
            }
            return a / b;
        };

        Console.WriteLine("Integer Calculator:");
        Console.WriteLine($"Addition: {intCalculator.Add(5, 3, intAdd)}");
        Console.WriteLine($"Subtraction: {intCalculator.Subtract(5, 3, intSubtract)}");
        Console.WriteLine($"Multiplication: {intCalculator.Multiply(5, 3, intMultiply)}");
        Console.WriteLine($"Division: {intCalculator.Divide(5, 3, intDivide)}");

        // For doubles
        Calculator<double> doubleCalculator = new Calculator<double>();

        Calculator<double>.AddDelegate doubleAdd = (a, b) => a + b;
        Calculator<double>.SubtractDelegate doubleSubtract = (a, b) => a - b;
        Calculator<double>.MultiplyDelegate doubleMultiply = (a, b) => a * b;
        Calculator<double>.DivideDelegate doubleDivide = (a, b) =>
        {
            if (b == 0)
            {
                Console.WriteLine("Cannot divide by zero.");
                return 0.0;
            }
            return a / b;
        };

        Console.WriteLine("\nDouble Calculator:");
        Console.WriteLine($"Addition: {doubleCalculator.Add(5.0, 3.0, doubleAdd)}");
        Console.WriteLine($"Subtraction: {doubleCalculator.Subtract(5.0, 3.0, doubleSubtract)}");
        Console.WriteLine($"Multiplication: {doubleCalculator.Multiply(5.0, 3.0, doubleMultiply)}");
        Console.WriteLine($"Division: {doubleCalculator.Divide(5.0, 3.0, doubleDivide)}");

        // For floats
        Calculator<float> floatCalculator = new Calculator<float>();

        Calculator<float>.AddDelegate floatAdd = (a, b) => a + b;
        Calculator<float>.SubtractDelegate floatSubtract = (a, b) => a - b;
        Calculator<float>.MultiplyDelegate floatMultiply = (a, b) => a * b;
        Calculator<float>.DivideDelegate floatDivide = (a, b) =>
        {
            if (b == 0)
            {
                Console.WriteLine("Cannot divide by zero.");
                return 0.0f;
            }
            return a / b;
        };

        Console.WriteLine("\nFloat Calculator:");
        Console.WriteLine($"Addition: {floatCalculator.Add(5.0f, 3.0f, floatAdd)}");
        Console.WriteLine($"Subtraction: {floatCalculator.Subtract(5.0f, 3.0f, floatSubtract)}");
        Console.WriteLine($"Multiplication: {floatCalculator.Multiply(5.0f, 3.0f, floatMultiply)}");
        Console.WriteLine($"Division: {floatCalculator.Divide(5.0f, 3.0f, floatDivide)}");
    }
}
