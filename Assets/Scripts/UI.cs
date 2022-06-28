using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class UI : MonoBehaviour
{

    public static UI Instance;

    [SerializeField] private int sceneOffset;
    [SerializeField] private TMP_Text nextLevelTxt,currentLevelTxt;
    [SerializeField] private Image firstLevelImage,secondLevelImage;


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
    }

    void Start()
    {
        firstLevelImage.fillAmount = 0f;
        secondLevelImage.fillAmount = 0f;
        SetLevelProgressText();    
    }

    void SetLevelProgressText()
    {
        int level = SceneManager.GetActiveScene().buildIndex +  sceneOffset;
        currentLevelTxt.text = level.ToString();
        nextLevelTxt.text = (level + 1).ToString();
    }

    
    public void UpdateLevelProgress()
    {
    
    float value = 1f - ((float) Level.Instance.objectsInScene / Level.Instance.totalObjects);      
      if(!gameManager.Instance.FirstPartEnded)
      {
        
        firstLevelImage.fillAmount = value;
        if(firstLevelImage.fillAmount == 1f)
        {
        gameManager.Instance.PartEnd1();
        }
      }
      else
      {
        secondLevelImage.fillAmount = value;
        if(secondLevelImage.fillAmount == 1)
        {
        gameManager.Instance.PartEnd2();
        }
      }
 

    }


}
