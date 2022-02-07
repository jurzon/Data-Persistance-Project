using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text bestScore;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        PeristanceManager.Instance.LoadPlayer();
        bestScore.text = "Best Score: " + PeristanceManager.Instance.playerName + ": " + PeristanceManager.Instance.points;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        string newPlayer = inputField.text;
        PeristanceManager.Instance.newPlayer = newPlayer;
        Debug.Log("StartNew! " + inputField.text);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        EditorApplication.ExitPlaymode();
    }
}
