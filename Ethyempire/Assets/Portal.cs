using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public int LevelToLoad;

    private GameMaster gm;

    void Start(){
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            gm.InputText.text = ("[E] Entrar en el portal");
        }
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.CompareTag("Player")){
            if(Input.GetKeyDown("e")){
                Application.LoadLevel(LevelToLoad);
            }
        }
    }
    void OnTriggerExit2D(Collider2D col){
        gm.InputText.text = (" ");
    }
}
