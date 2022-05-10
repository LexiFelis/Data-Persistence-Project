using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CURRENTLY UNUSED
// Class for scores, for future hi-score table implementation.
public class Scores : ScoreManager
{
    public string playerName;
    public int playerScore;

    public Scores (string aName, int aScore)
    {
        playerName = aName;
        playerScore = aScore;
    }
}
