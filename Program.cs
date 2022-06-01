namespace MazeSolvingAlgorithm;

class Program
{
    static char[,] labyrinth =
    {
        {' ', ' ', ' '},
        {'*', '*', ' '},
        {' ', ' ', ' '},
        {' ', ' ', 'e'}
    };

    static void Main()
    {
        FindPath(0, 0, 's');
    }

    static char[] path = new char[labyrinth.GetLength(0) * labyrinth.GetLength(1)];
    static int position = 0;

    static void FindPath(int row, int col, char direction)
    {
        if (row < 0 || col < 0 || row >= labyrinth.GetLength(0) || col >= labyrinth.GetLength(1))
        {
            return;
        }

        path[position] = direction;
        position++;
        if (labyrinth[row, col] == 'e')
        {
            PrintDirections(path, 1, position - 1);
        }

        if (labyrinth[row, col] == ' ')
        {
            labyrinth[row, col] = 's';

            FindPath(row, col - 1, 'L');
            FindPath(row - 1, col, 'U');
            FindPath(row, col + 1, 'R');
            FindPath(row + 1, col, 'D');

            labyrinth[row, col] = ' ';
        }
        position--;
    }

    static void PrintDirections(char[] path, int start, int end)
    {
        Console.Write("Find path to the exit: ");
        for (var i = start; i <= end; i++)
        {
            Console.Write(path[i]);
        }
        Console.WriteLine();
    }
}