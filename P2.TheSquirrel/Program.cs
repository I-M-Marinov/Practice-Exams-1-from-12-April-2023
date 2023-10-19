
int lenghtOfField = int.Parse(Console.ReadLine());
int rows = lenghtOfField;
int cols = lenghtOfField;


List<string> commands = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

int squirrelRow = 0;
int squirrelCol = 0;
int hazelnutsCount = 0;


char[,] field = new char[rows, cols];

for (int row = 0; row < rows; row++)
{
    char[] rowChars = Console.ReadLine().ToCharArray();

    for (int col = 0; col < cols; col++)
    {
        field[row, col] = rowChars[col];

        if (field[row, col] == 's')
        {
            squirrelRow = row;
            squirrelCol = col;
        }
    }
}

bool steppedOnTrap = false;
bool IsOutOfField = false;

while (true)
{
    if (commands.Count == 0)
    {
        break;
    }

    string command = commands[0];

    if (commands.Count > 0)
    {
        commands.RemoveAt(0);
    }

    if (command == "down")
    {
        if (squirrelRow == field.GetLength(0) - 1)
        {
            IsOutOfField = true;
            Console.WriteLine("The squirrel is out of the field.");
            break;
        }

        if (field[squirrelRow+1, squirrelCol] == 't')
        {
            steppedOnTrap = true;
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            break;
        }

        if (field[squirrelRow+1, squirrelCol] == 'h')
        {
            hazelnutsCount++;
            field[squirrelRow+1, squirrelCol] = '*';
            squirrelRow++;

            if (hazelnutsCount == 3)
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
                break;
            }
            continue;
        }

        if (field[squirrelRow+1, squirrelCol] == '*')
        {
            squirrelRow++;
            continue;
        }
        squirrelRow++;
    }
    else if (command == "up")
    {
        if (squirrelRow == 0)
        {
            IsOutOfField = true;
            Console.WriteLine("The squirrel is out of the field.");
            break;
        }

        if (field[squirrelRow-1, squirrelCol] == 't')
        {
            steppedOnTrap = true;
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            break;
        }

        if (field[squirrelRow-1, squirrelCol] == 'h')
        {
            hazelnutsCount++;
            field[squirrelRow-1, squirrelCol] = '*';
            squirrelRow--;

            if (hazelnutsCount == 3)
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
                break;
            }
            continue;
        }

        if (field[squirrelRow-1, squirrelCol] == '*')
        {
            squirrelRow--;
            continue;
        }
        squirrelRow--;
    }
    else if (command == "left")
    {
        if (squirrelCol == 0)
        {
            IsOutOfField = true;
            Console.WriteLine("The squirrel is out of the field.");
            break;
        }

        if (field[squirrelRow, squirrelCol-1] == 't')
        {
            steppedOnTrap = true;
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            break;
        }

        if (field[squirrelRow, squirrelCol-1] == 'h')
        {
            hazelnutsCount++;
            field[squirrelRow, squirrelCol-1] = '*';
            squirrelCol--;

            if (hazelnutsCount == 3)
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
                break;
            }
            continue;
        }

        if (field[squirrelRow, squirrelCol-1] == '*')
        {
            squirrelCol--;
            continue;
        }
        squirrelCol--;
    }
    else if (command == "right")
    {
        if (squirrelCol == field.GetLength(1) - 1)
        {
            IsOutOfField = true;
            Console.WriteLine("The squirrel is out of the field.");
            break;
        }

        if (field[squirrelRow, squirrelCol + 1] == 't')
        {
            steppedOnTrap = true;
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            break;
        }

        if (field[squirrelRow, squirrelCol + 1] == 'h')
        {
            hazelnutsCount++;
            field[squirrelRow, squirrelCol + 1] = '*';
            squirrelCol++;

            if (hazelnutsCount == 3)
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
                break;
            }

            continue;
        }

        if (field[squirrelRow, squirrelCol + 1] == '*')
        {
            squirrelCol++;
            continue;
        }
        squirrelCol++;
    }
}

if (hazelnutsCount < 3 && !steppedOnTrap && !IsOutOfField)
{
    Console.WriteLine("There are more hazelnuts to collect.");
}

Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");



