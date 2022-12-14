using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This object controls everything that happens on the GameBoard scene.
/// </summary>
public class GameBoardManager : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;

    public Floors currentFloor;

    public Floors[] floors;

    public int currentFloorsNum;
    public int currentChapter;
    public int currentChallengeFloor;

    private void Update()
    {
        currentChapter = GameManager.Chapter;
        currentFloorsNum = GameManager.CurrentFloorNumber;
        currentChallengeFloor = GameManager.CurrentlyChallengingFloorNumber;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadButtons();
    }

    /// <summary>
    /// Load the correct text and color for each Floor button
    /// </summary>
    void LoadButtons()
    {
        if (button1 != null || button2 != null || button3 != null || button4 != null || button5 != null)
        {
            button1.GetComponentInChildren<TextMeshProUGUI>().text = "Floor " + (1 + ((GameManager.Chapter - 1) * 5));
            button2.GetComponentInChildren<TextMeshProUGUI>().text = "Floor " + (2 + ((GameManager.Chapter - 1) * 5));
            button3.GetComponentInChildren<TextMeshProUGUI>().text = "Floor " + (3 + ((GameManager.Chapter - 1) * 5));
            button4.GetComponentInChildren<TextMeshProUGUI>().text = "Floor " + (4 + ((GameManager.Chapter - 1) * 5));
            button5.GetComponentInChildren<TextMeshProUGUI>().text = "Floor " + (5 + ((GameManager.Chapter - 1) * 5));
        }
        else
        {
            Debug.LogError("Buttons are not set!");
        }

        if (button1 != null || button2 != null || button3 != null || button4 != null || button5 != null)
        {
            SetButtonAttributes(button1, 1);
            SetButtonAttributes(button2, 2);
            SetButtonAttributes(button3, 3);
            SetButtonAttributes(button4, 4);
            SetButtonAttributes(button5, 5);
        }
        else
        {
            Debug.LogError("Buttons are not set!");
        }
    }

    /// <summary>
    /// Set color and intractability based on floor number and the player's cleared floors
    /// </summary>
    /// <param name="go"></param>
    /// <param name="buttonNumber"></param>
    void SetButtonAttributes(Button go, int buttonNumber)
    {
        int num = (buttonNumber + ((GameManager.Chapter - 1) * 5));
        if (GameManager.CurrentFloorNumber > num)
        {
            go.GetComponent<Image>().color = Color.green;
            go.interactable = true;
        }
        else if (GameManager.CurrentFloorNumber == num)
        {
            go.GetComponent<Image>().color = Color.red;
            go.interactable = true;
        }
        else
        {
            go.GetComponent<Image>().color = Color.white;
            go.interactable = false;
        }
    }

    public Floors GetCurrentFloor()
    {
        return currentFloor;
    }

    /// <summary>
    /// When clicked, change scene to the battle scene at that floor
    /// </summary>
    /// <param name="buttonNumber"></param>
    public void GotoBattleFloor(int buttonNumber)
    {
        currentFloor = floors[(buttonNumber + ((GameManager.Chapter - 1) * 5)) - 1];
        GameManager.CurrentFloor = currentFloor;
        GameManager.CurrentlyChallengingFloorNumber = (buttonNumber + ((GameManager.Chapter - 1) * 5));
        SceneManager.LoadScene(2); // go to battle
    }

    /// <summary>
    /// Go to next chapter. This will change which floors the player will see
    /// </summary>
    public void GotoNextChapter()
    {
        if (GameManager.Chapter < 3)
        {
            GameManager.Chapter++;
            LoadButtons();
        }
    }

    /// <summary>
    /// Go to previous chapter. This will change which floors the player will see
    /// </summary>
    public void GotoPrevChapter()
    {
        if (GameManager.Chapter > 1)
        {
            GameManager.Chapter--;
            LoadButtons();
        }
    }
}
