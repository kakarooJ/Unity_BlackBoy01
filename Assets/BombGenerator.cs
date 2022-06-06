using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    public GameObject bombPrefab;
    float span = 1.0f;  //1초
    float delta = 0;
    
    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span) {
            this.delta = 0;
            GameObject bomb = Instantiate(bombPrefab) as GameObject;
            int locX = Random.Range(-12, 12);
            bomb.transform.position = new Vector3(locX, 6, 0);
        }
        
    }
}
