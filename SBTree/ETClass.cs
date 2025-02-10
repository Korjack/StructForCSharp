
namespace SBTree;

public enum Symbol
{
    LeftParenthesis = '(', RightParenthesis = ')',
    Plus = '+', Minus = '-',
    Multiply = '*', Divide = '/',
    Space = ' ', Operand
}

public class ETClass
{
    private Stack<char> _stack;

    public ETClass()
    {
        _stack = new Stack<char>();
    }

    public double Evaluate(IntPtr root)
    {
        double result = 0;
        if (root == IntPtr.Zero) return result; // NULL 포인터이면 중단

        // 노드 포인터를 구조체로 변환
        SBTreeClass.SBTNode node = SBTreeClass.IntPtrToNode(root);

        // 노드가 가진 데이터 확인
        if (node.Data is '+' or '-' or '*' or '/')
        {
            // 다음 데이터 확인하여 숫자 결과 얻어옴
            double left = Evaluate(node.Left);
            double right = Evaluate(node.Right);

            if (node.Data == '+') result = left + right;
            else if (node.Data == '-') result = left - right;
            else if (node.Data == '*') result = left * right;
            else if (node.Data == '/') result = left / right;
        }
        else
        {
            // 숫자이면 double로 변환 후 반환
            result = double.Parse(node.Data.ToString());
        }

        return result;
    }

    public void BuildExpressionTree(ref string postfix, ref IntPtr nodePtr)
    {
        char token = postfix[^1];                           // 마지막 스트링 값
        postfix = postfix.Remove(postfix.Length - 1);       // 마지막 스트링 제외
        
        // 연산자인지 숫자인지 구별
        if (token is '+' or '-' or '*' or '/')
        {
            // 노드 생성 후, 생성된 노드 포인터를 구조체로 변환
            SBTreeClass node = new SBTreeClass(token);
            nodePtr = node.Node;
            SBTreeClass.SBTNode nodeStruct = SBTreeClass.IntPtrToNode(nodePtr);
            
            // 오른쪽부터 채운 후 왼쪽 채움
            BuildExpressionTree(ref postfix, ref nodeStruct.Right);
            BuildExpressionTree(ref postfix, ref nodeStruct.Left);

            // 해당 포인터에 변경된 노드 구조체를 포인터로 저장 (Marshal 특성때문)
            nodePtr = SBTreeClass.NodeToIntPtr(nodeStruct);
        }
        else
        {
            // 숫자면 노드를 생성하고 반환
            SBTreeClass node = new SBTreeClass(token);
            nodePtr = node.Node;
        }
    }
    
    public string GetPostFix(string infix)
    {
        string result = string.Empty;

        foreach (var c in infix)
        {
            if (!IsOperator(c))
            {
                result += c;
            }
            else
            {
                if (c == (char)Symbol.RightParenthesis)
                {
                    while (_stack.Count > 0)
                    {
                        char popped = _stack.Pop();

                        if (popped == (char)Symbol.LeftParenthesis)
                        {
                            break;
                        }
                    
                        result += popped;
                    }
                }
                else
                {
                    while (_stack.Count > 0 && !IsPriority(_stack.Peek(), c))
                    {
                        char popped = _stack.Pop();
                        if (popped != (char)Symbol.LeftParenthesis)
                        {
                            result += popped;
                        }
                    }
                    _stack.Push(c);
                }
            }
        }

        while (_stack.Count > 0)
        {
            char popped = _stack.Pop();
            result += popped;
        }

        return result;
    }

    private bool IsPriority(char operInStack, char operInToken)
    {
        return GetPriority((Symbol)operInStack, true) > GetPriority((Symbol)operInToken, false);
    }

    private int GetPriority(Symbol oper, bool inStack)
    {
        return oper switch
        {
            Symbol.LeftParenthesis => inStack ? 3 : 0,
            Symbol.Multiply => 1,
            Symbol.Divide => 1,
            Symbol.Plus => 2,
            Symbol.Minus => 2,
            _ => -1
        };
    }

    private bool IsOperator(char cipher)
    {
        return Array.IndexOf(['+', '-', '*', '/', '(', ')'], cipher) != -1;
    }
    
}