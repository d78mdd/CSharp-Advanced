// https://judge.softuni.org/Contests/Practice/Index/5430#1


string[] commandStrings = { "up", "down", "left", "right" };

Random random = new Random();

// use every allowed size
for (int size = 2; size <= 10; size++)
{

    // generate an empty field (no spaces)
    char[][] lines = new char[size][];
    for (int i = 0; i < lines.Length; i++)
    {
        lines[i] = new char[size];
        for (int j = 0; j < size; j++)
        {
            lines[i][j] = '.';
        }
    }


    // generate random S spaceship coordinages and assign to position
    int sx = random.Next(0, size);
    int sy = random.Next(0, size);
    lines[sy][sx] = 'S';



    // generate random P Planet coordinates and assign to position different from previous
    int px;
    int py;
    do
    {
        px = random.Next(0, size);
        py = random.Next(0, size);
    }
    while (px == sx && py == sy);
    lines[py][px] = 'P';



    // generate random number of M meteorites and assign them to random positions different from previous
    int maxMeteorites = size * size - 1 - 1;  // size * size - 1 planet - 1 spaceship
    int meteorites = random.Next(0, maxMeteorites + 1);
    for (int i = 1; i <= meteorites; i++)
    {
        int mx;
        int my;
        do
        {
            mx = random.Next(0, size);
            my = random.Next(0, size);
        }
        while ((mx == sx && my == sy) ||  // skip the spaceship coordinates
               (mx == px && my == py) ||  // skip the planet coordinates
               lines[mx][my] == 'M');     // skip existing meteorites
        lines[my][mx] = 'M';
    }



    // generate random number of R refueling stations and assign them to random positions different from previous
    int maxRefuelingStations = size * size - 1 - 1 - meteorites;  // size * size - 1 planet - 1 spaceship - all the meteorites
    int refuelingStations = random.Next(0, maxRefuelingStations + 1);
    for (int i = 1; i <= refuelingStations; i++)
    {
        int rx;
        int ry;
        do
        {
            rx = random.Next(0, size);
            ry = random.Next(0, size);
        }
        while ((rx == sx && ry == sy) ||  // skip the spaceship coordinates
               (rx == px && ry == py) ||  // skip the planet coordinates
               lines[rx][ry] == 'M' ||    // skip meteorite coordinates
               lines[rx][ry] == 'R');     // skip existing refueling stations
        lines[ry][rx] = 'R';
    }




    // generate 100 random commands
    string[] commands = new string[100];
    for (int i = 0; i < commands.Length; i++)
    {
        random = new Random();
        int commandIndex = random.Next(0, 4);
        commands[i] = commandStrings[commandIndex];
    }




    // add spaces
    char[][] linesWithSpaces = new char[size][];
    // init as spaces only
    for (int i = 0; i < size; i++)
    {
        linesWithSpaces[i] = new char[size * 2 - 1];
        for (int j = 0; j < size * 2 - 1; j++)
        {
            linesWithSpaces[i][j] = ' ';
        }
    }
    // copy the grid values
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size * 2 - 1; j += 2)
        {
            linesWithSpaces[i][j] = lines[i][j / 2];
        }
    }
    //// although odd positions will always have
    //// and even positions will always have




    // convert from char[][] to string[]
    string[] linesStrings = new string[size];
    for (int i = 0; i < linesWithSpaces.Length; i++)
    {
        linesStrings[i] = string.Join("", linesWithSpaces[i]);
    }


    foreach (string command in commands)
    {
        Console.WriteLine(command);
    }
    foreach (string line in linesStrings)
    {
        Console.WriteLine(line);
    }
    RunSpaceMission(size, linesStrings, commands);
    Console.WriteLine();
    Console.WriteLine();
}

// generates 1 run for each size
// to go through all possible scenarios no randomess should be used

// need to print starting grid

// need to print commands list




void RunSpaceMission(int size, string[] lines, string[] commands)
{


    char[][] grid = new char[size][];

    // current coordinates
    int x = -1;
    int y = -1;

    for (int row = 0; row < size; row++)
    {
        string input = string.Join("", lines[row].Split(' ').Select(s => s[0]));

        grid[row] = new char[size];
        for (int col = 0; col < size; col++)
        {
            grid[row][col] = input[col];

            if (grid[row][col] == 'S') // Spaceship
            {
                y = row;
                x = col;
            }
        }
    }


    int resources = 100;

    bool outside = false;
    bool reached = false;


    grid[y][x] = '.';

    for (int i = 0; i < commands.Length; i++)
    {
        string command = commands[i];

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

                if (y == (size - 1))
                {
                    outside = true;
                }
                else
                {
                    newY++;
                }

                break;

            case "right":

                if (x == (size - 1))
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
            grid[y][x] = 'S';
            break;
        }





        // check the new coordinates:

        // reach an empty sector
        if (grid[newY][newX] == '.')
        {
            x = newX;
            y = newY;
        }
        // reach a refueling space station
        else if (grid[newY][newX] == 'R')
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
        else if (grid[newY][newX] == 'M')
        {
            x = newX;
            y = newY;

            grid[y][x] = '.';

            resources -= 5;
        }
        // planet Erynor reached
        else if (grid[newY][newX] == 'P')
        {
            x = newX;
            y = newY;

            reached = true;

            break;
        }




        if (resources < 5)
        {
            grid[y][x] = 'S';

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
        Console.WriteLine(string.Join(' ', grid[row]));
    }
}