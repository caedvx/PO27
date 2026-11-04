using System;
using System.Linq;
using System.Collections.Generic;
int rows = int.Parse(Console.ReadLine());
int columns = int.Parse(Console.ReadLine());
int updates = int.Parse(Console.ReadLine());
char[][] map = new char[rows][];
int[] landmasses = new int[updates + 1];
int[] capitalCoordinates = new int[2];
for (int row = 0; row < rows; row++)
{
    map[row] = Console.ReadLine().ToCharArray();
    if (map[row].Contains('S'))
    {
        for (int col = 0; col < columns; col++)
        {
            if (map[row][col] == 'S')
            {
                capitalCoordinates[0] = row;
                capitalCoordinates[1] = col;
            }
        }
    }
}

landmasses[0] = GetLandmass(map);

for (int i = 0; i < updates; i++)
{
    int[] coordinates = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    int row = coordinates[0];
    int col = coordinates[1];
    map[row - 1][col - 1] = '#';
    landmasses[i + 1] = GetLandmass(map);
}

foreach (int landmass in landmasses)
{
    Console.WriteLine(landmass);
}

int GetLandmass(char[][] map)
{
    bool[,] visited = new bool[rows, columns];
    List<(int Row, int Col)> coordinateQueue = new List<(int, int)>();

    coordinateQueue.Add((capitalCoordinates[0], capitalCoordinates[1]));
    visited[capitalCoordinates[0], capitalCoordinates[1]] = true;
    int landmass = 0;
    for (int i = 0; i < coordinateQueue.Count; i++)
    {
        int row = coordinateQueue[i].Row;
        int column = coordinateQueue[i].Col;
        if (row + 1 < rows && !visited[row + 1, column] && (map[row + 1][column] == '#' || map[row + 1][column] == 'S'))
        {
            coordinateQueue.Add((row + 1, column));
            visited[row + 1, column] = true;
        }
        if (row - 1 >= 0 && !visited[row - 1, column] && (map[row - 1][column] == '#' || map[row - 1][column] == 'S'))
        {
            coordinateQueue.Add((row - 1, column));
            visited[row - 1, column] = true;
        }
        if (column + 1 < columns && !visited[row, column + 1] && (map[row][column + 1] == '#' || map[row][column + 1] == 'S'))
        {
            coordinateQueue.Add((row, column + 1));
            visited[row, column + 1] = true;
        }
        if (column - 1 >= 0 && !visited[row, column - 1] && (map[row][column - 1] == '#' || map[row][column - 1] == 'S'))
        {
            coordinateQueue.Add((row, column - 1));
            visited[row, column - 1] = true;
        }
        if (map[row][column] == '#' || map[row][column] == 'S')
        {
            landmass++;
            visited[row, column] = true;
        }
    }
    return landmass;
}