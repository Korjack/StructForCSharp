using System.Runtime.InteropServices;

namespace LCRSTree;

public class LCRSTreeNode
{
    public IntPtr Node;
    
    public LCRSTreeNode(char data)
    {
        Node = LCRS_CreateNode(data);
    }

    public void DestroyNode() => LCRS_DestroyNode(Node);

    public void AddChildNode(LCRSTreeNode node) => LCRS_AddChildNode(Node, node.Node);

    public static LCRSNode IntPtrToNode(IntPtr ptr) => Marshal.PtrToStructure<LCRSNode>(ptr);
    public static IntPtr NodeToIntPtr(LCRSNode node)
    {
        IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(node));
        Marshal.StructureToPtr(node, ptr, false);
        return ptr;
    }

    public static string PrintTree(IntPtr nodePtr, int depth)
    {
        string result = String.Empty;
        for (int i = 0; i < depth - 1; i++)
        {
            result += "   ";
        }

        if (depth > 0)
        {
            result += "+---";
        }

        LCRSNode node = IntPtrToNode(nodePtr);
        result += $"{node.Data}\n";
        
        if (node.LeftChild != IntPtr.Zero)
        {
            result += PrintTree(node.LeftChild, depth + 1);
        }

        if (node.RightSibling != IntPtr.Zero)
        {
            result += PrintTree(node.RightSibling, depth);
        }
        
        return result;
    }

    public static string PrintNodesAtLevel(IntPtr rootPtr, int depth, int level)
    {
        string result = string.Empty;
        LCRSNode root = IntPtrToNode(rootPtr);
        
        if (level == depth)
        {
            result += $"{root.Data} ";

            if (root.RightSibling != IntPtr.Zero)
            {
                result += PrintNodesAtLevel(root.RightSibling, depth, level);
            }
        }
        else
        {
            if (root.LeftChild != IntPtr.Zero)
            {
                result += PrintNodesAtLevel(root.LeftChild, depth + 1, level);
            }

            if (root.RightSibling != IntPtr.Zero)
            {
                result += PrintNodesAtLevel(root.RightSibling, depth, level);
            }
        }

        return result;
    }


    #region DLL Import
    
    [StructLayout(LayoutKind.Sequential)]
    public struct LCRSNode
    {
        public IntPtr LeftChild;
        public IntPtr RightSibling;

        public char Data;
    }

    [DllImport("libLCRSTree.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr LCRS_CreateNode(char NewData);

    [DllImport("libLCRSTree.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void LCRS_DestroyNode(IntPtr Node);

    [DllImport("libLCRSTree.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void LCRS_AddChildNode(IntPtr Parent, IntPtr Child);

    #endregion
}