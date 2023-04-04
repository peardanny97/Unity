using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    GameObject player;
    public GameObject gameClearScreen;
    Collider2D goalCollider;

    void Start()
    {
        goalCollider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Jammed" || col.gameObject.tag == "Ghost"){
            player = col.gameObject;
            player.BroadcastMessage("PlayerAvailable", false);
            gameClearScreen.SetActive(true);
        }
    }

    public void GameClearScreenOff(){
        SceneManager.LoadScene("GameScreen");
    }
}
