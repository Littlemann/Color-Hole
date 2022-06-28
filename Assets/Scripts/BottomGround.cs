using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BottomGround : MonoBehaviour
{
      

     private void OnEnable() 
    {
        gameManager.Instance.OnFail += PlayerFail;
    }
    private void OnDisable() 
    {
        gameManager.Instance.OnFail -= PlayerFail;
    }

    void OnTriggerEnter (Collider other)
    {

        if(other.tag == "Object")
        {
           Level.Instance.objectsInScene--;
           Handheld.Vibrate();
           UI.Instance.UpdateLevelProgress();

           
        }
        if(other.tag == "RedOnes")
        { 
          Handheld.Vibrate();       
          gameManager.Instance.Fail();
           
        }
    }

    private void PlayerFail()
    {   
        Invoke("ReloadSameScene",1f);
    }
    private void ReloadSameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
