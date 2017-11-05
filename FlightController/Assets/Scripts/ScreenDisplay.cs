using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenDisplay : MonoBehaviour {

    public Text mainDisplay;
    public Text promptDisplay;
    public string[] textToDisplay;
    public string[] promptToDisplay;
    private int currentIndex;
    private int maxIndex;
    private void Start()
    {
        currentIndex = 0;
        maxIndex = textToDisplay.Length - 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && currentIndex < maxIndex)
        {
            currentIndex++;
            mainDisplay.text = textToDisplay[currentIndex];
            promptDisplay.text = promptToDisplay[currentIndex];
        }

        if(Input.GetKeyDown(KeyCode.Joystick1Button0) && currentIndex == maxIndex)
        {
            SceneManager.LoadScene("main");
        }

        if(Input.GetKeyDown(KeyCode.Joystick1Button1) && currentIndex == maxIndex)
        {
            currentIndex = 4;
            mainDisplay.text = textToDisplay[currentIndex];
            promptDisplay.text = promptToDisplay[currentIndex];
        }
    }
}
