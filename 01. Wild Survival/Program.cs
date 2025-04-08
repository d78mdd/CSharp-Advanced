// Every integer represents a group of bees 
Queue<int> beeGroups = new Queue<int>(
    Console.ReadLine()
        .Split(' ')
        .Select(int.Parse)
);



// Every integer represents a group of bee-eaters
Stack<int> eaterGroups = new Stack<int>(
Console.ReadLine()
        .Split(' ')
        .Select(int.Parse)
);


for (; ; )
{
    if (beeGroups.Count < 1 || eaterGroups.Count < 1)
    {
        break;
    }

    int beeGroup = beeGroups.Peek();
    int eaterGroup = eaterGroups.Peek();


    int eatersDied = beeGroup / 7;
    if (eatersDied > eaterGroup)
    {
        eatersDied = eaterGroup;
    }

    int eatersAfterFight = eaterGroup - eatersDied;  // eaters survived plus eaters not entered the fight

    int beesDied = eatersDied * 7;
    int beesAfterFight = beeGroup - beesDied;

    if (eatersAfterFight > 0) // not a good solution
    {
        beesAfterFight = 0;
    }

    bool eatersWin = beesAfterFight <= 0;   // <= 0 ?

    bool beesWin = eatersAfterFight <= 0;   // <= 0 ?

    bool draw = beesWin && eatersWin;

    if (!beesWin && eatersWin)
    {
        if (eaterGroups.Count == 1)
        {
            eaterGroups.Pop();
            eaterGroups.Push(eatersAfterFight);
        }
        else
        {
            eaterGroups.Pop();
            eaterGroups.Push(eaterGroups.Pop() + eatersAfterFight);
        }

        beeGroups.Dequeue();
    }
    else if (beesWin && !eatersWin)
    {
        beeGroups.Dequeue();
        beeGroups.Enqueue(beesAfterFight);

        eaterGroups.Pop();
    }
    else if (draw)
    {
        beeGroups.Dequeue();
        eaterGroups.Pop();
    }

}

Console.WriteLine("The final battle is over!");


if (beeGroups.Count == 0 && eaterGroups.Count == 0)
{
    Console.WriteLine("But no one made it out alive!");
}
else
{
    if (beeGroups.Count > 0)
    {
        Console.Write("Bee groups left: ");
        Console.WriteLine(string.Join(", ", beeGroups));
    }

    if (eaterGroups.Count > 0)
    {
        Console.Write("Bee-eater groups left: ");
        Console.WriteLine(string.Join(", ", eaterGroups));
    }
}
