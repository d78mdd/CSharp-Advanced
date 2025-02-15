Queue<int> contestantCapacities = new Queue<int>(
    Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    );

Stack<int> piesPieces = new Stack<int>(
    Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    );

for (; ; )
{
    if (contestantCapacities.Count < 1 || piesPieces.Count < 1)
    {
        break;
    }

    int contestantCapacity = contestantCapacities.Dequeue();
    int piePieces = piesPieces.Pop();

    if (contestantCapacity >= piePieces)
    {
        contestantCapacity -= piePieces;
        // pie capacity is (already) removed from the collection

        // if the contestant capacity reached 0 they are (already) removed from the collection
        // otherwise:
        if (contestantCapacity > 0)
        {
            contestantCapacities.Enqueue(contestantCapacity);
        }
    }
    else
    {
        piePieces -= contestantCapacity;
        contestantCapacity = 0;

        if (piePieces == 1)
        {
            // remove the pie (already done)

            if (piesPieces.Count > 0)  // if the removed piece wasn't the last
            {
                int tempPie = piesPieces.Pop(); // get the next pie
                tempPie += 1;                    // add the one piece to it
                piesPieces.Push(tempPie);        // put it back
            }
            else // add back the only pie
            {
                piesPieces.Push(piePieces);
            }


        }
        else
        {
            piesPieces.Push(piePieces);
        }

        // remove the contestant - already done
    }
}


if (piesPieces.Count < 1) // pies are over
{
    if (contestantCapacities.Count > 0)
    {
        Console.WriteLine("We will have to wait for more pies to be baked!");

        Console.Write("Contestants left: ");
        foreach (int c in contestantCapacities)
        {
            Console.Write(string.Join(", ", contestantCapacities));
        }
    }
    else // both contestants and pies are over
    {
        Console.WriteLine("We have a champion!");
    }
}
else // there are pies left
{
    if (contestantCapacities.Count > 0)
    {
        // do nothing?
    }
    else // if the contestants are over
    {
        Console.WriteLine("Our contestants need to rest!");

        Console.Write("Pies left: ");
        foreach (int c in piesPieces)
        {
            Console.Write(string.Join(", ", piesPieces));
        }
    }
}






