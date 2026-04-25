using UnityEngine;
using UnityEngine.UI;
public class DisplayHighScore : MonoBehaviour
{

    public int GameScore;
    Text ScoreText;
    void Start()
    {
        GameScore = HighScore_Kanri.GetHighScore();
        ScoreText = GetComponent<Text>();
        ScoreText.text = string.Format("{0:D4}", GameScore);
    }

   
}
