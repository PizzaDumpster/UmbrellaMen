using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events; 

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text inputScore;
    [SerializeField] TMP_InputField inputName;
    public UnityEvent<string, string> submitScoreEvent; 

    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, inputScore.text);
    }
}
