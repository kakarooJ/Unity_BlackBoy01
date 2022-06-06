using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UvGenerator : MonoBehaviour
{
    public GameObject uvPrefab;
    float span = 1.5f;  //1.0f = 1초
    float delta = 0;
    
    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span) {
            this.delta = 0;
            GameObject uv = Instantiate(uvPrefab) as GameObject;
            int locX = Random.Range(-11, 11);
            uv.transform.position = new Vector3(locX, 6, 0);
        }
        
    }
}
