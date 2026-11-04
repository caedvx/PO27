using System;
using System.Collections.Generic;
using System.Text;

int rows = int.Parse(Console.ReadLine());
int columns = int.Parse(Console.ReadLine());
int updates = int.Parse(Console.ReadLine());

char[][] map = new char[rows][];
bool[,] connected = new bool[rows, columns];
Queue<(int Row, int Col)> toExplore = new Queue<(int Row, int Col)>();
int landmass = 0;

for (int row = 0; row < rows; row++)
{
    map[row] = Console.ReadLine().ToCharArray();
    int capitalColumn = Array.IndexOf(map[row], 'S');
    if (capitalColumn != -1)
    {
        Connect(row, capitalColumn);
    }
}

ExploreFromQueue();

StringBuilder output = new StringBuilder();
output.AppendLine(landmass.ToString());

for (int i = 0; i < updates; i++)
{
    string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    int row = int.Parse(parts[0]) - 1;
    int col = int.Parse(parts[1]) - 1;
    map[row][col] = '#';

    if (TouchesConnectedLand(row, col))
    {
        Connect(row, col);
        ExploreFromQueue();
    }

    output.AppendLine(landmass.ToString());
}

Console.Write(output);

void ExploreFromQueue()
{
    while (toExplore.Count > 0)
    {
        (int row, int col) = toExplore.Dequeue();
        TryConnect(row + 1, col);
        TryConnect(row - 1, col);
        TryConnect(row, col + 1);
        TryConnect(row, col - 1);
    }
}

void TryConnect(int row, int col)
{
    if (IsInside(row, col) && map[row][col] != '.' && !connected[row, col])
    {
        Connect(row, col);
    }
}

void Connect(int row, int col)
{
    connected[row, col] = true;
    toExplore.Enqueue((row, col));
    landmass++;
}

bool TouchesConnectedLand(int row, int col)
{
    if (connected[row, col])
    {
        return false;
    }
    return IsConnected(row + 1, col)
        || IsConnected(row - 1, col)
        || IsConnected(row, col + 1)
        || IsConnected(row, col - 1);
}

bool IsConnected(int row, int col)
{
    return IsInside(row, col) && connected[row, col];
}

bool IsInside(int row, int col)
{
    return row >= 0 && row < rows && col >= 0 && col < columns;
}
