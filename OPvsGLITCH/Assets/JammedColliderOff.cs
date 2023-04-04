using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammedColliderOff : MonoBehaviour
{
    Collider2D boundaryCollider;
    public float jammedTime = 0.5f;
    public float jammedTimeElapsed = 0f;
    public bool _jammed = false;
    
    private void Start(){
        boundaryCollider = GetComponent<Collider2D>();
    }

    public bool Jammed {
        set{
            _jammed = value;
            if(_jammed){
                jammedTimeElapsed = 0f;
                boundaryCollider.enabled = false;
            }
            else{
                boundaryCollider.enabled = true;
            }
        }
        get{
            return _jammed;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Jammed"){
            Jammed = true;
        }
        else{
            Jammed = false;
        }
    }

    public void FixedUpdate(){
        if(Jammed) {
            jammedTimeElapsed += Time.deltaTime;

            if(jammedTimeElapsed > jammedTime){
                Jammed = false;
            }
        }
    }
}
