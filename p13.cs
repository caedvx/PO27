using System;
using System.Collections.Generic;
using System.Linq;

int n = int.Parse(Console.ReadLine());
List<int>[] adj = new List<int>[n];

for (int i = 0; i < n; i++)
{
    adj[i] = new List<int>();
}

for (int i = 0; i < n - 1; i++)
{
    int[] route = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    adj[route[0]].Add(route[1]);
    adj[route[1]].Add(route[0]);
}

int[] order = new int[n];
int[] parent = new int[n];
int head = 0;
int tail = 1; 
order[0] = 0;
parent[0] = -1;

while (head < tail)
{
    int v = order[head];
    head++;
    foreach (int u in adj[v])
    {
        if (u != parent[v])
        {
            parent[u] = v;
            order[tail] = u;
            tail++;
        }
    }
}

int[] height = new int[n];
for (int i = 0; i < n; i++)
{
    height[i] = 1;
}

for (int i = n - 1; i > 0; i--)
{
    int v = order[i];
    int p = parent[v];
    height[p] = Math.Max(height[p], height[v] + 1);
}

int[] tallestChild = new int[n];
for (int i = 0; i < n; i++)
{
    tallestChild[i] = -1;
}

for (int i = 1; i < n; i++)
{
    int v = order[i];
    int p = parent[v];
    if (tallestChild[p] == -1 || height[v] > height[tallestChild[p]])
    {
        tallestChild[p] = v;
    }   
}

List<int> chains = new List<int>();
for (int v = 1; v < n; v++)
{
    if (v != tallestChild[parent[v]])
    {
        chains.Add(height[v]);
    }
}
chains.Add(height[tallestChild[0]]);
chains.Sort();
chains.Reverse();
List<int> output = new List<int>();
for (int i = 0; i < chains.Count; i++)
{
    for (int j = 0; j < chains[i]; j++)
    {
        output.Add(i + 1);
    }
}
Console.WriteLine(string.Join(' ', output));