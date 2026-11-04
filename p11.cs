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

// TODO 7: created as [r, c] = [row, column], but used below as [x, y] = [column, row]. Crashes on non-square rinks.
// TODO 8: a state is (cell, direction). Should this track direction too? And which cells need marking: every cell slid over, or only where she stops?
bool[,] visited = new bool[r,c];
visited[0,0] = true;

// TODO 1: List needs a using that's missing up top. Which one did p13 use?
// TODO 11: counting turns: what if the tuple had a fourth number?
List<(int x, int y, int dir)> stateQueue = new List<(int, int, int)>();

// TODO 6: queue starts empty, so this loop never runs. What has to be in it first?
for (int i = 0; i < stateQueue.Count; i++)
{
    // TODO 2: Glide takes 3 separate ints, this passes one tuple.
    Glide(stateQueue[i]);
    // TODO 3: x and dir only exist inside Glide.
    if (x == c && dir == 2) break;
}
//Gotta figure out the counting but gotta sleep for now

// OPTIONAL: cases 1-4 are the same code with different directions. dRow/dCol arrays would make them one block,
// so TODOs 8-10 get fixed once instead of four times.
void Glide(int x, int y, int dir)
{
    switch (dir)
    {
        // TODO 4: every case must end with break or return, no falling into the next case.
        case 1:
            // TODO 10: this loop stops for two reasons: hit '#', or reached the edge. Only '#' allows a turn.
            // North/south/west edge = skated off = dead end. East edge = goal.
            while (y > 0 && map[y - 1][x] =='.')
            {
                y--;
                visited[x,y] = true;
            }
            // TODO 9: what does [x + 1] / [x - 1] do on the last / first column? (same in every case below)
            if (!visited[x + 1, y] && map[y][x + 1] == '.')
                // TODO 5: Add takes one item, here a tuple. How is a tuple written in brackets?
                stateQueue.Add(x,y, 2);
            if (!visited[x - 1, y] && map[y][x - 1] == '.')
                stateQueue.Add(x,y, 4);

        case 2:
            while (x < c - 1 && map[y][x+1] == '.')
            {
                x++;
                visited[x,y] = true;
            }
            // TODO 10: the while above stops at c - 1, so x == c is never true.
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