using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public float swordDamage = 1f;
    public float knockbackForce = 500f;

    public Collider2D swordCollider;
    public Vector3 faceRight = new Vector3(0.773f,-0.239f,0);
    public Vector3 faceLeft = new Vector3(-0.773f,-0.239f,0);

    bool normalMode = true;

    void Start()
    {
        swordCollider.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        
        IDamageable damageableObject = collider.GetComponent<IDamageable>();
        if(damageableObject != null && normalMode){
            // Caclulate Direction btn character and slime
            //Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
            Vector3 parentPosition = transform.parent.position;

            Vector2 direction = (Vector2) (collider.gameObject.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * knockbackForce;
            //print("damage is "+swordDamage);
            damageableObject.OnHit(swordDamage, knockback);
        }
        else{
            //Debug.LogWarning("Collider does not implement IDamageable");
        }

        
    }

    void IsFacingRight(bool IsFacingRight){
        if(IsFacingRight){
            gameObject.transform.localPosition = faceRight;
        }
        else {
            gameObject.transform.localPosition = faceLeft;
        }
    }

    void IsNormalMode(bool IsNormalMode){
        if(IsNormalMode){
            normalMode = true;
        }
        else normalMode = false;
    }

    
}
