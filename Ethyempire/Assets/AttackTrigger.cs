using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private EnemyController enemy;
   public int dmg = 1;
   void Start(){
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
    }
    void OnTriggerEnter2D(Collider2D col){
        enemy.DamageEnemy(1);
        Debug.Log("Paso!");
    }
    
}
