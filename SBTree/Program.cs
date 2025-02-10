using SBTree;

class Program
{
    public void SBTreeTest()
    {
        SBTreeClass A = new SBTreeClass('A');
        SBTreeClass B = new SBTreeClass('B');
        SBTreeClass C = new SBTreeClass('C');
        SBTreeClass D = new SBTreeClass('D');
        SBTreeClass E = new SBTreeClass('E');
        SBTreeClass F = new SBTreeClass('F');
        SBTreeClass G = new SBTreeClass('G');

        A.AddLeft(B);
        B.AddLeft(C);
        B.AddRight(D);

        A.AddRight(E);
        E.AddLeft(F);
        E.AddRight(G);

        // 전위 방식
        Console.WriteLine($"Preorder ...\n{SBTreeClass.PreorderPrintTree(A.Node)}\n");

        // 중위 방식
        Console.WriteLine($"Inorder ...\n{SBTreeClass.InorderPrintTree(A.Node)}\n");

        // 후위 방식
        Console.WriteLine($"Postorder ...\n{SBTreeClass.PostorderPrintTree(A.Node)}\n");

        // 트리 삭제
        SBTreeClass.DestroyTree(A);
    }

    public static void Main(string[] args)
    {
        ETClass etClass = new ETClass();

        SBTreeClass root = new SBTreeClass();
        string postfix = etClass.GetPostFix("(7*1)/(5-2)");
        
        etClass.BuildExpressionTree(ref postfix, ref root.Node);
        
        Console.WriteLine($"Evaulation Result: {etClass.Evaluate(root.Node)}");
        
        SBTreeClass.DestroyTree(root);
    }
}