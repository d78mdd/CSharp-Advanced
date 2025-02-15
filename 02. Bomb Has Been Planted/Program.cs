int[] sizes = sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

char[,] map = new char[sizes[0], sizes[1]];

int counterRow = 0;
int counterCol = 0;

// input
for (int row = 0; row < map.GetLength(0); row++)
{
    string line = Console.ReadLine();
    for (int col = 0; col < map.GetLength(1); col++)
    {
        map[row, col] = line[col];

        if (map[row, col] == 'C')
        {
            counterRow = row;
            counterCol = col;
        }
    }
}



int time = 16; // seconds
bool bombExploded = false;
bool isKilledByT = false;

while (true)
{
    if (time <= 0)
    {
        bombExploded = true;
        break;
    }

    string command = Console.ReadLine();

    if (command == "defuse")
    {
        if (map[counterRow, counterCol] == 'B')
        {
            if (time >= 4)
            {
                map[counterRow, counterCol] = 'D';
                break;
            }
            else
            {
                map[counterRow, counterCol] = 'X';
                break;
            }
        }
        else
        {
            time -= 2;
        }
    }
    else
    {
        time -= 1;

        Direction direction = (Direction)Enum.Parse(typeof(Direction), command);

        switch (direction)  // or using command
        {
            case Direction.up:  // or using string "up"
                if (counterRow > 0)
                {
                    counterRow--;
                }
                break;

            case Direction.down:  // or using string "down"
                if (counterRow < map.GetLength(0) - 1)
                {
                    counterRow++;
                }
                break;

            case Direction.right:  // or using string "right"
                if (counterCol < map.GetLength(1) - 1)
                {
                    counterCol++;
                }
                break;

            case Direction.left:  // or using string "left"
                if (counterCol > 0)
                {
                    counterCol--;
                }
                break;

            default:
                break;
        }


        if (map[counterRow, counterCol] == 'T')
        {
            isKilledByT = true;
            map[counterRow, counterCol] = '*';
            break;
        }
    }

}

if (map[counterRow, counterCol] == 'X' || bombExploded)
{
    Console.WriteLine("Terrorists win!");
    Console.WriteLine("Bomb was not defused successfully!");
    if (map[counterRow, counterCol] == 'X')
    {
        Console.WriteLine($"Time needed: {4 - time} second/s.");
    }
    else
    {
        Console.WriteLine($"Time needed: {time} second/s.");
    }
}

if (map[counterRow, counterCol] == 'D')
{
    Console.WriteLine("Counter-terrorist wins!");
    Console.WriteLine($" Bomb has been defused: {time - 4} second/s remaining.");
}

if (isKilledByT)
{
    Console.WriteLine($"Terrorists win!");
}

PrintMatrix(map);















// not needed for exam
// can copy-paste to exam for fast implementation of printing the matrix there
void PrintMatrix<T>(T[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col]);
        }
        Console.WriteLine();
    }
}

// not needed for exam
enum Direction
{
    up,
    down,
    left,
    right
}
