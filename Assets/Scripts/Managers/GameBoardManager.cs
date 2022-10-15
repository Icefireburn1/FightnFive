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

    // Start is called before the first frame update
    void Start()
    {
        button1.GetComponentInChildren<TextMeshProUGUI>().text = "Floor " + 1* GameManager.Chapter;
        button2.GetComponentInChildren<TextMeshProUGUI>().text = "Floor " + 2* GameManager.Chapter;
        button3.GetComponentInChildren<TextMeshProUGUI>().text = "Floor " + 3* GameManager.Chapter;
        button4.GetComponentInChildren<TextMeshProUGUI>().text = "Floor " + 4* GameManager.Chapter;
        button5.GetComponentInChildren<TextMeshProUGUI>().text = "Floor " + 5* GameManager.Chapter;

        // TODO: Figure out why this doesnt work
        if (ColorUtility.TryParseHtmlString("53FF00", out Color color))
        {
            button1.GetComponent<Image>().color = GameManager.CurrentFloorNumber > 1 * GameManager.Chapter ? color : button1.GetComponent<Image>().color;
        }
    }

    public Floors GetCurrentFloor()
    {
        return currentFloor;
    }

    public void GotoBattleFloor(int buttonNumber)
    {
        currentFloor = floors[buttonNumber - 1];
        GameManager.CurrentFloor = currentFloor;
        SceneManager.LoadScene(2); // go to battle
    }
}
