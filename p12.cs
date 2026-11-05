using System;
using System.Collections.Generic;
using System.Linq;

int beats = int.Parse(Console.ReadLine());
List<(char move1, char move2)> beatMoves = new List<(string, string)>();
for (int i = 0; i < beats; i++)
{
    string moves = Console.ReadLine();
    if (moves.Length == 2)
    {
        beatMoves.Add((moves[0], moves[1]));
    }
    else
    {
        beatMoves.Add((moves[0]), null);
    }
}

List<(char lfp, char rfp, int moves, int beats)> stateQueue = new List<(char, char, int, int)>();
stateQueue.Add(('V', 'H', 0, 0));

(char lfp, char rfp, int moves, int beats) Move((char lfp, char rfp, int moves, int beats) state)
{
    if (beatMoves[beats].move2 == null)
    {
        if (beatMoves[beats].move1 != rfp && beatMoves[beats].move1 != rfp)
        {
            state.moves++;
            stateQueue.Add((beatMoves[beats].move1, state.rfp));
            stateQueue.Add((state.lfp, beatMoves[beats].move1));
        }
    }
    else
    {
        
    }
}