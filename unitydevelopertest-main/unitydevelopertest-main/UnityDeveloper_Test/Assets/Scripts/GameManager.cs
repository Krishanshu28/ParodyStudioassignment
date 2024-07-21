using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Timer timer;

    public GameObject gameOverText;

    public int noOfCubes = 5;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if(timer.remainingTime == 0 && noOfCubes != 0)
        {
            GameOver();
        }
        CheckFall();
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator CheckFall()
    {
        if(!Player.player.isGrounded)
        {
            print(1);
            yield return new WaitForSeconds(5f);
            if (!Player.player.isGrounded)
            {
                GameOver();
            }
        }
    }
}
