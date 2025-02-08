using LinkedListStack;

namespace Calculator;

enum Symbol
{
    None = -1,
    LeftParenthesis = '(', RightParenthesis = ')',
    Plus = '+', Minus = '-',
    Multiply = '*', Divide = '/',
    Space = ' ', Operand
}

public class CalculatorClass
{
    private double _result = 0;
    private char[] NUMBER = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'];


    public double Calculate(string postFixExpression)
    {
        using var stack = new LinkedListStackClass();
        
        Symbol type = Symbol.None;
        int read = 0;
        int length = postFixExpression.Length;

        while (read < length)
        {
            string token = String.Empty;
            read += GetNextToken(postFixExpression[read..], ref token, ref type);
            
            if(type == Symbol.Space) continue;

            if (type == Symbol.Operand)
            {
                IntPtr newNode = stack.CreateNode(token);
                stack.Push(newNode);
            }
            else
            {
                var operatorNode = stack.Pop();
                var operator2 = double.Parse(operatorNode.Data);
                stack.DestroyNode(stack.NodeToIntPtr(operatorNode));

                operatorNode = stack.Pop();
                var operator1 = double.Parse(operatorNode.Data);
                stack.DestroyNode(stack.NodeToIntPtr(operatorNode));

                var tempResult = type switch
                {
                    Symbol.Plus => operator1 + operator2,
                    Symbol.Minus => operator1 - operator2,
                    Symbol.Multiply => operator1 * operator2,
                    Symbol.Divide => operator1 / operator2,
                    _ => throw new ArgumentOutOfRangeException()
                };

                var resultString = tempResult.ToString("G6");
                stack.Push(stack.CreateNode(resultString));
            }
        }

        var resultNode = stack.Pop();
        var result = double.Parse(resultNode.Data);
        
        stack.DestroyNode(stack.NodeToIntPtr(resultNode));

        return result;
    }
    
    
    private bool IsNumber(char cipher)
    {
        return Array.IndexOf(NUMBER, cipher) != -1;
    }

    public string GetPostfix(string InfixExpression)
    {
        string postfixexpression = String.Empty;
        
        Symbol type = Symbol.None;
        int position = 0;
        int length = InfixExpression.Length;

        using var stack = new LinkedListStackClass();

        while (position < length)
        {
            string token = String.Empty;
            position += GetNextToken(InfixExpression[position..], ref token, ref type);

            if (type == Symbol.Operand)
            {
                postfixexpression += token + " ";
            }
            else if (type == Symbol.RightParenthesis)
            {
                while (stack.IsEmpty == 0)
                {
                    Node Popped = stack.Pop();

                    if (Popped.Data[0] == (char)Symbol.LeftParenthesis)
                    {
                        stack.DestroyNode(stack.NodeToIntPtr(Popped));
                        break;
                    }
                    else
                    {
                        postfixexpression += Popped.Data;
                        stack.DestroyNode(stack.NodeToIntPtr(Popped));
                    }
                }
            }
            else
            {
                while (stack.IsEmpty == 0 && !IsPrior(stack.Top().Data[0], token[0]))
                {
                    Node Popped = stack.Pop();

                    if (Popped.Data[0] != (char)Symbol.LeftParenthesis)
                    {
                        postfixexpression += Popped.Data;
                    }
                    
                    stack.DestroyNode(stack.NodeToIntPtr(Popped));
                }
                
                stack.Push(stack.CreateNode(token));
            }
        }

        while (stack.IsEmpty == 0)
        {
            Node Popped = stack.Pop();

            if (Popped.Data[0] != (char)Symbol.LeftParenthesis)
            {
                postfixexpression += Popped.Data;
            }
            
            stack.DestroyNode(stack.NodeToIntPtr(Popped));
        }
        
        return postfixexpression;
    }

    private int GetNextToken(string expression, ref string token, ref Symbol type)
    {
        int i;
        for (i = 0; i < expression.Length; i++)
        {
            token += expression[i];
            
            if (IsNumber(expression[i]))
            {
                type = Symbol.Operand;

                if (i+1 < expression.Length && !IsNumber(expression[i + 1]))
                {
                    break;
                }
            }
            else
            {
                type = (Symbol)expression[i];
                break;
            }
        }
        
        return ++i;
    }


    private int GetPriority(Symbol oper, int instack)
    {
        int priority = oper switch
        {
            Symbol.LeftParenthesis => instack > 0 ? 3 : 0,
            Symbol.Multiply or Symbol.Divide => 1,
            Symbol.Plus or Symbol.Minus => 2,
            _ => -1
        };

        return priority;
    }

    private bool IsPrior(char OperatorInStack, char OperatorInToken)
    {
        return (GetPriority((Symbol)OperatorInStack, 1) > GetPriority((Symbol)OperatorInToken, 0));
    }
}