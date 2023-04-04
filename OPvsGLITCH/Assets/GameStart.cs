using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void gameStartOff(){
        SceneManager.LoadScene("GameScreen");
        print("hi");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }   
    
}
