using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;
    public Image HeartUI;
    private PlayerController Player;

    void Start(){
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void FixedUpdate(){
        HeartUI.sprite = HeartSprites[Player.curHealth];
    }
}
