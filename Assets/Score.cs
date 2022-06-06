using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int bestScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        int score = GameDirector.curScore;

        if(score > bestScore) {
            bestScore = score;
        }


        updateScore(score, "Score: ", GameObject.Find("TextUI_CurScore"));
        updateScore(bestScore, "Best:   ", GameObject.Find("TextUI_BestScore"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void updateScore(float score, string prefix, GameObject obj) {
        /*int minute = (int)score / 60;

        int second = (int)score - (minute*60);
        int second1 = second / 10;
        int second2 = second % 10;                    

        if(obj != null) {
            obj.GetComponent<Text>().text = 
            prefix + (minute.ToString("D2") + " : " + second1.ToString() + second2.ToString());
        } else {
            Debug.Log("Score:: obj is null");
        }*/

        if(obj != null) {
            obj.GetComponent<Text>().text = prefix + score.ToString();
        } else {
            Debug.Log("Score:: obj is null");
        }
        
    }
}
