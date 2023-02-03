using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameEnd : MonoBehaviour
{
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        score.text = "Score: " + PlayerPrefs.GetInt("score");
    }

    public void tryAgain()
    {
        SceneManager.LoadScene("Game");
    }
}
