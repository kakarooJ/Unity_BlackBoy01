using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineGenerator : MonoBehaviour
{
    public GameObject medicinePrefab;
    float span = 3.5f;  //시간 간격 1.0f = 1초
    float delta = 0;
    
    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span) {
            this.delta = 0;
            GameObject uv = Instantiate(medicinePrefab) as GameObject;
            int locX = Random.Range(-9, 9);
            uv.transform.position = new Vector3(locX, 6, 0);
        }
        
    }
}
