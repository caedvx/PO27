using System;
using System.Collections.Generic;
using System.Linq;

int beats = int.Parse(Console.ReadLine());
List<(int move1, int move2)> beatMoves = new List<(int, int)>();
for (int i = 0; i < beats; i++)
{
    string sMoves = Console.ReadLine();
    int[] moves = new int[2];
    switch (sMoves[0])
    {
        case 'U':
        moves[0] = 0;
        break;

        case 'H':
        moves[0] = 1;
        break;

        case 'N':
        moves[0] = 2;
        break;

        case 'V':
        moves[0] = 3;
        break;
    }
    if (sMoves.Length == 2)
    {
        switch(sMoves[1])
        {
            case 'U':
            moves[1] = 0;
            break;

            case 'H':
            moves[1] = 1;
            break;

            case 'N':
            moves[1] = 2;
            break;

            case 'V':
            moves[1] = 3;
            break;
        }
    }
    else 
    {
        moves[1] = -1;
    }
    beatMoves.Add((moves[0], moves[1]));
}

int[,,] cost1Move = new int[4,4,4];
int[,,,] cost2Moves = new int[4,4,4,4];

for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        for (int k = 0; k < 4; k++)
        {
            if (i==j) continue;
            bool leftMatchesNew = (i == k);
            bool rightMatchesNew = (j == k);
            if (!leftMatchesNew && !rightMatchesNew)
            {
                cost1Move[i,j,k] = 1;
            }
            else cost1Move[i,j,k] = 0;
        }
    }
}

for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        for (int k = 0; k < 4; k++)
        {
            for (int l = 0; l < 4; l++)
            {
                if (i==j) continue;
                bool leftMatchesNew1 = (i == k);
                bool leftMatchesNew2 = (i == l);
                bool rightMatchesNew1 = (j == k);
                bool rightMatchesNew2 = (j == l);
                bool bothMatchNew = (leftMatchesNew1 && rightMatchesNew2 || rightMatchesNew1 && leftMatchesNew2);
                bool oneMatchesNew = (leftMatchesNew1 || rightMatchesNew1 || leftMatchesNew2 || rightMatchesNew2) ;
                if (bothMatchNew)
                {
                    cost2Moves[i,j,k,l] = 0;
                }
                else if (oneMatchesNew)
                {
                    cost2Moves[i,j,k,l] = 1;
                }
                else 
                {
                    cost2Moves[i,j,k,l] = 2;
                }
            }
        }
    }
}

int[,] currentCost = new int[4,4];
int[,] nextCost = new int[4,4];
for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        currentCost[i,j] = int.MaxValue/2;
        nextCost[i,j] = int.MaxValue/2;
    }
}
nextCost[3,1] = 0;

for (int i = 0; i < beatMoves.Count; i++)
{
    int move1 = beatMoves[i].move1;
    int move2 = beatMoves[i].move2;

    for (int L = 0; L < 4; L++)
    {
        for (int R = 0; R < 4; R++)
        { 
            currentCost[L,R] = nextCost[L,R];
            nextCost[L,R] = int.MaxValue/2;
             
        }
    }

    for (int L = 0; L < 4; L++)
    {
        for (int R = 0; R < 4; R++)
        {
            
            if (currentCost[L,R] == int.MaxValue/2) continue;
            bool isSingleMove = (move2 == -1);
            bool moveCosts = (cost1Move[L, R, move1] > 0);
            if (isSingleMove && moveCosts) 
            { 
                nextCost[L, move1] = Math.Min(nextCost[L, move1], 1 + currentCost[L, R]);
                nextCost[move1, R] = Math.Min(nextCost[move1, R], 1 + currentCost[L, R]);
            }
            else if (isSingleMove)
            {
                nextCost[L, R] = Math.Min(nextCost[L,R], currentCost[L, R] + cost1Move[L, R, move1]);
            }
            else
            {
                int nL = L;
                int nR = R;
                switch (cost2Moves[L, R, move1, move2])
                {
                    case 0:
                    break;

                    case 1:
                    if (L == move1) nR = move2;
                    else if (L == move2) nR = move1;
                    else if (R == move1) nL = move2;
                    else nL = move1;
                    break;

                    case 2:
                    nL = move1;
                    nR = move2;
                    break;
                }
                nextCost[nL, nR] = Math.Min(nextCost[nL,nR], currentCost[L, R] + cost2Moves[L, R, move1, move2]);
            }
        }
    }
}

List<int> costs = new List<int>();
foreach (int i in nextCost)
{
    costs.Add(i);
}

costs.Sort();
Console.WriteLine(costs[0]);