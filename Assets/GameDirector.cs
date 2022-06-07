using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI를 사용하므로 꼭 추가해야 한다.
using UnityEngine.SceneManagement;  //LoadScene 을 사용하는 데 필요
using System;

public class GameDirector : MonoBehaviour
{
    GameObject GameObj_HpGauge;
    GameObject GameObj_LifeCount;
    GameObject GameObj_Score;

    GameObject GameObj_JumpCount;
    GameObject GameObj_MedicineCount;

    GameObject GameObj_PauseGame;
    GameObject GameObj_ResumeGame;
    
    float ratio;    
    float scoreTime;
    int timeCount;  //1초에 1증가

    public static bool bPause = false;

    public int maxLifeCount = 10;
    public Image hpImage;

    public static int lifeCount = 0;
    public static int curScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObj_HpGauge = GameObject.Find("ImageUI_HpGauge");        

        GameObj_PauseGame = GameObject.Find("PauseButton");
        GameObj_ResumeGame = GameObject.Find("ResumeButton");
        
        bPause = false;
        GameObj_PauseGame.SetActive(true);
        GameObj_ResumeGame.SetActive(false);

        GameObj_LifeCount = GameObject.Find("TextUI_LifeCount");
        GameObj_Score = GameObject.Find("TextUI_Score");

        GameObj_JumpCount = GameObject.Find("TextUI_JumpCount");
        GameObj_MedicineCount = GameObject.Find("TextUI_MedicineCount");

        GameObject.Find("TextUI_JumpScore").GetComponent<Text>().text = "x" + Common.jumpScore.ToString();
        GameObject.Find("TextUI_MedicineScore").GetComponent<Text>().text = "x" + Common.medicineScore.ToString();        

        curScore = 0;
        scoreTime = 0.0f;

        lifeCount = maxLifeCount;
        ratio = 1.0f / maxLifeCount;
        hpImage = GameObj_HpGauge.GetComponent<Image>();
        GameObj_LifeCount.GetComponent<Text>().text = lifeCount.ToString();
    }

    void Update() {
        scoreTime += Time.deltaTime;
        int timeScore = (int)Math.Floor(scoreTime);

        if(timeScore > 0) {            
            scoreTime = 0.0f;
            timeCount++;
        }

        curScore = calculateScore();

        GameObj_Score.GetComponent<Text>().text = "Score: " + curScore.ToString();

        GameObj_JumpCount.GetComponent<Text>().text = Common.playerJumpCount.ToString();
        GameObj_MedicineCount.GetComponent<Text>().text = Common.medicineCount.ToString();
        
/*
        int minute = (int)scoreTime / 60;

        int second = (int)scoreTime - (minute*60);
        int second1 = second / 10;
        int second2 = second % 10;                    

        UI_timeLine.GetComponent<Text>().text = 
            (minute.ToString("D2") + " : " + second1.ToString() + second2.ToString());
*/
    }

    int calculateScore() {
        int value = 0;
        value += timeCount;
        value += getAdditionalScore();

        return value;
    }

    int getAdditionalScore() {
        int value = 0;

        value += Common.playerJumpCount * Common.jumpScore;   //jump는 1회당 5점
        value += Common.medicineCount * Common.medicineScore;
        //TODO

        return value;
    }

    public void onClickPauseResumeButton() {
        Debug.Log("onClickPauseResumeButton:: " + bPause);
        
        if(bPause) {
            GameObj_PauseGame.SetActive(true);
            GameObj_ResumeGame.SetActive(false);                
            //TODO : Game Start
            Time.timeScale = 1;
            bPause = false;
        } else {
            GameObj_PauseGame.SetActive(false);
            GameObj_ResumeGame.SetActive(true);
            //TODO : Game Start
            Time.timeScale = 0;
            bPause = true;
        }   
    }

    public void onClickStopGameButton() {
        Debug.Log("onClickStopGameButton");
        SceneManager.LoadScene("StartScene");
    }

    public void decreaseHP(int level) {
        Debug.Log("decreaseHP " + lifeCount);
        Color prev = hpImage.color;
        float value = ratio* level;
        hpImage.color = new Color(prev.r-value, prev.g-value, prev.b-value, prev.a-value);
        //this.GameObj_HpGauge.GetComponent<Image>().fillAmount -= 0.2f * level;
        lifeCount -= level;
        GameObj_LifeCount.GetComponent<Text>().text = lifeCount.ToString();
        
        if(lifeCount <= 0) {
            Debug.Log("Game over");            
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void increaseHP(int level) {
        Debug.Log("increaseHP " + lifeCount);
        if(lifeCount < maxLifeCount) {
            Color prev = hpImage.color;
            float value = ratio * level;
            hpImage.color = new Color(prev.r+value, prev.g+value, prev.b+value, prev.a+value);
            //this.GameObj_HpGauge.GetComponent<Image>().fillAmount += 0.2f * level;
            lifeCount += level;
            GameObj_LifeCount.GetComponent<Text>().text = lifeCount.ToString();
        }
    }

}
