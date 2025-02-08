using System.Runtime.InteropServices;

namespace LinkedListStack;

[StructLayout(LayoutKind.Sequential)]
public struct Node
{
    public string Data;
    public IntPtr NextNode;
}

public class LinkedListStackClass : IDisposable
{
    private IntPtr _stack;

    public LinkedListStackClass()
    {
        LLS_CreateStack(out _stack);
    }

    public void Dispose()
    {
        LLS_DestroyStack(_stack);
        
        GC.SuppressFinalize(this);
    }

    public IntPtr CreateNode(string data) => LLS_CreateNode(data);
    public void DestroyNode(IntPtr node) => LLS_DestroyNode(node);

    public IntPtr NodeToIntPtr(Node node)
    {
        IntPtr nodePtr = Marshal.AllocHGlobal(Marshal.SizeOf(node));
        Marshal.StructureToPtr(node, nodePtr, false);
        return nodePtr;
    }

    public void Push(IntPtr node) => LLS_Push(_stack, node);

    public Node Pop() => Marshal.PtrToStructure<Node>(LLS_Pop(_stack));
    public Node Top() => Marshal.PtrToStructure<Node>(LLS_Top(_stack));
    
    public int Size => LLS_GetSize(_stack);
    public int IsEmpty => LLS_IsEmpty(_stack);

    #region DLL Import

    [DllImport("libLinkedListStack.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void LLS_CreateStack(out IntPtr Stack);

    [DllImport("libLinkedListStack.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void LLS_DestroyStack(IntPtr Stack);


    [DllImport("libLinkedListStack.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr LLS_CreateNode(string Data);

    [DllImport("libLinkedListStack.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void LLS_DestroyNode(IntPtr _Node);


    [DllImport("libLinkedListStack.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void LLS_Push(IntPtr Stack, IntPtr NewNode);

    [DllImport("libLinkedListStack.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr LLS_Pop(IntPtr Stack);


    [DllImport("libLinkedListStack.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr LLS_Top(IntPtr Stack);

    [DllImport("libLinkedListStack.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern int LLS_GetSize(IntPtr Stack);

    [DllImport("libLinkedListStack.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern int LLS_IsEmpty(IntPtr Stack);

    #endregion
}