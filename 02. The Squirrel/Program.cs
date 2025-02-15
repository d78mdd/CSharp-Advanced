

int size = int.Parse(Console.ReadLine());

char[,] field = new char[size, size];

string[] commands = Console.ReadLine().Split(", ");

int allHazelnuts = 3;
int collectedHazelnuts = 0;

// current coordinates
int x = -1;
int y = -1;

for (int row = 0; row < size; row++)
{
    string input = Console.ReadLine();

    for (int col = 0; col < size; col++)
    {
        field[row, col] = input[col];

        if (field[row, col] == 's')
        {
            y = row;
            x = col;
        }
    }
}


bool outside = false;
bool trap = false;

foreach (string command in commands)
{
    int newY = y;
    int newX = x;

    switch (command)
    {
        case "up":

            if (y == 0)
            {
                outside = true;
            }
            else
            {
                newY--;
            }

            break;

        case "down":

            if (y == size - 1)
            {
                outside = true;
            }
            else
            {
                newY++;
            }

            break;

        case "right":

            if (x == size - 1)
            {
                outside = true;
            }
            else
            {
                newX++;
            }

            break;

        case "left":

            if (x == 0)
            {
                outside = true;
            }
            else
            {
                newX--;
            }

            break;
    }



    if (outside)
    {
        break;
    }



    // check the new coordinates:

    // step on an empty position or the initial position
    if (field[newY, newX] == '*'
        || field[newY, newX] == 's')
    {
        x = newX;
        y = newY;
    }
    // step on a hazelnut
    else if (field[newY, newX] == 'h')
    {
        x = newX;
        y = newY;

        collectedHazelnuts++;

        field[y, x] = '*';
    }
    // step on a trap
    else if (field[newY, newX] == 't')
    {
        x = newX;
        y = newY;

        trap = true;

        break;
    }


    if (collectedHazelnuts == allHazelnuts)
    {
        break;
    }

}



if (outside)
{
    Console.WriteLine("The squirrel is out of the field.");
}
else if (trap)
{
    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
}
else if (collectedHazelnuts < allHazelnuts)
{
    Console.WriteLine("There are more hazelnuts to collect.");
}
else if (collectedHazelnuts == allHazelnuts)
{
    Console.WriteLine("Good job! You have collected all hazelnuts!");
}

Console.WriteLine($"Hazelnuts collected: {collectedHazelnuts}");
