using LCRSTree;

LCRSTreeNode root = new LCRSTreeNode('A');

LCRSTreeNode B = new LCRSTreeNode('B');
LCRSTreeNode C = new LCRSTreeNode('C');
LCRSTreeNode D = new LCRSTreeNode('D');
LCRSTreeNode E = new LCRSTreeNode('E');
LCRSTreeNode F = new LCRSTreeNode('F');
LCRSTreeNode G = new LCRSTreeNode('G');
LCRSTreeNode H = new LCRSTreeNode('H');
LCRSTreeNode I = new LCRSTreeNode('I');
LCRSTreeNode J = new LCRSTreeNode('J');
LCRSTreeNode K = new LCRSTreeNode('K');

root.AddChildNode(B);
    B.AddChildNode(C);
    B.AddChildNode(D);
        D.AddChildNode(E);
        D.AddChildNode(F);

root.AddChildNode(G);
    G.AddChildNode(H);

root.AddChildNode(I);
    I.AddChildNode(J);
        J.AddChildNode(K);

Console.WriteLine(LCRSTreeNode.PrintTree(root.Node, 0));

Console.WriteLine(LCRSTreeNode.PrintNodesAtLevel(root.Node, 0, 3));


root.DestroyNode();