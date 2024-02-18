using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChanger : MonoBehaviour
{
    //4 start,5gameplay,6over
    int score;
    public TextMeshProUGUI scoretext;

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        scoretext.text = "Score: " + score.ToString();
    }

    public void startGame()
    {
        SceneManager.LoadScene(5);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(4);
    }
}
