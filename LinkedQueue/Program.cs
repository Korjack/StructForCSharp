using LinkedQueue;

using var queue = new LinkedQueueClass();

queue.Enqueue(queue.CreateNode("Linked"));
queue.Enqueue(queue.CreateNode("Queue"));
queue.Enqueue(queue.CreateNode("Class"));
queue.Enqueue(queue.CreateNode("TEST"));

Console.WriteLine($"Queue Size: {queue.Count}");

while (queue.IsEmpty() == 0)
{
    IntPtr node = queue.Dequeue();
    
    Console.WriteLine($"Dequeue: {queue.IntPtrToNode(node).Data}");
    
    queue.DestroyNode(node);
}