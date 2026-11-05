using System;
using System.Collections.Generic;
using System.Linq;

int beats = int.Parse(Console.ReadLine());
List<(char move1, char move2)> beatMoves = new List<(char, char)>();
for (int i = 0; i < beats; i++)
{
    string moves = Console.ReadLine();
    if (moves.Length == 2)
    {
        beatMoves.Add((moves[0], moves[1]));
    }
    else
    {
        beatMoves.Add((moves[0], '0'));
    }
}

List<(char lfp, char rfp, int moves, int beats)> stateQueue = new List<(char, char, int, int)>();
stateQueue.Add(('V', 'H', 0, 0));
for (int i = 0; i < stateQueue.Count; i++)
{
    (int beat, int moves) endState = Move((stateQueue[i]));
    if (endState.beat == beats)
    {
        Console.WriteLine(endState.moves);
    }
}

(int beat, int moves) Move((char lfp, char rfp, int moves, int beats) state)
{
    if (beatMoves[state.beats].move2 == '0')
    {
        if (beatMoves[state.beats].move1 != state.lfp && beatMoves[state.beats].move1 != state.rfp)
        {
            stateQueue.Add((beatMoves[state.beats].move1, state.rfp, state.moves + 1, state.beats + 1));
            stateQueue.Add((state.lfp, beatMoves[state.beats].move1, state.moves + 1, state.beats + 1));
        }
    }
    else
    {
        if (beatMoves[state.beats].move1 != state.rfp && beatMoves[state.beats].move2 != state.lfp && beatMoves[state.beats].move1 != state.lfp && beatMoves[state.beats].move2 != state.rfp)
        {
            stateQueue.Add((beatMoves[state.beats].move1, beatMoves[state.beats].move2, state.moves + 1, state.beats + 1));
            stateQueue.Add((beatMoves[state.beats].move2, beatMoves[state.beats].move1, state.moves + 1, state.beats + 1));
        }
        else if (beatMoves[state.beats].move1 == state.rfp && beatMoves[state.beats].move2 != state.lfp)
        {
            stateQueue.Add((beatMoves[state.beats].move2, state.rfp, state.moves + 1, state.beats + 1));
        }
        else if  (beatMoves[state.beats].move1 == state.lfp && beatMoves[state.beats].move2 != state.rfp)
        {
            stateQueue.Add((state.lfp, beatMoves[state.beats].move2, state.moves + 1, state.beats + 1));
        }
        else if (beatMoves[state.beats].move2 == state.rfp && beatMoves[state.beats].move1 != state.lfp)
        {
            stateQueue.Add((beatMoves[state.beats].move1, state.rfp, state.moves + 1, state.beats + 1));
        }
        else if  (beatMoves[state.beats].move2 == state.lfp && beatMoves[state.beats].move1 != state.rfp)
        {
            stateQueue.Add((state.lfp, beatMoves[state.beats].move1, state.moves + 1, state.beats + 1));
        }
        else
        {
            stateQueue.Add((state.lfp, state.rfp, state.moves, state.beats + 1));
        }
    }
}