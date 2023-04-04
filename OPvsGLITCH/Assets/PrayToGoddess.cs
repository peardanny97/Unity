using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrayToGoddess : MonoBehaviour
{
    public GameObject goddessText;
    public GameObject player;
    Collider2D goddessCollider;
    public bool prayable = false;
    public bool debug_unlock = false;
    public float _gold = 50f;

    
    [SerializeField] private TextMeshProUGUI goldText;
    public GameObject glitchMessage0;
    public GameObject prayMessage;
    
    // Start is called before the first frame update
    public float Gold{
        set{
            if((value < _gold || value > _gold)&&(_gold>=0)){
                goldText.text = "You Have " +_gold +" gold\nWill you Pray for 50 health(-100Gold)?";
            }
            _gold = value;

            
        }
        get {
            return _gold;
        }
    }
    
    
    void Start()
    { 
        goldText.text = "You Have " +_gold +" gold\nWill you Pray for 50 health(-100Gold)?";
        goddessCollider = GetComponent<Collider2D>();
    }


    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            prayable = true;
            player = col.gameObject;
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        if(col.gameObject.tag == "Player" && prayable){
            //player.BroadcastMessage("PrayAvailable", true);
            prayMessageOn();
            player.BroadcastMessage("PlayerAvailable", false);
        }
        else{
            player.BroadcastMessage("PlayerAvailable", true);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Ghost" || col.gameObject.tag == "Jammed"){
            //player.BroadcastMessage("PrayAvailable", false);
            prayMessageOff();
            player.BroadcastMessage("PlayerAvailable", true);
        }
    }
    
    public void prayMessageOn(){
        prayMessage.SetActive(true);
    }
    public void prayMessageOff(){
        prayMessage.SetActive(false);
    }
    public void glitchMessage0On(){
        glitchMessage0.SetActive(true);
        prayMessage.SetActive(false);
        
    }

    public void glitchMessage0Off(){
        glitchMessage0.SetActive(false);
        prayable = true;
    }
    public void prayYes(){
        Gold -= 100f;
        if(Gold < 0 && !debug_unlock) {
            debug_unlock = true;
            prayable = false;
            glitchMessage0On();
            goldText.text = "You Have 궭뚫셀렙 gold\nWill you Pray for 50 health(-100Gold)?";
            Gold = 99949f;
        }
        else if(Gold<0){
            Gold = 99949f;
        }
        player.BroadcastMessage("GetPreyed", true);
    }
    public void prayNo(){
        prayMessage.SetActive(false);
        prayable = false;
    }
    
    
}
