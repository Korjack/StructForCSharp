using System.Runtime.InteropServices;

namespace LinkedQueue;

public class LinkedQueueClass : IDisposable
{
    private IntPtr _queue;


    public LinkedQueueClass()
    {
        LQ_CreateQueue(out _queue);
    }

    public void Dispose()
    {
        LQ_DestroyQueue(_queue);
        
        GC.SuppressFinalize(this);
    }


    public IntPtr CreateNode(string newData) => LQ_CreateNode(newData);
    public void DestroyNode(IntPtr node) => LQ_DestroyNode(node);

    public Node IntPtrToNode(IntPtr nodePtr) => Marshal.PtrToStructure<Node>(nodePtr);
    public IntPtr NodeToIntPtr(Node node)
    {
        IntPtr nodePtr = Marshal.AllocHGlobal(Marshal.SizeOf(node));
        Marshal.StructureToPtr(node, nodePtr, false);
        return nodePtr;
    }

    public void Enqueue(IntPtr node) => LQ_Enqueue(_queue, node);
    public IntPtr Dequeue() => LQ_Dequeue(_queue);

    public int IsEmpty() => LQ_IsEmpty(_queue);
    public int Count => Marshal.PtrToStructure<LinkedQueue>(_queue).Count;
    

    #region DLL Import

    [StructLayout(LayoutKind.Sequential)]
    public struct Node
    {
        public string Data;
        public IntPtr NextNode;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct LinkedQueue
    {
        public IntPtr Front;
        public IntPtr Rear;
        public int Count;
    }


    [DllImport("libLinkedQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void LQ_CreateQueue(out IntPtr Queue);

    [DllImport("libLinkedQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void LQ_DestroyQueue(IntPtr Queue);


    [DllImport("libLinkedQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr LQ_CreateNode(string NewData);

    [DllImport("libLinkedQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void LQ_DestroyNode(IntPtr _Node);


    [DllImport("libLinkedQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void LQ_Enqueue(IntPtr Queue, IntPtr NewNode);

    [DllImport("libLinkedQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr LQ_Dequeue(IntPtr Queue);


    [DllImport("libLinkedQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern int LQ_IsEmpty(IntPtr Queue);


    #endregion
}