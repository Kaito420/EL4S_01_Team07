using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // 既存探索
                _instance = FindObjectOfType<ScoreManager>();

                // 無ければ生成
                if (_instance == null)
                {
                    var obj = new GameObject("ScoreManager");
                    _instance = obj.AddComponent<ScoreManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return _instance;
        }
    }

    public int Score { get; private set; }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnDestroy()
    {
        // 重要：破棄時にクリアしないと2周目で壊れる
        if (_instance == this)
        {
            _instance = null;
        }
    }

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

    public void ResetScore()
    {
        Score = 0;
    }
}