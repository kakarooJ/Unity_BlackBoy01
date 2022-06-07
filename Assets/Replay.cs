using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //LoadScene 을 사용하는 데 필요

public class Replay : MonoBehaviour
{
    public void onClickReplayButton() {
        //SceneManager.LoadScene("GameScene");        
        StartCoroutine(loadScene());
    }

    public void onClickExitButton() {
        Application.Quit();
    }

    IEnumerator loadScene() {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("GameScene");
    }
}
