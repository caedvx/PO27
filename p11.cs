using System;
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

bool[,] visited = new bool[r,c];
visited[0,0] = true;

List<(int x, int y, int dir)> stateQueue = new List<(int, int, int)>();

for (int i = 0; i < stateQueue.Count; i++)
{
    Glide(stateQueue[i]);
    if (x == c && dir == 2) break;
}
//Gotta figure out the counting but gotta sleep for now

void Glide(int x, int y, int dir)
{
    switch (dir)
    {
        case 1:
            while (y > 0 && map[y - 1][x] =='.')
            {
                y--;
                visited[x,y] = true;
            }
            if (!visited[x + 1, y] && map[y][x + 1] == '.')
                stateQueue.Add(x,y, 2);
            if (!visited[x - 1, y] && map[y][x - 1] == '.')
                stateQueue.Add(x,y, 4);

        case 2:
            while (x < c - 1 && map[y][x+1] == '.')
            {
                x++;
                visited[x,y] = true;
            }
            if (x == c)
            {
                
            }
            if (!visited[x, y + 1] && map[y + 1][x] == '.')
            {
                stateQueue.Add(x,y, 3);
            } 
            if (!visited[x, y - 1] && map[y - 1][x] == '.')
            {
                stateQueue.Add(x,y, 1);
            }

        case 3:
            while (y < r - 1 && map[y + 1][x] == '.')
            {
                y++;
                visited[x,y] = true;
            }
            if (!visited[x + 1, y] && map[y][x + 1] == '.')
                stateQueue.Add(x,y, 2);
            if (!visited[x - 1, y] && map[y][x - 1] == '.')
                stateQueue.Add(x,y, 4);

        case 4:
            while (x > 0 && map[y][x-1] == '.')
            {
                x--;
                visited[x,y] = true;
            }
            if (!visited[x, y + 1] && map[y + 1][x] == '.')
                stateQueue.Add(x,y, 3);
            if (!visited[x, y - 1] && map[y - 1][x] == '.')
                stateQueue.Add(x,y, 1);    
    }

}