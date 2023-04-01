using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static System.Action GameStarted;
    public static System.Action<bool> GamePaused;
    public static System.Action GameOver;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
