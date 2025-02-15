
int size = int.Parse(Console.ReadLine());

char[,] battlefield = new char[size, size];

int x = -1;
int y = -1;

for (int row = 0; row < size; row++)
{
    string input = Console.ReadLine();

    for (int col = 0; col < input.Length; col++)
    {
        battlefield[row, col] = input[col];

        if (battlefield[row, col] == 'S')
        {
            y = row;
            x = col;
        }
    }
}

int hits = 0;
int battlecruisers = 3;
bool win = false;

for (; ; )
{
    string command = Console.ReadLine();

    switch (command)
    {
        case "up":
            battlefield[y, x] = '-';

            // prepare the new position
            y -= 1;
            break;

        case "down":
            battlefield[y, x] = '-';

            // prepare the new position
            y += 1;
            break;

        case "right":
            battlefield[y, x] = '-';

            // prepare the new position
            x += 1;
            break;

        case "left":
            battlefield[y, x] = '-';

            // prepare the new position
            x -= 1;
            break;

        default:
            break;
    }

    // check the new position
    if (battlefield[y, x] == '*')
    {
        hits += 1;
    }
    else if (battlefield[y, x] == 'C')
    {
        battlecruisers -= 1;
    }


    // mark the new position as current
    battlefield[y, x] = 'S';

    if (hits == 3) // submarine is destroyed
    {
        // win = false
        break;
    }

    if (battlecruisers == 0) // all battlecruisers are destroyed
    {
        win = true;
        break;
    }

}



if (win)
{
    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
}
else  // !win
{
    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{y}, {x}]!");
}

for (int row = 0; row < battlefield.GetLength(0); row++)
{
    for (int col = 0; col < battlefield.GetLength(1); col++)
    {
        Console.Write(battlefield[row, col]);
    }
    Console.WriteLine();
}




