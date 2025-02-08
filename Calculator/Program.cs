using Calculator;

var calculator = new CalculatorClass();

string postfix = calculator.GetPostfix("1+3.334/(4.28*(110-7729))");
Console.WriteLine($"PostFix: {postfix}");

Console.WriteLine($"Calculation Result: {calculator.Calculate(postfix)}");