using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandle : MonoBehaviour
{
    public Text bestScore;
    public Text playerName;

    private void Start()
    {
        bestScore.text = "BestScore: " + DataManager.Instance.GetData();
    }
    public void StartGame()
    {
        if (!playerName.text.Equals(""))
        {
            DataManager.Instance.playerName = playerName.text;
            SceneManager.LoadScene(1);
        }
        
    }
    public void Exit()
    {
        Application.Quit();
    }
}
