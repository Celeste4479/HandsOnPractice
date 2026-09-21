using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public string GetCurrentSceneName() => SceneManager.GetActiveScene().name;

    public void NextScene()
    {
		SceneManager.LoadScene(GetCurrentSceneName() switch
        {
            "Title" => "Lobby",
			"Lobby" => "Play",
            "Play"  => "Lobby",
            _       => "Title"
		});
	}    
}
