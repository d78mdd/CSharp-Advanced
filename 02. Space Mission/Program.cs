
int size = int.Parse(Console.ReadLine());

char[,] grid = new char[size, size];

// current coordinates
int x = -1;
int y = -1;

for (int row = 0; row < size; row++)
{
    string input = string.Join("", Console.ReadLine().Split(' ').Select(s => s[0]));

    for (int col = 0; col < size; col++)
    {
        grid[row, col] = input[col];

        if (grid[row, col] == 'S') // Spaceship
        {
            y = row;
            x = col;
        }
    }
}


int resources = 100;

bool outside = false;
bool reached = false;


grid[y, x] = '.';

for (; ; )
{
    string command = Console.ReadLine();

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



    if (outside) // lost in space
    {
        grid[y, x] = 'S';
        break;
    }


    resources -= 5;


    // check the new coordinates:

    // reach an empty sector
    if (grid[newY, newX] == '.')
    {
        x = newX;
        y = newY;
    }
    // reach a refueling space station
    else if (grid[newY, newX] == 'R')
    {
        x = newX;
        y = newY;

        resources += 10;
        if (resources > 100)
        {
            resources = 100;
        }
    }
    // reach a meteorite
    else if (grid[newY, newX] == 'M')
    {
        x = newX;
        y = newY;

        grid[y, x] = '.';

        resources -= 5;
    }
    // planet reached
    else if (grid[newY, newX] == 'P')
    {
        x = newX;
        y = newY;

        reached = true;

        break;
    }

    


    if (resources < 5)
    {
        grid[y, x] = 'S';

        break;
    }

}


// it can reach with negative resources


if (outside)
{
    Console.WriteLine("Mission failed! The spaceship was lost in space.");
}
else if (reached) // resources >= 0, outside = false
{
    Console.WriteLine($"Mission accomplished! The spaceship reached Planet Eryndor with {resources} resources left.");
}
else // resources < 0
{
    Console.WriteLine("Mission failed! The spaceship was stranded in space.");
}
//else nothing
// reached = false, outside = false
// There will always be enough commands to either succeed or fail the mission.

// print the grid
for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        Console.Write(grid[row, col]);
        Console.Write(' ');  // will this break judge tests? every line will have 1 empty space at the end
    }
    Console.WriteLine();
}
