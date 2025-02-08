using CircularQueue;

var rand = new Random();
using var queue = new CircularQueuClass(10);

queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Enqueue(4);

for (int i = 0; i < 3; i++)
{
    Console.WriteLine($"Dequeue: {queue.Dequeue()}, Front: {queue.Front}, Rear: {queue.Rear}");
}

while (queue.IsFull() == 0)
{
    queue.Enqueue(rand.Next(0, 100));
}

Console.WriteLine($"Capacity: {queue.Capacity}, Size: {queue.Size}\n");

while (queue.IsEmpty() == 0)
{
    Console.WriteLine($"Dequeue: {queue.Dequeue()}, Front: {queue.Front}, Rear: {queue.Rear}");
}