using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Animator anim = null;
    private Rigidbody2D rb = null;
    
    //private float speed = 5.0f;
    public GroundCheck ground; 
    private float gravity = 1.3f;
    private bool isGround = false;
    private bool isDown = false;
    private float jumpSpeed = 2.0f;
    private bool isJump = false;
    //private string enemyTag = "Enemy";
    private string deadAreaTag = "deadarea";
    private string goalTag = "goal";
    

    [SerializeField]
    private float dB_Min = -80.0f;

    
    [SerializeField]
    private float dB_Max = 20.0f;

    
    [SerializeField]
    private Audio micAS = null;

    void Start()
    {
        GManager.instance.timer = 0.0f;
        GManager.instance.timer2 = 0.0f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isDown)
        {
            
            isGround = ground.IsGround();
            
            float speed =   dB_ToFillAmountValue(micAS.now_dB);

            float xSpeed = 0.0f;
            float ySpeed = -gravity;


            //float ySpeed = 0.0f;
            if (speed > 0.8)
            {
                //transform.localScale = new Vector3(1, 1, 1);
                anim.SetBool("run", true);
                xSpeed = 7 * speed;

                //ySpeed = 3 * speed;
                if (isGround)
                {

                    if (speed > 0.9)
                    {
                        jumpSpeed = 40 * speed;
                        ySpeed = 3*jumpSpeed;
                        isJump = true;
                    }
                    else if (speed > 0.8)
                    {
                        jumpSpeed = 10 * speed;
                        ySpeed = 3*jumpSpeed;
                        isJump = true;
                    }
                    else
                    {
                        isJump = false;
                    }
                }
                else if (isJump)
                {
                    if (speed > 0.95)
                    {
                        jumpSpeed = 15 * speed;
                        ySpeed = 1.5f * jumpSpeed;
                    }
                    else if (speed > 0.8)
                    {
                        jumpSpeed = 10 * speed;
                        ySpeed = 1.5f * jumpSpeed;
                        isJump = true;
                    }
                    else
                    {
                        isJump = false;
                    }
                }
            }

            else if (speed > 0.7)
            {
                isJump = false;
                //transform.localScale = new Vector3(1, 1, 1);
                anim.SetBool("run", true);
                xSpeed = 10 * speed;
                //ySpeed = 3 * speed;
            }

            else if (speed > 0.5)
            {
                isJump = false;
                //transform.localScale = new Vector3(1, 1, 1);
                anim.SetBool("run", true);
                xSpeed = 5 * speed;
                //ySpeed = 3 * speed;
            }


            else if (speed > 0.4)
            {
                isJump = false;
                //transform.localScale = new Vector3(1, 1, 1);
                anim.SetBool("run", true);
                xSpeed = speed;
                //ySpeed = -5.0f;
            }

            else
            {
                isJump = false;
                anim.SetBool("run", false);
                xSpeed = 0.0f;
                //ySpeed = -5.0f;
            }
            //rb.velocity = new Vector2(xSpeed, ySpeed);
            anim.SetBool("jump", isJump);
            anim.SetBool("ground", isGround); //New
            rb.velocity = new Vector2(xSpeed, ySpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, -gravity);
        }


        }

    /*


    */


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == deadAreaTag)
        {
            
            Invoke("Call", 0.8f);

        }
        if (collision.tag == goalTag)
        {
            rb.velocity = new Vector2(0, 0);
            Invoke("down", 0.2f);
            
            Invoke("Call2", 0.6f);

        }


    }
    public void OnDamage()
    {
        
        anim.Play("onpudown_Animation");
        rb.velocity = new Vector2(0, -gravity);
        Invoke("Call", 0.8f);
        isDown = true;

    }

    public void OnfinishGame()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void down()
    {
        isDown = true;
    }

    

    public void Call()
    {
        OnfinishGame();
    }
    public void OnfinishGame2()
    {
        SceneManager.LoadScene("clear");
    }

    public void Call2()
    {
        OnfinishGame2();
    }

    public void ContinuePlayer()
    {
        isDown = false;
        anim.Play("player_stand");
        isJump = false;
    }


    float dB_ToFillAmountValue(float dB)
    {
        
        float modified_dB =  dB;
        
        if (modified_dB > dB_Max) { modified_dB = dB_Max; }
        else if (modified_dB < dB_Min) { modified_dB = dB_Min; }
        
        //dB_Min=0.0f, dB_Max=1.0f
        float fillAountValue = 1.0f +  (modified_dB / (dB_Max - dB_Min));
        //float fillAountValue = 1.0f + modified_dB;
        return fillAountValue;
    }

}
