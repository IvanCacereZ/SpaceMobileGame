using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "HighScore", menuName = "ScriptableObjects/HighScore", order = 3)]
public class HighScoreSO : ScriptableObject
{
    [SerializeField] private List<int> scores = new List<int>(10);
    public NotificactionSO notificationSystem;
    private int iterations = 0;

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
            iterations++;
        }
        if (!added)
        {
            if(iterations==0)
                notificationSystem._Text = "Se ha dado un nuevo puntaje maximo de: " + score;
            else
                notificationSystem._Text = "Se ha dado una nueva puntuacion de: " + score + " de posicion " + iterations;

            notificationSystem.SendNotification();
        }

        if (scores.Count > 10)
        {
            scores.RemoveAt(scores.Count - 1);
        }
        iterations = 0;
    }

    public List<int> GetScores()
    {
        return scores;
    }
}
