using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //LoadScene 을 사용하는 데 필요

public class StartGame : MonoBehaviour
{
    public void onClickStartGameButton() {
        //SceneManager.LoadScene("GameScene");        
        StartCoroutine(loadScene());
    }

    public void onClickExitGameButton() {
        Application.Quit();
    }

    IEnumerator loadScene() {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("GameScene");
    }
}
