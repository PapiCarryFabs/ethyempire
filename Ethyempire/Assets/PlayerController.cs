using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxspeed = 10f;
    public float speed = 2f;
    public float jumpPower = 0.5f;
    private bool jump;
    public bool grounded;
    public int curHealth;
    public int maxHealth = 2;
    private Rigidbody2D rg2d; 
    private bool movement = true;
    private SpriteRenderer spr;
    private Animator anim;
    private GameMaster gm;
    
    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        curHealth = maxHealth;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
        

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rg2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        if(Input.GetKeyDown(KeyCode.UpArrow) && grounded){
            jump = true;
        }

        if(curHealth > maxHealth){
            curHealth = maxHealth;
        }
        if(curHealth <= 0){
            Die();
        }
    }
    void FixedUpdate(){
        Vector3 fixedVelocity = rg2d.velocity;
        fixedVelocity.x *= 0.75f;

    if(grounded){
        rg2d.velocity = fixedVelocity;
    }

        float h = Input.GetAxis("Horizontal");
        if(!movement) h = 0;
        rg2d.AddForce(Vector2.right * speed * h);
        float limitedSpeed = Mathf.Clamp(rg2d.velocity.x, -maxspeed,maxspeed);
        rg2d.velocity = new Vector2(limitedSpeed, rg2d.velocity.y);
        
        if(h>0.1f){
            transform.localScale = new Vector3 (1f, 1f, 1f);
        }
        if(h<-0.1f){
            transform.localScale = new Vector3 (-1f, 1f, 1f);
        }
        if(jump){
            rg2d.velocity = new Vector2(rg2d.velocity.x,0);
            rg2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
    }
    void OnBecameInvisible(){
            transform.position = new Vector3(-1,0,0);
        }
    public void EnemyKnockback(float enemyPosX){
        jump=true;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rg2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);
        movement = false;
        Invoke("EnableMovement",0.7f);
        Color color = new Color();
        spr.color = Color.red;
        curHealth -= 1;
    }
    void EnableMovement(){
        movement = true;
        spr.color = Color.white;
    }
    void Die(){
        Application.LoadLevel(Application.loadedLevel);
    }
    public void DamageSpikes(int dmg){
        curHealth -= dmg;        
    }
}
