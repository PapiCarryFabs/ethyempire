using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private PlayerController player;
    
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            player.DamageSpikes(5);
        }
    }
}
