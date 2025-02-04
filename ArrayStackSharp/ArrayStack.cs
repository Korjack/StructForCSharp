using System.Runtime.InteropServices;

namespace ArrayStackSharp;

using ElementType = System.Int32;

public class ArrayStack : IDisposable
{
    
    private IntPtr _stackPtr;

    public ArrayStack(int capacity)
    {
        AS_CreateStack(out _stackPtr, capacity);
    }

    public void Dispose()
    {
        AS_DestroyStack(_stackPtr);
        _stackPtr = IntPtr.Zero;
        
        GC.SuppressFinalize(this);
    }


    public void Push(ElementType data) => AS_Push(_stackPtr, data);
    public ElementType Pop() => AS_Pop(_stackPtr);
    public ElementType Top() => AS_Top(_stackPtr);

    public int Size => AS_GetSize(_stackPtr);
    public int IsEmpty => AS_IsEmpty(_stackPtr);
    public int IsFull => AS_IsFull(_stackPtr);
    


    public int Capacity
    {
        get
        {
            var stack = Marshal.PtrToStructure<ArrayStackNative>(_stackPtr);
            return stack.Capacity;
        }
    }


    #region DLL Import

    [DllImport("libArrayStack.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void AS_CreateStack(out IntPtr stack, int capacity);

    [DllImport("libArrayStack.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void AS_DestroyStack(IntPtr stack);

    [DllImport("libArrayStack.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern void AS_Push(IntPtr stack, ElementType Data);

    [DllImport("libArrayStack.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern ElementType AS_Pop(IntPtr stack);

    [DllImport("libArrayStack.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern ElementType AS_Top(IntPtr stack);

    [DllImport("libArrayStack.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern int AS_GetSize(IntPtr stack);

    [DllImport("libArrayStack.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern int AS_IsEmpty(IntPtr stack);

    [DllImport("libArrayStack.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern int AS_IsFull(IntPtr stack);

    [StructLayout(LayoutKind.Sequential)]
    public struct Node
    {
        public ElementType Data;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ArrayStackNative
    {
        public int Capacity;
        public int Top;
        public IntPtr Nodes;
    }

    #endregion
}