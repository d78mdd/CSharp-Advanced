
int N = int.Parse(Console.ReadLine());

char[][] spaceField = new char[N][];

// current coordinates
int x = -1;
int y = -1;

for (int row = 0; row < N; row++)
{
    string input = string.Join("", Console.ReadLine().Split(' '));

    spaceField[row] = new char[N];
    for (int col = 0; col < N; col++)
    {
        spaceField[row][col] = input[col];

        if (spaceField[row][col] == 'S') // Spaceship
        {
            y = row;
            x = col;
        }
    }
}


int resources = 100;

bool outside = false;
bool reached = false;


spaceField[y][x] = '.';

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

            if (y == (N - 1))
            {
                outside = true;
            }
            else
            {
                newY++;
            }

            break;

        case "right":

            if (x == (N - 1))
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

    resources -= 5;

    if (outside) // lost in space
    {
        spaceField[y][x] = 'S';
        break;
    }





    // check the new coordinates:

    // reach an empty sector
    if (spaceField[newY][newX] == '.')
    {
        x = newX;
        y = newY;
    }
    // reach a refueling space station
    else if (spaceField[newY][newX] == 'R')
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
    else if (spaceField[newY][newX] == 'M')
    {
        x = newX;
        y = newY;

        spaceField[y][x] = '.';

        resources -= 5;
    }
    // planet Erynor reached
    else if (spaceField[newY][newX] == 'P')
    {
        x = newX;
        y = newY;

        reached = true;

        break;
    }




    if (resources < 5)
    {
        spaceField[y][x] = 'S';

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
for (int row = 0; row < N; row++)
{
    Console.WriteLine(string.Join(' ', spaceField[row]));
}
