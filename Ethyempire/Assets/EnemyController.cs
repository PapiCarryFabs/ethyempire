using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxspeed = 55f;
    public float speed = 55f;
    
    public int curHealth;
    public int maxHealth = 3;
    private Rigidbody2D rg2d;
    private GameMaster gm;
    
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        curHealth = maxHealth;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rg2d.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rg2d.velocity.x, -maxspeed,maxspeed);
        rg2d.velocity = new Vector2(limitedSpeed, rg2d.velocity.y);
        if (rg2d.velocity.x > -0.01f && rg2d.velocity.x < 0.01f){
            speed = -speed;
            rg2d.velocity = new Vector2(speed, rg2d.velocity.y);
        }
        if(speed > 0){
            transform.localScale = new Vector3 (1f, 1f, 1f);
        }
        else if(speed < 0){
            transform.localScale = new Vector3 (-1f, 1f, 1f);
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            Debug.Log("Player detected!");
            col.SendMessage("EnemyKnockback", transform.position.x);
        }
    }
    public void DamageEnemy(int dmg){
        curHealth -= dmg;
        Debug.Log("Au");
        if(curHealth<=0){
            Destroy(gameObject);
        }
    }
}
