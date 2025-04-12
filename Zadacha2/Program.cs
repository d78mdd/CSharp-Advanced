// 02. Fortress

int N = int.Parse(Console.ReadLine());

// the size of the square fortress grid
char[][] fortress = new char[N][];

// current coordinates
int x = -1;
int y = -1;

for (int row = 0; row < N; row++)
{
    string input = Console.ReadLine();  // receive strings of length N, representing each row of the grid.

    fortress[row] = new char[N];
    for (int col = 0; col < N; col++)
    {
        fortress[row][col] = input[col];

        if (fortress[row][col] == 'S') // starting position of the spy
        {
            y = row;
            x = col;
        }
    }
}



int stealthPoints = 100;














bool outside = false;
//bool reached = false;
bool missionFails = false;
bool missionSuccess = false;

fortress[y][x] = '.';

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


    if (outside) // If a command would move the spy outside the grid, it is skipped
    {
        outside = false;
        continue;
    }





    // check the new coordinates:

    // Moving into a guard cell 
    if (fortress[newY][newX] == 'G')
    {
        x = newX;
        y = newY;

        stealthPoints -= 40;

        if (stealthPoints < 1)
        {
            fortress[y][x] = 'S';  // If the mission has failed, mark the spy’s last position with 'S'

            missionFails = true;
            break;
        }
        else  // spy survives , the guard is neutralized
        {
            fortress[y][x] = '.';  // the cell becomes a '.' (empty corridor)
        }
    }
    // Moving into a blind spot ('B') 
    else if (fortress[newY][newX] == 'B')
    {
        x = newX;
        y = newY;

        stealthPoints += 15;
        if (stealthPoints > 100)
        {
            stealthPoints = 100;
        }

        fortress[y][x] = '.';
    }
    // Moving into an empty corridor ('.') is safe
    else if (fortress[newY][newX] == '.')
    {
        x = newX;
        y = newY;
    }
    // The spy reaches the extraction point 'E' (mission success)
    else if (fortress[newY][newX] == 'E')
    {
        x = newX;
        y = newY;

        // the 'E' remains on the grid ; If the mission succeeded: the spy’s position should not be shown

        missionSuccess = true;
        break;
    }

}





if (missionFails)  // stealthPoints < 1
{
    Console.WriteLine("Mission failed. Spy compromised.");
}
else if (missionSuccess)  // spy reaches 'E'
{
    Console.WriteLine("Mission accomplished. Spy extracted successfully.");
}


Console.WriteLine($"Stealth level: {stealthPoints} units");  // . dot ?



// print the final state of the fortress grid
for (int row = 0; row < N; row++)
{
    Console.WriteLine(fortress[row]);
}
