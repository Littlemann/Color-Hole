using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    


    private Animator myAnimator;
    
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

      private void OnEnable() 
    {
        gameManager.Instance.OnPartEnd1 += OpenDoor;
        
       
    }
     private void OnDisable() 
    {
        gameManager.Instance.OnPartEnd1 -= OpenDoor;
        
       
    }
   
   private void OpenDoor()
   {
        myAnimator.SetTrigger("OpenDoor");
   }
}
