using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenu : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;
    public void Start()
    {
        if (BestScoreManager.Instance != null)
        {
            BestScoreText.text = BestScoreManager.Instance.bestScoreString;
        }
    }
    public void startGame()
    {
        SceneManager.LoadScene("main");
    }

    public void exitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void nameInput(string name)
    {
        BestScoreManager.Instance.setUserName(name);
    }

}
