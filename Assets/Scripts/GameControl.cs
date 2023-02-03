using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    public GameObject zombie;
    private float timeCounter;
    private float spawnTime = 10f;
    public Text scoreText;
    private int score;
    void Start()
    {
        timeCounter = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter -= Time.deltaTime ;
        if (timeCounter< 0)
        {
            Vector3 pos = new Vector3(Random.Range(200,326),22,Random.Range(190,300));
            Instantiate(zombie,pos,Quaternion.identity);
            timeCounter = spawnTime;
        }
    }

    public void scoreInc(int p)
    {
        score += p;
        scoreText.text = "" + score;
    }
    public void gameEnd()
    {
        PlayerPrefs.SetInt("score",score);
        SceneManager.LoadScene("GameEnd");
    }
}
