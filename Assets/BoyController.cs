using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyController : MonoBehaviour
{
    public float speed = 3;
    float border = 0.01f;

    bool flipFlag = false;
    bool leftFlag = false;
    bool moveFlag = false;
    bool jumpFlag = false;
    bool stopFlag = false;

    float vx = 0;
    float vy = 0;

    Rigidbody2D rigid2D;
    float jumpForce = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        Common.playerJumpCount = 0;
        Common.medicineCount = 0;
    }

    public void LeftButtonDown() {
        //vx = 0;
        vx = -speed;            
        leftFlag = true;
        moveFlag = true;
    }

    public void RightButtonDown() {
        //vx = 0;
        vx = speed;            
        leftFlag = false;
        moveFlag = true;
    }

    public void JumpButtonDown() {
        //vx = 0;
        //vx = -speed;
        /*jumpFlag = true;
        if(moveFlag) {
            vx = (leftFlag) ? -speed : speed;
        } else {
            vx = 0;
        }*/
        Debug.Log("JUMP BUTTON");
        Common.playerJumpCount++;

        //if(this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }        
    }

    public void StopMovingButtonDown() {
        vx = 0;
        //vx = -speed;
        moveFlag = false;
        stopFlag = true;
        jumpFlag = false;
    }

    // Update is called once per frame
    void Update()
    {        
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f + border) pos.x = 0f + border;
        if (pos.x > 1f - border) pos.x = 1f - border;
        if (pos.y < 0f + border) pos.y = 0f + border;
        if (pos.y > 1f - border) pos.y = 1f - border*2;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
        
        /*
        vx = 0;
        vy = 0;
        if(Input.GetKey("right"))
        {
            //Debug.Log("right clicked");
            vx = speed;            
            leftFlag = false;
        }
        if(Input.GetKey("left"))
        {
            //Debug.Log("left clicked");
            vx = -speed;            
            leftFlag = true;
        }*/
        /*if(Input.GetKey("up"))
        {
            Debug.Log("up clicked");
            vy = speed;
            //leftFlag = false;
        }
        if(Input.GetKey("down"))
        {
            Debug.Log("down clicked");
            vy = -speed;
            //leftFlag = false;
        }*/
    }

    void FixedUpdate()  //1초에 50번씩 실행됨
    {
        if(moveFlag) {
            this.transform.Translate(vx/50, vy/50, 0);
            this.GetComponent<SpriteRenderer>().flipX = leftFlag;   //왼쪽 오른쪽 방향을 바꾼다.
        }
        //moveFlag = false;
    }

    void playSound() {
        if(AudioManager.instance == null) {
            Debug.Log("AudioManager.instance is null");
            return;
        }
        AudioManager.instance.playExplosion();
    }
}
