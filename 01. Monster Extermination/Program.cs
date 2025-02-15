
// the armor of the monsters
Queue<int> armors = new Queue<int>(
    Console.ReadLine()
    .Split(',')
    .Select(int.Parse)
    );

// the soldier's striking impact
Stack<int> impacts = new Stack<int>(
    Console.ReadLine()
    .Split(',')
    .Select(int.Parse)
    );

int killedMonsters = 0;

for (; ; )
{
    if (armors.Count < 1 || impacts.Count < 1)
    {
        break;
    }

    int armor = armors.Peek();
    int impact = impacts.Peek();


    if (impact >= armor)
    {
        armors.Dequeue();
        killedMonsters++;

        impact -= armor;

        impacts.Pop(); // remove the current impact

        if (impacts.Count > 0) // it was not the last
        {
            if (impact > 0)
            {
                // increase the next impact
                int next = impacts.Pop();
                next += impact;
                impacts.Push(next);
            }
        }
        else // it's the last
        {
            if (impact > 0)
            {
                impacts.Push(impact); // put back the current and last one
            }
        }
    }
    else // impact < armor
    {
        impacts.Pop(); // remove the current impact

        armors.Dequeue();
        armor -= impact;
        if (armor > 0)
        {
            armors.Enqueue(armor);
        }
    }

}


if (armors.Count == 0)
{
    Console.WriteLine("All monsters have been killed!");
}
if (impacts.Count == 0)
{
    Console.WriteLine("The soldier has been defeated.");
}

Console.WriteLine($"Total monsters killed: {killedMonsters}");
