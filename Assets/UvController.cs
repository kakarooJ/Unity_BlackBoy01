using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UvController : MonoBehaviour
{
    public float speed = 20;
    public int decreaseLevel = 2;

    GameObject boy;

    // Start is called before the first frame update
    void Start()
    {
        this.boy = GameObject.Find("Obj_PlayerBoy");
    }

    // Update is called once per frame
    void Update()
    {
        //FPS 환경에 따른 보정을 위해 Time.deltaTime 적용
        transform.Translate(0, speed *-0.1f * Time.deltaTime, 0);

        //화면 밖으로 나오면 오브젝트를 소멸시킨다.
        if(transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }

        //충돌 판정
        /*Vector2 p1 = transform.position;    //중심 좌표
        Vector2 p2 = this.boy.transform.position;
        Vector2 dir = p1 - p2;

        float distance = dir.magnitude;

        //반경
        float r_obj = 0.5f;
        float r_boy = 0.5f;

        if(distance < r_obj + r_boy) {  //충돌
            Debug.Log("충돌");
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().decreaseHP(2);
            
            //소멸
            Destroy(gameObject);
        }*/
    }

    void OnTriggerEnter2D(Collider2D obj) {
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().decreaseHP(decreaseLevel);

        playSound();
        
        //bomb 소멸
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D obj) {
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().decreaseHP(decreaseLevel);

        playSound();
        
        //소멸
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void playSound() {
        if(AudioManager.instance == null) {
            Debug.Log("AudioManager.instance is null");
            return;
        }
        AudioManager.instance.playExplosion();
    }
}
