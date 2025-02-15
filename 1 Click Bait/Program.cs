
// engagement scores of Suggested Links
// FIFO principle collection
Queue<int> links = new Queue<int>(
    Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    );

// popularity scores of Featured Articles
// LIFO principle collection
Stack<int> articles = new Stack<int>(
    Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    );

// target goal ( Target Engagement Value )
int target = int.Parse(Console.ReadLine());

//Final Feed Collection
List<int> feed = new List<int>();

// Engagement Value (Total Engagement Value)
int engagement = 0;


for (; ; )
{
    if (links.Count < 1 || articles.Count < 1)
    {
        break;
    }
    int link = links.Peek();
    int article = articles.Peek();

    bool linkIsGreater = link > article;
    bool articleIsGreater = article > link;

    // remainder
    int modulo = 0;
    if (linkIsGreater)
    {
        modulo = link % article;
    }
    else if (articleIsGreater)
    {
        modulo = article % link;
    }
    // else nothing

    if (articleIsGreater) // greater element is from a LIFO principle collection
    {
        feed.Add(modulo);

        articles.Pop();
        links.Dequeue();

        if (modulo != 0)
        {
            modulo *= 2;
            articles.Push(modulo);
        }
    }
    else if (linkIsGreater) // greater element is from a FIFO principle collection
    {
        //modulo = 0 - modulo;

        feed.Add(0 - modulo);

        links.Dequeue();
        articles.Pop();

        if (modulo != 0)
        {
            modulo *= 2;
            links.Enqueue(modulo);
        }
    }
    else // equal
    {
        // If the two elements are equal, just add zero to the Final Feed Collection
        
        // and remove both elements?

        articles.Pop();
        links.Dequeue();

        feed.Add(0);
    }
}


engagement = feed.Sum();


// Print the Final Feed Collection
Console.Write("Final Feed: ");
Console.WriteLine(string.Join(", ", feed));


if (engagement >= target)
{
    // the goal has been achieved

    Console.WriteLine($"Goal achieved! Engagement Value: {engagement}");
}
else // engagement < target
{
    // the goal has not been achieved

    int shortfall = target - engagement;

    Console.WriteLine($"Goal not achieved! Short by: {shortfall}");
}
