using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSlave : MonoBehaviour
{
    GameTimer myGameTimer; 

    [SerializeField] TMP_Text myScore;
    [SerializeField] TMP_Text gameTimer;
    [SerializeField] TMP_Text myHealth;
    [SerializeField] TMP_Text myBombs;
    PlayerHealth myPlayerHealth; 
    MovementController myMovementController;
    //[SerializeField] TMP_Text timeCounter;

    // Start is called before the first frame update
    void Start()
    {
        myGameTimer = FindFirstObjectByType<GameTimer>();
        myPlayerHealth = FindFirstObjectByType<PlayerHealth>();
        myMovementController = FindObjectOfType<MovementController>();
        myScore.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        string scoreFromMaster = "Score: " + ScoreTracker.instance.score.ToString().PadLeft(6);
        myScore.text = scoreFromMaster;
        gameTimer.text = "Timer: " + myGameTimer.gameTimer.ToString();
        myHealth.text = "Health: " + myPlayerHealth.health.ToString(); 
        myBombs.text = "Bombs: " + myMovementController.bombCounter.ToString();
    }
}
