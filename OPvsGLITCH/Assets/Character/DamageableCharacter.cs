using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DamageableCharacter : MonoBehaviour, IDamageable
{

    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;
    
    [SerializeField] private TextMeshProUGUI HPText;

    public GameObject healthText;
    public GameObject GameOverScreen;

    public bool canTurnInvincible = false;
    public float invincibilityTime = 0.2f;
    public float invincibleTimeElapsed = 0f;

    public bool _invincible = false;
    public float _health = 3;
    public bool _tragetable = true;
    public bool disableSimulation = false;  // true to make simulation stopped when character is dead
    

    private void Start() {
        animator = GetComponent<Animator>();   
        rb = GetComponent<Rigidbody2D>(); 
        physicsCollider = GetComponent<Collider2D>();
        animator.SetBool("isAlive", true);
        if(HPText != null){
            HPText.text = "HP "+ Health;
        }
    }

    public float Health{
        set{
            if(value < _health){
                animator.SetTrigger("hit");
                RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
                textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                textTransform.SetParent(canvas.transform);
                
            }
            _health = value;

            if(HPText != null){
                HPText.text = "HP "+_health;
            }

            if(_health <= 0){
                animator.SetBool("isAlive", false);
                Targetable = false;
                if(GameOverScreen != null){
                    GameOverScreen.SetActive(true);
                }
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

            if(invincibleTimeElapsed > invincibilityTime){
                Invincible = false;
            }
        }
    }

    public void GetPreyed(bool GetPreyed){
        if(GetPreyed){
            Health += 50f;
            print(Health);
        }
    }

    public void GameOverScreenOff(){
        GameOverScreen.SetActive(false);
        SceneManager.LoadScene("GameScreen");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
