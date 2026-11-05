using System;
using System.Collections.Generic;
using System.Linq;

int[] rc = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int r = rc[0];
int c = rc[1];
char[][] map = new char[r][];
for (int i = 0; i < r; i++)
{
    map[i] = Console.ReadLine().ToCharArray();
}

bool[,,] visited = new bool[c, r, 4];

List<(int x, int y, int dir, int turns)> stateQueue = new List<(int, int, int, int)>();
stateQueue.Add((0, 0, 2, 0));

for (int i = 0; i < stateQueue.Count; i++)
{
    (int x, int y, int dir, int turns) endState = Glide(stateQueue[i].x, stateQueue[i].y, stateQueue[i].dir, stateQueue[i].turns);
    
    if (endState.x == c - 1 && endState.dir == 2) 
    {
        Console.WriteLine(endState.turns); 
        break;
    }
}

(int x, int y, int dir)? NextCoordinates(int column, int row, int dir)
{
    switch(dir % 4)
    {
        case 1:
        if (row > 0) return (column, row - 1, dir);
        break;

        case 2:
        if (column < c - 1) return (column + 1, row, dir);
        break;
        
        case 3:
        if (row < r - 1) return (column, row + 1, dir);
        break;
        
        case 0:
        if (column > 0) return (column - 1, row, dir);
        break;
    }
    return null;
}

(int x, int y, int dir, int turns) Glide(int x, int y, int dir, int turns)
{
    while (NextCoordinates(x, y, dir) is (int nextX, int nextY, int nextDir) newCoords)
    {
        if (visited[x, y, dir]) break;
        if (map[nextY][nextX] != '.')
        {
            visited[x, y, dir] = true;
            if (NextCoordinates(x, y, (dir + 3) % 4) != null)
            {
                (int x, int y, int dir) turnLeft = NextCoordinates(x, y, (dir + 3) % 4).Value;
                if (!visited[turnLeft.x, turnLeft.y, turnLeft.dir] && map[turnLeft.y][turnLeft.x] == '.')
                {
                    stateQueue.Add((turnLeft.x, turnLeft.y, turnLeft.dir, turns + 1));
                }
            }
            if (NextCoordinates(x, y, (dir + 1) % 4) != null)
            {
                (int x, int y, int dir) turnRight = NextCoordinates(x, y, (dir + 1) % 4).Value;
                if (!visited[turnRight.x, turnRight.y, turnRight.dir] && map[turnRight.y][turnRight.x] == '.')
                {
                    stateQueue.Add((turnRight.x, turnRight.y, turnRight.dir, turns + 1));
                }
            }
            return (x, y, dir, turns);
        }
        x = nextX;
        y = nextY;
    }
    return (x, y, dir, turns);
}