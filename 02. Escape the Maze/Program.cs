// dimension 0 = row = y
// dimension 1 = col = x

int initialHealth = 100;
int potionSize = 15;
int monsterDamage = 40;

int size = int.Parse(Console.ReadLine());

char[,] maze = new char[size, size];

// player coordinates
int x = -1;
int y = -1;

for (int row = 0; row < size; row++)
{
    string input = Console.ReadLine();

    for (int col = 0; col < input.Length; col++)
    {
        maze[row, col] = input[col];
        
        // save initial player coordinates
        if (maze[row, col] == 'P')
        {
            x = col;
            y = row;
        }
    }
}

int playerHealth = initialHealth;

bool exit = false;

for (; ; )
{
    string command = Console.ReadLine();

    switch (command)
    {
        case "up":
            if (y == 0)
            {
                // do nothing
            }
            else
            {
                maze[y, x] = '-';

                // prepare the new position
                y -= 1;
            }
            break;

        case "down":
            if (y == maze.GetLength(0) - 1)
            {
                // do nothing
            }
            else
            {
                maze[y, x] = '-';

                // prepare the new position
                y += 1;
            }
            break;

        case "right":
            if (x == maze.GetLength(1) - 1)
            {
                // do nothing
            }
            else
            {
                maze[y, x] = '-';

                // prepare the new position
                x += 1;
            }
            break;

        case "left":
            if (x == 0)
            {
                // do nothing
            }
            else
            {
                maze[y, x] = '-';

                // prepare the new position
                x -= 1;
            }
            break;

        default:
            break;
    }

    // check the new position
    if (maze[y, x] == 'H')
    { 
        playerHealth += potionSize;
    }
    else if (maze[y, x] == 'M')
    {
        playerHealth -= monsterDamage;
    }
    else if (maze[y, x] == 'X')
    {
        exit = true;
    }

    // mark the new postion as stepped/current
    maze[y, x] = 'P';

    if (playerHealth < 1)
    {
        playerHealth = 0;
        break;
    }
    else if (playerHealth > 100)
    {
        playerHealth = 100;
    }

    if (exit)
    {
        break;
    }
}

if (playerHealth < 1)
{
    Console.WriteLine("Player is dead. Maze over!");
}
else // player has positive health and certainly escaped according to description
{
    Console.WriteLine("Player escaped the maze. Danger passed!");
}

Console.WriteLine($"Player's health: {playerHealth} units");

for (int row = 0; row < maze.GetLength(0); row++)
{
    for (int col = 0; col < maze.GetLength(1); col++)
    {
        Console.Write(maze[row, col]);
    }
    Console.WriteLine();
}
