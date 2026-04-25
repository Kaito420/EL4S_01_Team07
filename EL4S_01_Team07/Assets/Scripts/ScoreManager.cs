using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // インスタンス
    public static ScoreManager Instance { get; private set; }

    // スコア本体
    public int Score { get; private set; }

    void Awake()
    {
        // 既に存在する場合は破棄
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // シーン遷移しても保持したい場合
        DontDestroyOnLoad(gameObject);
    }

    // スコア加算
    public void AddScore(int value)
    {
        Score += value;
    }

    public int GetScore()
    {
        return Score;
    }

    public void SetScore(int value)
    {
        Score = value;
    }

    // スコアリセット
    public void ResetScore()
    {
        Score = 0;
    }
}