using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Obstacles : MonoBehaviour
{
    [SerializeField] private Rigidbody[] rigidbodies;


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
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.useGravity= false;
        }
        
    }

   




}
