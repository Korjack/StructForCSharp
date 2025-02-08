using System.Runtime.InteropServices;

namespace CircularQueue;

public class CircularQueuClass : IDisposable
{
    private IntPtr _queue;

    public CircularQueuClass(int capacity)
    {
        CQ_CreateQueue(out _queue, capacity);
    }

    public void Dispose()
    {
        CQ_DestroyQueue(_queue);
        GC.SuppressFinalize(this);
    }


    public void Enqueue(int data) => CQ_Enqueue(_queue, data);
    public int Dequeue() => CQ_Dequeue(_queue);

    public int Size => CQ_GetSize(_queue);
    public int Capacity => Marshal.PtrToStructure<CircularQueue>(_queue).Capacity;
    public int Front => Marshal.PtrToStructure<CircularQueue>(_queue).Front;
    public int Rear => Marshal.PtrToStructure<CircularQueue>(_queue).Rear;
    
    public int IsEmpty() => CQ_IsEmpty(_queue);
    public int IsFull() => CQ_IsFull(_queue);

    
    #region DLL Import

    [StructLayout(LayoutKind.Sequential)]
    public struct Node
    {
        public int Data;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct CircularQueue
    {
        public int Capacity;
        public int Front;
        public int Rear;

        public IntPtr Nodes;
    }

    [DllImport("libCircularQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CQ_CreateQueue(out IntPtr Queue, int Capacity);

    [DllImport("libCircularQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CQ_DestroyQueue(IntPtr Queue);


    [DllImport("libCircularQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CQ_Enqueue(IntPtr Queue, int Data);

    [DllImport("libCircularQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CQ_Dequeue(IntPtr Queue);


    [DllImport("libCircularQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CQ_GetSize(IntPtr Queue);

    [DllImport("libCircularQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CQ_IsEmpty(IntPtr Queue);

    [DllImport("libCircularQueue.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CQ_IsFull(IntPtr Queue);

    #endregion
}