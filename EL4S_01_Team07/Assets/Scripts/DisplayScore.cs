using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public static int GameScore;
    public static int Score_Test = 1;


    Text ScoreText;

    void Start()
    {
        GameScore = Score_Test;
        
        if (GameScore>=9999)
        {
            GameScore = 9999;
        }
        ScoreText = GetComponent<Text>();
        ScoreText.text = string.Format("{0:D4}", GameScore);

        if (GameScore > HighScore_Kanri.GetHighScore())
        {
            HighScore_Kanri.SetHighScore(GameScore);
        }
    }

    //void Update()
    //{
    //   
    //    ScoreText.text = string.Format("{0:D4}", Score_Test);
    //    Score_Test += 9;
    //    if (Score_Test >= GameScore)
    //    {
    //        Score_Test = GameScore;
    //    }
    //}
}
