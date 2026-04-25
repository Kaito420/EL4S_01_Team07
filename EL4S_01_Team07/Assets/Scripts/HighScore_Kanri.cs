using UnityEngine;

public class HighScore_Kanri : MonoBehaviour
{
    public static int highScore = 0;

    public static int GetHighScore()
    {
        return highScore;
    }
    public static void SetHighScore(int score)
    {
        highScore = score;
    }
}
