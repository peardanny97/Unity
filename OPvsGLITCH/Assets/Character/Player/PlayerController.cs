using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool IsMoving{
        set{
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }

    //public float moveSpeed = 7f;
    public float moveSpeed = 5000f;
    public float maxSpeed = 250f;
    public float idleFriction = 0.9f;

    public AudioSource swordSound;

    public bool normalMode = true;
    public bool ghostMode = false;
    public bool jammedMode = false;

    private bool jammedModeAvailable = false;
    private bool ghostModeAvailable = false;

    public float rotateSpeed = 150f;

    public GameObject swordHitbox;
    public ContactFilter2D movementFilter;
    //public SwordAttack swordAttack;

    Collider2D swordCollider;
    Vector2 moveInput = Vector2.zero;
    
    Rigidbody2D rb;
    Transform tf;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Animator animator;
    SpriteRenderer spriteRenderer;
    Color startingColor;
    //public Collider2D collider;

    bool isMoving = false;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        swordCollider = swordHitbox.GetComponent<Collider2D>();
        startingColor = spriteRenderer.color;

    }

    private void FixedUpdate() {
        if(moveInput != Vector2.zero && canMove){
            // Move animation and add velocity

            // Accelerate the player while run direction is pressed
            // But don't allow to run faster than the max speed in any direction
            rb.AddForce(moveInput * moveSpeed * Time.deltaTime);
            if (rb.velocity.magnitude > maxSpeed){
                float limitedSpeed = Mathf.Lerp(rb.velocity.magnitude, maxSpeed, idleFriction);
                rb.velocity = rb.velocity.normalized * limitedSpeed;
            }
            //rb.velocity = Vector2.ClampMagnitude(rb.velocity + (moveInput * moveSpeed * Time.deltaTime), maxSpeed);
            
            if(moveInput.x > 0 ){
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", true);
            }
            else if(moveInput.x < 0){
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", false);
            }
            IsMoving = true;
        }
        else {
            // no movement so interpolate velocity towards 0
            //rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            IsMoving = false;
        }
        
        if(ghostMode){
            spriteRenderer.color = new Color(startingColor.r, startingColor.g, startingColor.b, 0.5f);
            tf.rotation = Quaternion.identity;
            gameObject.tag = "Ghost";
            //collider.enabled = true;
            
            gameObject.BroadcastMessage("IsNormalMode", false);
        }
        else if(jammedMode){

            spriteRenderer.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1);
            tf.Rotate(0,0, Time.deltaTime*rotateSpeed);
            gameObject.tag = "Jammed";
            //collider.enabled = false;
            
            gameObject.BroadcastMessage("IsNormalMode", false);
        }
        else {
            spriteRenderer.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1);
            tf.rotation = Quaternion.identity;
            gameObject.tag = "Player";
            //collider.enabled = true;
            
            gameObject.BroadcastMessage("IsNormalMode", true);
        }
        
    }
    
    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void OnFire() {
        swordSound.Play();
        animator.SetTrigger("swordAttack");
    }

    void OnZero() {
        SceneManager.LoadScene("GameScreen");
    }

    void OnOne() {
        if(!jammedMode && ghostModeAvailable) {
            ghostMode = !ghostMode;
        }
    }

    void OnTwo() { // Jammed Mode activate/deactivate
        if(!ghostMode && jammedModeAvailable) {
            jammedMode = !jammedMode;
        }
    }


    public void LockMovement(){
        canMove = false;
    }

    public void UnlockMovement(){
        canMove = true;
    }

    public void EnableSword() {
        swordCollider.enabled = true;
        //swordCollider.isTrigger = true;
    }

    public void DisableSword() {
        swordCollider.enabled = false;
        //swordCollider.isTrigger = false;
    }
    void JammedModeAvailable(bool JammedModeAvailable){
        if(JammedModeAvailable){
            jammedModeAvailable = true;
        }
        else {
            jammedModeAvailable = false;
        }
    }

     void GhostModeAvailable(bool GhostModeAvailable){
        if(GhostModeAvailable){
            ghostModeAvailable = true;
        }
        else {
            ghostModeAvailable = false;
        }
    }

    void PlayerAvailable(bool PlayerAvailable){
        if(PlayerAvailable){
            
            canMove = true;
        }
        else{
            canMove = false;
        }
    }

}
