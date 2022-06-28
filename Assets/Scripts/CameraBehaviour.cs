using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CameraBehaviour : MonoBehaviour
{
    
    [SerializeField] private Transform nextTarget;


    

    private void OnEnable() 
    {
        gameManager.Instance.OnPartEnd1 += PlayerSuccessPart1;
       
        
    }
    private void OnDisable() 
    {
        gameManager.Instance.OnPartEnd1 -= PlayerSuccessPart1;
       
        
    }
   
    private void PlayerSuccessPart1()
    {
        Invoke("Move",1f);
        
    }

    private void Move()
    {
        transform.DOLocalMove( nextTarget.position, 5f );
       
    }
    

  

}
