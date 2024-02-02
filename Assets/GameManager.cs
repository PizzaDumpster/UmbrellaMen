using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    GameTimer myGameTimer;

    [SerializeField] Canvas myPopUpCanvas;

    [SerializeField] public bool isPopUp;
    [SerializeField] bool isPlaying;
    [SerializeField] TMP_Text myScore;
    [SerializeField] TMP_Text myGameTime;
    [SerializeField] GameObject myButton;
    [SerializeField] EventSystem myEventSystem;
    [SerializeField] bool canSubmit; 

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        myGameTimer = FindFirstObjectByType<GameTimer>();
        isPopUp = false;
        canSubmit = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        if (!isPopUp)
        {
            Time.timeScale = 1; 
            isPlaying = true;
            myPopUpCanvas.enabled = false;
            myEventSystem.SetSelectedGameObject(null);
        }
        else
        {
            isPlaying = false;
            myPopUpCanvas.enabled = true;
            myEventSystem.SetSelectedGameObject(null);
            myEventSystem.SetSelectedGameObject(myButton);
            Time.timeScale = 0; 
            myScore.text = "Score: " + ScoreTracker.instance.score.ToString();
            myGameTime.text = "Timer: " + myGameTimer.timeCounter.ToString() + "s";          
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0); 
    }
 
}
