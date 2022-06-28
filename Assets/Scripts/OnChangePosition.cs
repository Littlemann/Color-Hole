using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class OnChangePosition : MonoBehaviour
{
    [SerializeField] private float speedModifier;
    [SerializeField] private Collider[] groundColliders;

    private Touch touch;
    private Mesh GeneratedMesh;
    
    private void OnEnable() 
    {
        gameManager.Instance.OnPartEnd1 += PlayerSuccessPart1;   
        
    }
    private void OnDisable() 
    {
        gameManager.Instance.OnPartEnd1 -= PlayerSuccessPart1;

    }

    private void Update()
    {
        
        if(Input.touchCount>0)
        {
            if(!gameManager.Instance.CanMove) return;
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
               
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier,transform.position.y,transform.position.z + touch.deltaPosition.y * speedModifier);      
               
                var pos = transform.position;
                if(!gameManager.Instance.FirstPartEnded)
                {
                    pos.x =  Mathf.Clamp(transform.position.x, -2.3f, 2.3f);
                    pos.z = Mathf.Clamp(transform.position.z, -3.25f, 3.35f);
                }
                else
                {
                    pos.x =  Mathf.Clamp(transform.position.x, -2.3f, 2.3f);
                    pos.z = Mathf.Clamp(transform.position.z, 13.2f, 19.8f);
                }
                
                transform.position = pos;
                
            }

        }
    }
    
    

    private void PlayerSuccessPart1()
    {
        gameManager.Instance.CanMove = false;
        transform.DOLocalMove( new Vector3( 0f, 0f, 0f ), 1f ).OnComplete(MoveStraight);      
    }
   
    private void MoveStraight()
    {
       transform.DOLocalMove( new Vector3( 0f, 0f, 13.35f ), 5f).OnComplete(()=> gameManager.Instance.CanMove = true);
    }
    
    
    private void OnTriggerEnter(Collider other) 
    {
        for (int i = 0; i < groundColliders.Length; i++)
        {
            Physics.IgnoreCollision(other, groundColliders[i], true);
        }
    }
  
}
