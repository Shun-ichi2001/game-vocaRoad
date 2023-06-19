using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bandit : MonoBehaviour {

    [SerializeField] float      m_speed = 0.0001f;
    //[SerializeField] float      m_jumpForce = 7.5f;
    [Header("gravity")] public float gravity;


    private SpriteRenderer sr = null;
    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;

    public Transform attackPoint;
    public float attackRadius;
    public LayerMask PlayerLayer;
    float timer = 0.0f;
    private Animator anim = null;
    private bool rightTleftF = false;
    [Header("behavior")] public bool nonVisibleAct;
    [Header("attach")] public Enemycollision checkCollision;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        int xVector = -1;
        //m_body2d.velocity = new Vector2(xVector* m_speed, m_body2d.velocity.y);
        //m_speed = 4.0f;
        if (sr.isVisible || nonVisibleAct)
        {

            timer += Time.deltaTime;
            //Debug.Log("taima22"+timer);
            //Check if character just landed on the ground
            //int xVector = -1;
            if (checkCollision.isOn)
            {
                //xVector = 1;
                rightTleftF = !rightTleftF;
            }
            xVector = -1;
 
            if (rightTleftF)
            {
                xVector = 1;
                transform.localScale = new Vector3(-1.553609f, 1.864391f, 1.0f);
            }
            
                
            else
            {
                transform.localScale = new Vector3(1.553609f, 1.864391f, 1.0f);
                    //transform.localScale = new Vector3(1, 1, 1);
            }
            
            if (!m_grounded && m_groundSensor.State())
            {
                m_grounded = true;
                m_animator.SetBool("Grounded", m_grounded);
            }

            //Check if character just started falling
            if (m_grounded && !m_groundSensor.State())
            {
                m_grounded = false;
                m_animator.SetBool("Grounded", m_grounded);
            }
            
           
            //Set AirSpeed in animator
            m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);
            m_animator.SetInteger("AnimState", 2);
            //m_body2d.velocity = new Vector2(xVector * m_speed , m_body2d.velocity.y);
            this.transform.position += new Vector3(xVector * m_speed * Time.deltaTime, 0);

            
            if (timer > 3.0f)
            {
                timer = 0.0f;
                Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, PlayerLayer);
                
                //this.transform.position += new Vector3(xVector * m_speed * Time.deltaTime, 0);
                m_animator.SetTrigger("Attack");
                Invoke("Destroy", 0.1f);
                

            }
            


        }

    }
    void Destroy()
    {
        
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, PlayerLayer);
        foreach (Collider2D hitPlayer in hitPlayers)
        {
            hitPlayer.GetComponent<NewBehaviourScript>().OnDamage();
            

        }
   
    }



        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
