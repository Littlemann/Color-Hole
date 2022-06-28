using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;

    public event System.Action OnPartEnd1;
    public event System.Action OnPartEnd2;
    public event System.Action OnFail;

    [SerializeField] private GameObject playButton;

    private bool firstPartEnded;
    public bool CanMove;

    public bool FirstPartEnded => firstPartEnded;
    
    
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
        
        StartPack();
    }

    private void StartPack()
    {
        firstPartEnded = false;
        CanMove = false;
        playButton.SetActive(true);
    }
    public void OnTapClick()
    {
        CanMove = true;
        playButton.SetActive(false);
    }

    public void PartEnd1()
    {
        OnPartEnd1?.Invoke();
        firstPartEnded = true;
    }
    
    public void Fail()
    {
        OnFail?.Invoke();
        firstPartEnded = false;
    }

    public void PartEnd2()
    {
        OnPartEnd2?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        firstPartEnded = false; 
    }
   
    
    


}
