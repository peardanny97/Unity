using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{   
    public List<Collider2D> detectedObjs = new List<Collider2D>();
    public Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Jammed"){
            detectedObjs.Add(collider);
        }
    }
    void OnTriggerStay2D(Collider2D collider){
        if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Jammed"){
            if(detectedObjs.Count == 0){
                detectedObjs.Add(collider);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Jammed" || collider.gameObject.tag == "Ghost"){
            detectedObjs.Remove(collider);
        }
    }
}
