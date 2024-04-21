using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "HighScore", menuName = "ScriptableObjects/HighScore", order = 3)]
public class HighScoreSO : ScriptableObject
{
    [SerializeField] private List<int> scores = new List<int>(10);

    public void AddScore(int score)
    {
        bool added = false;
        for (int i = 0; i < scores.Count; i++)
        {
            if (score > scores[i])
            {
                scores.Insert(i, score);
                added = true;
                break;
            }
        }
        if (!added)
        {
            scores.Add(score);
        }

        if (scores.Count > 10)
        {
            scores.RemoveAt(scores.Count - 1);
        }
    }

    public List<int> GetScores()
    {
        return scores;
    }
}
