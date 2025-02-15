

int[] size = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToArray();

int n = size[0]; // rows ; y axis
int m = size[1]; // columns ; x axis

char[,] neighbourhood = new char[n, m];

// current coordinates
int x = -1;
int y = -1;

for (int row = 0; row < n; row++)
{
    string input = Console.ReadLine();

    for (int col = 0; col < m; col++)  // input.Length == m
    {
        neighbourhood[row, col] = input[col];

        if (neighbourhood[row, col] == 'B')
        {
            y = row;
            x = col;
        }
    }
}


int initialX = x;
int initialY = y;

bool outside;

for (; ; )
{
    string command = Console.ReadLine();

    int newY = y;
    int newX = x;

    outside = false;

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

            if (y == n - 1)
            {
                outside = true;
            }
            else 
            {
                newY++;
            }

            break;

        case "right":

            if (x == m - 1)
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



    // check the new coordinates
    if (neighbourhood[newY, newX] == '*')
    {
        // do nothing - stay on the same position
    }
    else if (neighbourhood[newY, newX] == '-'
        || neighbourhood[newY, newX] == '.'
        || neighbourhood[newY, newX] == 'B')
    {
        x = newX;
        y = newY;

        neighbourhood[y, x] = '.';
    }
    // the boy collects the pizza
    else if (neighbourhood[newY, newX] == 'P')  // assuming this is the restaurant and not a previously delivered address
    {
        x = newX;
        y = newY;

        neighbourhood[y, x] = 'R';

        Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
    }
    // pizza is delivered successfully
    else if (neighbourhood[newY, newX] == 'A')
    {
        x = newX;
        y = newY;

        neighbourhood[y, x] = 'P';

        Console.WriteLine("Pizza is delivered on time! Next order...");

        break;
    }

}


if (outside)
{
    neighbourhood[initialY, initialX] = ' ';  // mark the boy's initial position as empty

    Console.WriteLine("The delivery is late. Order is canceled.");
}
else
{
    neighbourhood[initialY, initialX] = 'B';  // mark the boy's initial position
}


for (int row = 0; row < n; row++)
{
    for (int col = 0; col < m; col++)
    {
        Console.Write(neighbourhood[row, col]);
    }
    Console.WriteLine();
}
