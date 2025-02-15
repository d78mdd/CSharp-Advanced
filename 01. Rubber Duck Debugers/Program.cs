
// programmers' times
Queue<int> programmers = new Queue<int>(
    Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    );
// numbers of tasks
Stack<int> tasks = new Stack<int>(
    Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    );
// their Count will always be identical

int duckiesDarthVader = 0;
int duckiesThor = 0;
int duckiesBigBlueRubber = 0;
int duckiesSmallYellowRubber = 0;

int taskDecreaseValue = 2;

for (; ; )
{
    if (programmers.Count < 1)
    {
        break;
    }

    int programmer = programmers.Peek();
    int task = tasks.Peek();

    int time = programmer * task;

    if (time <= 60)
    {
        duckiesDarthVader++;

        programmers.Dequeue();
        tasks.Pop();
    }
    else if (time <= 120)
    {
        duckiesThor++;

        programmers.Dequeue();
        tasks.Pop();
    }
    else if (time <= 180)
    {
        duckiesBigBlueRubber++;

        programmers.Dequeue();
        tasks.Pop();
    }
    else if (time <= 240)
    {
        duckiesSmallYellowRubber++;

        programmers.Dequeue();
        tasks.Pop();
    }
    else // time > 240
    {
        task -= taskDecreaseValue;

        programmers.Dequeue();
        programmers.Enqueue(programmer);

        tasks.Pop();
        tasks.Push(task);
    }
}

Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");

Console.WriteLine($"Darth Vader Ducky: {duckiesDarthVader}");
Console.WriteLine($"Thor Ducky: {duckiesThor}");
Console.WriteLine($"Big Blue Rubber Ducky: {duckiesBigBlueRubber}");
Console.WriteLine($"Small Yellow Rubber Ducky: {duckiesSmallYellowRubber}");
