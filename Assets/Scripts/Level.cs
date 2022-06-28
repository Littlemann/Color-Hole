using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
   
    public static Level Instance;
    [SerializeField] private GameObject nextLevel;
    public int objectsInScene;
    public int totalObjects;
    public Transform objectsParentP1,objectsParentP2;
    private bool nextLevelobj = false;
    
 
    
    void Awake() 
    {
        
        if (Instance == null) 
        {
        
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else if (Instance != this) 
        {
            Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        nextLevel.SetActive(false);
    }

      private void OnEnable() 
    {
        gameManager.Instance.OnPartEnd1 += PlayerSuccessPart1;
    }
     private void OnDisable() 
    {
        gameManager.Instance.OnPartEnd1 -= PlayerSuccessPart1;
    }
  
    void Start()
    {
        CountObjects();
    }

    private void PlayerSuccessPart1()
    {  
       nextLevel.SetActive(true);
       nextLevelobj = true;
       CountObjects();
    }
 
    public void CountObjects()
    { 
        if(!nextLevelobj)
        {
           totalObjects = objectsParentP1.childCount;
           objectsInScene = totalObjects;
        }
        else if(nextLevelobj)
        {
            totalObjects = objectsParentP2.childCount;
            objectsInScene = totalObjects;
        }
    }

    
}
