using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckGameOver : MonoBehaviour
{
    SceneChange SceneChange;
    [SerializeField] private PlayerController playerController;
    void Awake()
    {
        SceneChange = GetComponent<SceneChange>();
        //playerController = FindObjectOfType<PlayerController>();
    }



    void Update()
    {
        if (playerController.isAlive == false)
        {
            SceneChange.SceneChangeManager();
        }
    }
}
