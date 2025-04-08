int size = int.Parse(Console.ReadLine());

char[][] field = new char[size][];

// current coordinates
int x = -1;
int y = -1;

for (int row = 0; row < size; row++)
{
    string input = string.Join("", Console.ReadLine().Split(' '));

    field[row] = new char[size];
    for (int col = 0; col < size; col++)
    {
        field[row][col] = input[col];

        if (field[row][col] == 'P') // Player
        {
            y = row;
            x = col;
        }
    }
}

//starting position
int xStart = 0;
int yStart = 0;

int stars = 2;



bool outside = false;



field[y][x] = '.';

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


    if (outside) // teleport to starting position
    {
        newX = xStart;
        newY = yStart;
        outside = false;
    }





    // check the new coordinates:

    // move to a star
    if (field[newY][newX] == '*')
    {
        x = newX;
        y = newY;

        stars += 1;

        field[y][x] = '.';
    }
    // move to a previously visited position
    else if (field[newY][newX] == '.')
    {
        x = newX;
        y = newY;
    }
    // hit/encounter an obstacle
    else if (field[newY][newX] == '#')
    {
        stars -= 1;
    }




    if (stars == 10 || stars == 0)
    {
        field[y][x] = 'P';

        break;
    }

}



bool win = stars == 10;
bool lose = !win;



if (win)
{
    Console.WriteLine("You won! You have collected 10 stars.");
}
else  // lose
{
    Console.WriteLine("Game over! You are out of any stars.");
}

Console.WriteLine($"Your final position is [{y}, {x}]");



// print the matrix
for (int row = 0; row < size; row++)
{
    Console.WriteLine(string.Join(' ', field[row]));
}
