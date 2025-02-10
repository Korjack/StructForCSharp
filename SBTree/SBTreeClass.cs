using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SBTree;

public class SBTreeClass
{
    public IntPtr Node;

    public SBTreeClass()
    {
        Node = IntPtr.Zero;
    }
    
    public SBTreeClass(char data)
    {
        Node = SBT_CreateNode(data);
    }

    // 구조체 포인터로 인하여서 직접 참조가 불가능한 노드
    // 왼쪽 및 오른쪽 데이터 추가를 위한 함수
    public void AddLeft(SBTreeClass nodeClass)
    {
        SBTNode node = IntPtrToNode(Node);
        node.Left = nodeClass.Node;
        Marshal.StructureToPtr(node, Node, false);
    }
    public void AddRight(SBTreeClass nodeClass)
    {
        SBTNode node = IntPtrToNode(Node);
        node.Right = nodeClass.Node;
        Marshal.StructureToPtr(node, Node, false);
    }

    // 선언된 노드 및 트리를 메모리에서 해제
    public void DestroyNode() => SBT_DestroyNode(Node);
    public static void DestroyTree(SBTreeClass node) => SBT_DestroyTree(node.Node);
    
    // 구조체 포인터에서 데이터를 쉽게 참조하기 위한 변환장치
    public static SBTNode IntPtrToNode(IntPtr ptr) => Marshal.PtrToStructure<SBTNode>(ptr);
    public static IntPtr NodeToIntPtr(SBTNode node)
    {
        IntPtr nodePtr = Marshal.AllocHGlobal(Marshal.SizeOf(node));
        Marshal.StructureToPtr(node, nodePtr, false);
        return nodePtr;
    }

    // 전위 표기 방식
    public static string PreorderPrintTree(IntPtr nodePtr)
    {
        if (nodePtr == IntPtr.Zero) return string.Empty;
        
        string result = string.Empty;
        SBTNode node = IntPtrToNode(nodePtr);       // C#에서 가능한 구조체로 변환

        // 루트 데이터 추가
        result += " " + node.Data;
        
        result += PreorderPrintTree(node.Left);
        result += PreorderPrintTree(node.Right);

        return result;
    }

    // 중위 표기 방식
    public static string InorderPrintTree(IntPtr nodePtr)
    {
        if (nodePtr == IntPtr.Zero) return string.Empty;
        
        string result = string.Empty;
        SBTNode node = IntPtrToNode(nodePtr);

        result += InorderPrintTree(node.Left);
        
        result += " " + node.Data;

        result += InorderPrintTree(node.Right);

        return result;
    }

    // 후위 표기 방식
    public static string PostorderPrintTree(IntPtr nodePtr)
    {
        if (nodePtr == IntPtr.Zero) return string.Empty;

        string result = string.Empty;
        SBTNode node = IntPtrToNode(nodePtr);

        result += PostorderPrintTree(node.Left);
        result += PostorderPrintTree(node.Right);

        result += " " + node.Data;

        return result;
    }
    

    #region DLL Import

    [StructLayout(LayoutKind.Sequential)]
    public struct SBTNode
    {
        public IntPtr Left;
        public IntPtr Right;

        public char Data;
    }

    [DllImport("libSBTree.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SBT_CreateNode(char Data);

    [DllImport("libSBTree.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SBT_DestroyNode(IntPtr Node);

    [DllImport("libSBTree.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SBT_DestroyTree(IntPtr Node);

    #endregion
}