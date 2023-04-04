using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GhostModeAvailable : MonoBehaviour, IDamageable
{
    Rigidbody2D rb;
    Collider2D physicsCollider;
    Tilemap tilemap;
    
    public GameObject playerObj;
    public GameObject glitchMessage1;

    public bool canTurnInvincible = true;
    public float invincibilityTime = 0.2f;
    public float invincibleTimeElapsed = 0f;

    public bool _invincible = false;
    public float _health = 3;
    public bool _tragetable = true;
    public bool disableSimulation = false;  // true to make simulation stopped when character is dead
    
    private void Start() {
        rb = GetComponent<Rigidbody2D>(); 
        tilemap = GetComponent<Tilemap>();
        tilemap.color = new Color(1, 1, 1, 0);
        physicsCollider = GetComponent<Collider2D>();
    }

    public float Health{
        set{
            
            _health = value;

            if(_health <= 0){
                glitchMessage1On();
                Targetable = false;
            }
        }
        get {
            return _health;
        }
    }

    public bool Targetable {
        set{
            _tragetable = value;
            physicsCollider.enabled = value;
            if(disableSimulation){
                rb.simulated = false;
            }
        }
        get{
            return _tragetable;
        }
    }

    public bool Invincible {
        set{
            _invincible = value;
            if(_invincible){
                invincibleTimeElapsed = 0f;
            }
        }
        get{
            return _invincible;
        }
    }


    public void OnHit(float damage, Vector2 knockback) {
        if(!Invincible){
            Health -= damage;
            rb.AddForce(knockback, ForceMode2D.Impulse);
            if(canTurnInvincible){
                // Activate invincibility and timer
                Invincible = true;
            }
        }
     
    }

    public void OnHit(float damage) {
        if(!Invincible){
            Health -= damage;
            if(canTurnInvincible){
                // Activate invincibility and timer
                Invincible = true;
            }
        }
    }

    public void OnObjectDestroyed() {
        Destroy(gameObject);
    }

    public void FixedUpdate(){
        if(Invincible) {
            invincibleTimeElapsed += Time.deltaTime;
            tilemap.color = new Color(1, 1, 1, 1);
            if(invincibleTimeElapsed > invincibilityTime){
                Invincible = false;
                tilemap.color = new Color(1, 1, 1, 0);
            }
        }
    }

    public void glitchMessage1On(){
        glitchMessage1.SetActive(true);
        playerObj.BroadcastMessage("PlayerAvailable", false);
        playerObj.BroadcastMessage("GhostModeAvailable", true);
    }

    public void glitchMessage1Off(){
        glitchMessage1.SetActive(false);
        playerObj.BroadcastMessage("PlayerAvailable", true);
    }

}
