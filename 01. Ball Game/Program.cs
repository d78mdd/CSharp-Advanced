
Stack<int> kicks = new Stack<int>(
    Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    );

Queue<int> accuracies = new Queue<int>(
    Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    );

int goalValue = 100;
int kickStrengthDecrease = 10;

int scoredGoals = 0;

for (; ; )
{
    if (kicks.Count < 1 || accuracies.Count < 1)
    {
        break;
    }

    int kickStrength = kicks.Peek();
    int accuracy = accuracies.Peek();

    int sum = kickStrength + accuracy;

    if (sum == goalValue)
    {
        kicks.Pop();
        accuracies.Dequeue();

        scoredGoals++;
    }
    else if (sum < goalValue)
    {
        if (kickStrength < accuracy)
        {
            kicks.Pop();
        }
        else if (kickStrength > accuracy)
        {
            accuracies.Dequeue();
        }
        else // kickStrength == accuracy
        {
            kicks.Pop();
            kicks.Push(sum);

            accuracies.Dequeue();
        }
    }
    else // sum > goalValue
    {
        kickStrength -= kickStrengthDecrease;

        kicks.Pop();
        kicks.Push(kickStrength);

        accuracies.Dequeue();
        accuracies.Enqueue(accuracy);
    }
}

Console.WriteLine();

if (scoredGoals == 3)
{
    Console.WriteLine("Paul scored a hat-trick!");
}
else if (scoredGoals == 0)
{
    Console.WriteLine("Paul failed to score a single goal.");
}
else if (scoredGoals > 3)
{
    Console.WriteLine("Paul performed remarkably well!");
}
else if (scoredGoals > 0) // and less than 3
{
    Console.WriteLine("Paul failed to make a hat-trick.");
}

if (scoredGoals > 0)
{
    Console.WriteLine($"Goals scored: {scoredGoals}");
}

if (kicks.Count > 0)
{
    Console.Write("Strength values left: ");
    Console.WriteLine(string.Join($", ", kicks));
}
if (accuracies.Count > 0)
{
    Console.Write("Accuracy values left: ");
    Console.WriteLine(string.Join($", ", accuracies));
}
