using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    Animator animator;

    public float damage = 1;
    public float knockbackForce = 500f;
    public float moveSpeed = 2000f;
    public float maxSpeed = 250f;

    public DetectionZone detectionZone;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    DamageableCharacter damageableCharacter;

    private void Start() {
        animator = GetComponent<Animator>();   
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        damageableCharacter = GetComponent<DamageableCharacter>();
        animator.SetBool("isAlive", true);
    }
    
    void FixedUpdate(){
        if(damageableCharacter.Targetable && detectionZone.detectedObjs.Count>0){
            // Move twoards detected object
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
            if(direction.x > 0 ){
                spriteRenderer.flipX = false;
            }
            else if(direction.x < 0){
                spriteRenderer.flipX = true;
            }
        }
        else{
            animator.SetBool("isMoving", false);
        }

        
    }


    void OnCollisionEnter2D(Collision2D col) {
        Collider2D collider = col.collider;
        IDamageable damageableObject = collider.GetComponent<IDamageable>();
        if(damageableObject != null){
            // Caclulate Direction btn character and slime
            Vector2 direction = (Vector2) (collider.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;
            //print("damage is "+swordDamage);
            damageableObject.OnHit(damage, knockback);
        }
    }

}
