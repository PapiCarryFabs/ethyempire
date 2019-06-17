using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{

    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }
    void OnCollisionStay2D(Collision2D col){
        player.grounded = true;
    }
    void OnCollisionExit2D(Collision2D col){
        player.grounded = false;
    }
}
