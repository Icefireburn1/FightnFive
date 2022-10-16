using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Collections;
using UnityEngine.UI;
using System.Linq;
using TMPro;

/// <summary>
/// This object controls everything that happens in the Battle scene.
/// </summary>
public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameBoardMenuManager;
    [SerializeField]
    private Floors currentFloors;
    [SerializeField]
    private GameObject marker;
    public Transform spot1;
    public Transform spot2;
    public Transform spot3;
    public Transform spot4;

    public Button btnAbility1;
    public Button btnAbility2;
    public Button btnAbility3;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    public GameObject sam;
    public GameObject charles;
    public GameObject rogue;
    public GameObject jerry;

    [SerializeField]
    public TurnOrder turnOrder;

    private bool beginBattle = false;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            Init();
            SpawnEnemies();
            SpawnPlayers();
            CreateTurnOrder();
            PopulateAbilityButtons();
            beginBattle = true;
        }
        catch (UnauthorizedAccessException e)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Going to previous screen.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (beginBattle)
        {

        }
    }

    void Init()
    {
        currentFloors = GameManager.CurrentFloor;
    }

    void SpawnPlayers()
    {
        try
        {
            // Only need to check 1 to determine state of all
            if (GameManager.GetPlayerCharacter(GameManager.Heroes.Sam) == null)
            {
                GameManager.SetPlayerCharacter(GameManager.Heroes.Sam, sam);
                GameManager.SetPlayerCharacter(GameManager.Heroes.Jerry, jerry);
                GameManager.SetPlayerCharacter(GameManager.Heroes.Charles, charles);
                GameManager.SetPlayerCharacter(GameManager.Heroes.Rogue, rogue);
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e);
        }
    }

    void SpawnEnemies()
    {
        // We started in the battle scene
        if (currentFloors == null)
        {
            throw new UnauthorizedAccessException();
        }

        try
        {
            enemy1 = Instantiate(currentFloors.enemy1, spot1.transform.position, spot1.transform.rotation);
            enemy2 = Instantiate(currentFloors.enemy2, spot2.transform.position, spot2.transform.rotation);
            enemy3 = Instantiate(currentFloors.enemy3, spot3.transform.position, spot3.transform.rotation);
            enemy4 = Instantiate(currentFloors.enemy4, spot4.transform.position, spot4.transform.rotation);

            enemy1.GetComponent<Enemy>().SetAttributes(currentFloors.attack1, currentFloors.health1, currentFloors.speed1);
            enemy2.GetComponent<Enemy>().SetAttributes(currentFloors.attack2, currentFloors.health2, currentFloors.speed2);
            enemy3.GetComponent<Enemy>().SetAttributes(currentFloors.attack3, currentFloors.health3, currentFloors.speed3);
            enemy4.GetComponent<Enemy>().SetAttributes(currentFloors.attack4, currentFloors.health4, currentFloors.speed4);
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e);
        }
    }

    void PopulateAbilityButtons()
    {
        try
        {
            Character firstMovingPlayerCharacter = turnOrder.GetFirstMovingPlayer().GetComponent<Character>();
            btnAbility1.GetComponentInChildren<TextMeshProUGUI>().text = firstMovingPlayerCharacter.Ability1.title;
            btnAbility2.GetComponentInChildren<TextMeshProUGUI>().text = firstMovingPlayerCharacter.Ability2.title;
            btnAbility3.GetComponentInChildren<TextMeshProUGUI>().text = firstMovingPlayerCharacter.Ability3.title;
            
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e);
        }
    }

    void CreateTurnOrder()
    {
        try
        {
            GameObject[] playerCharacters = GameObject.FindGameObjectsWithTag("Player");
            turnOrder = new TurnOrder();
            turnOrder.Add(playerCharacters[0]);
            turnOrder.Add(playerCharacters[1]);
            turnOrder.Add(playerCharacters[2]);
            turnOrder.Add(playerCharacters[3]);

            turnOrder.Add(enemy1);
            turnOrder.Add(enemy2);
            turnOrder.Add(enemy3);
            turnOrder.Add(enemy4);
            turnOrder.SortBySpeed();
        }
        catch (Exception e)
        {
            Debug.LogError("Could not find GameObjects with tag 'Player'");
        }
    }
}

