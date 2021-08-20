using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageUi : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] GameObject restartButton;
    [SerializeField] Text timetxt;
    [SerializeField] GameObject realod;

    private GameManagement gameManagement;

    private void Start()
    {
        gameManagement = FindObjectOfType<GameManagement>();
        StartCoroutine(TimeDiscount());
       // restartButton.onClick.AddListener(TaskOnClick);
    }

    private IEnumerator TimeDiscount()
    {
        int timeByMinut;
        int timeBySecond;
        while (true) { 
        timeByMinut = gameManagement.time / 60;
        timeBySecond = gameManagement.time % 60;
        timetxt.text = string.Concat("Time : ", timeByMinut.ToString(), ":", timeBySecond.ToString());
        gameManagement.time--;
            if (gameManagement.time == 0)
                DieUi();
            yield return new WaitForSeconds(1f);
        }
    }

    public void updateScore(int i)
    {
        score.text = string.Concat("score : ", i.ToString()).ToUpper();
    }

    public void DieUi()
    {
        realod.SetActive(true);
        //restartButton.SetActive(true);
    }


    public void restart()
    {
        SceneManager.LoadScene("1-1");
    }
}
