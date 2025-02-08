using LinkedListStack;

using var stack = new LinkedListStackClass();

stack.Push(stack.CreateNode("Hello"));
stack.Push(stack.CreateNode("World"));
stack.Push(stack.CreateNode("Linked"));
stack.Push(stack.CreateNode("Stack"));

int count = stack.Size;
Console.WriteLine($"Size: {count}, Top: {stack.Top()}");

for (int i = 0; i < count; i++)
{
    if(stack.IsEmpty == 1) break;

    Node popped = stack.Pop();
        
    Console.Write($"Popped: {popped.Data}, ");
        
    stack.DestroyNode(stack.NodeToIntPtr(popped));

    if (stack.IsEmpty == 0)
    {
        Console.WriteLine($"Current Top: {stack.Top().Data}");
    }
    else
    {
        Console.WriteLine("Stack is full.");
    }
}