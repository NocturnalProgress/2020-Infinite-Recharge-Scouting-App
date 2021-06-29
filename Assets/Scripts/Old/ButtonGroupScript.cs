using UnityEngine;

/*
    This script was used for a previous version of the scouting app.
    It disabled and enabled specific menus based on the button the user selects.
*/

public class ButtonGroupScript : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas initialDataCanvas;
    public Canvas autonomousCanvas;
    public Canvas teleOpCanvas;
    public Canvas endGameCanvas;
    public Canvas submitDataCanvas;
    public Canvas selectionCanvas;

    private bool firstButtonPressed = false;
    private bool reset = false;
    private float timeOfFirstButton = 0f;

    private void Start()
    {
        mainCanvas.enabled = true;
        initialDataCanvas.enabled = false;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        submitDataCanvas.enabled = false;
        selectionCanvas.enabled = false;
    }

    public void MainButton()
    {
        mainCanvas.enabled = true;
        initialDataCanvas.enabled = false;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        submitDataCanvas.enabled = false;
        selectionCanvas.enabled = false;
    }

    public void InitalDataButton()
    {
        mainCanvas.enabled = false;
        initialDataCanvas.enabled = true;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        submitDataCanvas.enabled = false;
        selectionCanvas.enabled = false;
    }

    public void AutonomousButton()
    {
        mainCanvas.enabled = false;
        initialDataCanvas.enabled = false;
        autonomousCanvas.enabled = true;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        submitDataCanvas.enabled = false;
        selectionCanvas.enabled = false;
    }

    public void TeleOpButton()
    {
        mainCanvas.enabled = false;
        initialDataCanvas.enabled = false;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = true;
        endGameCanvas.enabled = false;
        submitDataCanvas.enabled = false;
        selectionCanvas.enabled = false;
    }

    public void EndGameButton()
    {
        mainCanvas.enabled = false;
        initialDataCanvas.enabled = false;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = true;
        submitDataCanvas.enabled = false;
        selectionCanvas.enabled = false;
    }

    public void SubmitDataButton()
    {
        mainCanvas.enabled = false;
        initialDataCanvas.enabled = false;
        autonomousCanvas.enabled = false;
        teleOpCanvas.enabled = false;
        endGameCanvas.enabled = false;
        submitDataCanvas.enabled = true;
        selectionCanvas.enabled = false;
    }

    public void EnableSelectionButton()
    {
        if (firstButtonPressed == true)
        {
            if (Time.time - timeOfFirstButton > 0.1f)
            {
                selectionCanvas.enabled = false;
            }
            reset = true;
        }

        if (firstButtonPressed == false)
        {
            firstButtonPressed = true;
            timeOfFirstButton = Time.time;
            selectionCanvas.enabled = true;
        }

        if (reset)
        {
            firstButtonPressed = false;
            reset = false;
        }
    }
}