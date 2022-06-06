using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class UIHandler : MonoBehaviour
{
public static UIHandler instance;
[SerializeField] private GameObject mainMenuUI;
[SerializeField] private GameObject HighScore;
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
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        mainMenuUI.SetActive(false);
        HighScore.transform.localPosition = Vector3.up * 210;
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}