using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class UIHandler : MonoBehaviour
{
[SerializeField] private Text playerStats;
public static UIHandler instance;
private string savedPlayerName;
private int savedPlayerScore;
public InputField playerNameInputField;
[SerializeField] private GameObject mainMenuUI;
[SerializeField] private GameObject nameAndHighScore;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Load();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        mainMenuUI.SetActive(false);
        nameAndHighScore.transform.localPosition = Vector3.up * 210;
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/Save.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            playerStats.text = ("Player: " + data.playerName + " | High Score: " + data.highScore);
        }
    }
}