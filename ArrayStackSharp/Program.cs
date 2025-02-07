using ArrayStackSharp;

int maxSize = 10;
Random random = new Random();

using (var stack = new ArrayStack(maxSize))
{
    for (int i = 0; i < maxSize; i++)
    {
        if (stack.IsFull != 0)
        {
            Console.WriteLine("Stack is full.");
            break;
        }
        
        stack.Push(random.Next(0, 100));
    }
    
    Console.WriteLine($"Capacity: {stack.Capacity}, Size: {stack.Size}, Top: {stack.Top()}");
    
    for (int i = 0; i < maxSize; i++)
    {
        if (stack.IsEmpty != 0) break;
        
        Console.Write($"Popped: {stack.Pop()} / ");

        Console.WriteLine(stack.IsEmpty == 0 ? $"Current Top: {stack.Top()}" : "Stack is empty.");
    }
}