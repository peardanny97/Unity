using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammedModeAvailable : MonoBehaviour
{
    Collider2D boundaryCollider;
    
    public float jammedAvailTime = 5f;
    public float jammedAvailTimeElapsed = 0f;
    public bool _jammedAvail = false;
    public GameObject playerObj;
    public GameObject glitchMessage2;

    public bool JammedAvail {
        set{
            _jammedAvail = value;
        }
        get{
            return _jammedAvail;
        }
    }

    private void Start(){
        boundaryCollider = GetComponent<Collider2D>();
    }

    public void FixedUpdate(){
        if(JammedAvail) {
            jammedAvailTimeElapsed += Time.deltaTime;
        }
        else{
            jammedAvailTimeElapsed = 0;
        }
        if(jammedAvailTimeElapsed > jammedAvailTime){
            glitchMessage2.SetActive(true);
            playerObj.BroadcastMessage("JammedModeAvailable", true);
            playerObj.BroadcastMessage("PlayerAvailable", false);
            jammedAvailTime = 2000f;
        }
        
    }


    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Ghost"){
            JammedAvail = true;
            playerObj = col.gameObject;
        }
    }
    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Ghost"){
            JammedAvail = false;
            jammedAvailTimeElapsed = 0;
        }
    }

    public void glitchMessage2Off(){
        glitchMessage2.SetActive(false);
        playerObj.BroadcastMessage("PlayerAvailable", true);
    }
}