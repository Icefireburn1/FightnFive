using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using Random = System.Random;
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

    public Ability selectedAbility;
    public Ability.EligibleTarget eligibleTarget;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    public GameObject sam;
    public GameObject charles;
    public GameObject rogue;
    public GameObject jerry;

    public List<GameObject> selectedUnits;

    [SerializeField]
    public TurnOrder turnOrder;

    public bool beginBattle;
    public bool isPlayersTurn = false;

    public GameObject HpPrefab;
    public SoundManager audioSource;
    public AudioClip targetSelectSound;

    private void Awake()
    {
        audioSource = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            Init();
            SpawnEnemies();
            SpawnPlayers();
            CreateTurnOrder();
            CreateHealthBars();
            PopulateAbilityButtons();
            EndInit();
        }
        catch (UnauthorizedAccessException)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Going to previous screen.");
        }
    }

    void Init()
    {
        beginBattle = false;
        currentFloors = GameManager.CurrentFloor;
        selectedUnits = new List<GameObject>();
    }

    void EndInit()
    {
        beginBattle = true;
        selectedAbility = null;
        gameObject.GetComponent<DoubleClick>().doubleClicked += new EventHandler(HandleDoubleClick);
    }

    void HandleDoubleClick(object sender, EventArgs e)
    {
        // Don't do anything when its not our turn
        if (!isPlayersTurn) return;

        if (selectedAbility == null)
        {
            Debug.Log("No ability selected");
            return;
        }
        if (selectedUnits.Count <= 0)
        {
            Debug.Log("No unit is selected");
            return;
        }
        
        foreach(GameObject go in selectedUnits)
        {
            PlayAbilitySoundEffect(selectedAbility);
            go.GetComponent<Character>().ApplyAbilityToSelf(selectedAbility, turnOrder.GetMoving().GetComponent<Hero>().Damage);
        }
        ClearAllMarkers();
        selectedAbility = null;
        FinishCurrentPlayerCharacterTurn();
    }

    void FinishCurrentPlayerCharacterTurn()
    {
        CleanUpDeadAssets();
        selectedUnits = new();
        GameObject nowMovingGO = turnOrder.DoNext();
        isPlayersTurn = nowMovingGO.GetComponent<Character>().IsPlayer;
    }

    void FinishCurrentAICharacterTurn()
    {
        CleanUpDeadAssets();
        GameObject nowMovingGO = turnOrder.DoNext();
        isPlayersTurn = nowMovingGO.GetComponent<Character>().IsPlayer;
    }

    void CleanUpDeadAssets()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (go.GetComponent<Character>().Health <= 0)
            {
                go.GetComponent<SpriteRenderer>().enabled = false;
                go.GetComponent<BoxCollider2D>().enabled = false;
                turnOrder.RemoveFromTurnOrder(go);
            }
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (go.GetComponent<Character>().Health <= 0)
            {
                go.GetComponent<SpriteRenderer>().enabled = false;
                go.GetComponent<BoxCollider2D>().enabled = false;
                turnOrder.RemoveFromTurnOrder(go);
            }
        }
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Healthbar"))
        {
            go.GetComponent<HealthBar>().DoUpdateFillAmount(); // We want up-to-date information...Update doesn't happen fast enough
            if (go.GetComponent<HealthBar>().GetImageFilledComponent().fillAmount <= 0)
            {
                Destroy(go);
            }
        }
    }

    private void CreateHealthBars()
    {
        try
        {
            foreach (GameObject go in turnOrder.GetAllUnits())
            {
                GameObject hp = HpPrefab;
                hp.name = "HPBar " + go.name;
                Character tempChar = go.GetComponent<Character>();
                hp.GetComponent<HealthBar>().character = tempChar;

                GameObject created = Instantiate(hp, tempChar.HealthBarPosition, hp.transform.rotation);
                created.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (beginBattle)
        {
            DoBattleEnd(CheckForVictoryOrDefeat());
            if (isPlayersTurn)
            {
                PopulateAbilityButtons();
                CheckForNewTarget();
                // Other logic is automatically handled by double click method
            }
            // AI is moving
            else
            {
                // TODO: can make this "smarter"
                GameObject movingAI = turnOrder.GetMoving();
                Ability movingAbility = movingAI.GetComponent<Character>().Ability1;
                int movingAttack = movingAI.GetComponent<Character>().Attack;

                GameObject targetPlayerCharacter = GetRandomAlivePlayerCharacter();
                // This is null when no players are left standing
                if (targetPlayerCharacter == null)
                {
                    return;
                }

                PlayAbilitySoundEffect(movingAbility);
                targetPlayerCharacter.GetComponent<Character>().ApplyAbilityToSelf(movingAbility, movingAttack); // do attack
                FinishCurrentAICharacterTurn();
            }
        }
    }

    void PlayAbilitySoundEffect(Ability ability)
    {
        if (ability.soundEffect == null)
        {
            Debug.LogError("This ability needs a sound effect!");
        }
        audioSource.PlayOneShot(ability.soundEffect);
    }

    void DoBattleEnd(int result)
    {
        switch (result)
        {
            case 1:
                SceneManager.LoadScene(3); // Victory
                if (GameManager.CurrentFloorNumber == GameManager.CurrentlyChallengingFloorNumber)
                {
                    GameManager.NextGameFloor();
                }
                break;
            case -1:
                SceneManager.LoadScene(4); // Defeat
                break;
            default:
                return;
        }
    }

    /// <summary>
    /// Check for battle end state
    /// </summary>
    /// <returns>-1 = defeat, 0 = neither, 1 = victory</returns>
    private int CheckForVictoryOrDefeat()
    {
        bool isVictory = true;
        bool isDefeat = true;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (go.GetComponent<Character>().Health > 0)
            {
                isVictory = false;
            }
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (go.GetComponent<Character>().Health > 0)
            {
                isDefeat = false;
            }
        }

        if (isDefeat) return -1;
        if (isVictory) return 1;
        return 0;
    }

    GameObject GetRandomAlivePlayerCharacter()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");

        List<GameObject> playersAlive = new();
        foreach(GameObject go in gos)
        {
            if (go.GetComponent<Character>().IsAlive)
            {
                playersAlive.Add(go);
            }
        }

        if (playersAlive.Count <= 0)
        {
            return null;
        }

        Random r = new();
        return playersAlive.ElementAt(r.Next(playersAlive.Count));
    }

    /// <summary>
    /// Use Raycast to find a selected target
    /// </summary>
    void CheckForNewTarget()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {
            Debug.Log(hit.transform.gameObject.name + " Position: " + hit.collider.gameObject.transform.position);
            audioSource.PlayOneShot(targetSelectSound);
            DoMarker(hit.transform);
        }
    }

    /// <summary>
    /// Create a marker at the selected target(s).
    /// This uses context from eligibleTargets when choosing multiples
    /// </summary>
    /// <param name="selectedTarget"></param>
    void DoMarker(Transform selectedTarget)
    {
        if (selectedAbility == null)
            return;

        if (eligibleTarget == Ability.EligibleTarget.OneEnemy && selectedTarget.gameObject.CompareTag("Enemy"))
        {
            ClearAllMarkers();
            selectedTarget.gameObject.GetComponent<Character>().CreateMarker();
            selectedUnits = new List<GameObject>() { selectedTarget.gameObject };

        }
        else if (eligibleTarget == Ability.EligibleTarget.AllEnemy && selectedTarget.gameObject.CompareTag("Enemy"))
        {
            ClearAllMarkers();
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
            List<GameObject> tempSelected = new List<GameObject>();
            foreach(GameObject go in gos)
            {
                if (go.GetComponent<Character>().Health > 0)
                {
                    go.GetComponent<Character>().CreateMarker();
                    tempSelected.Add(go);
                }
            }
            selectedUnits = tempSelected;
        }
        else if (eligibleTarget == Ability.EligibleTarget.OneAlly && selectedTarget.gameObject.CompareTag("Player"))
        {
            ClearAllMarkers();
            selectedTarget.gameObject.GetComponent<Character>().CreateMarker();
            selectedUnits = new List<GameObject>() { selectedTarget.gameObject };
        }
        else if (eligibleTarget == Ability.EligibleTarget.AllAlly && selectedTarget.gameObject.CompareTag("Player"))
        {
            ClearAllMarkers();
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
            List<GameObject> tempSelected = new List<GameObject>();
            foreach (GameObject go in gos)
            {
                if (go.GetComponent<Character>().Health > 0)
                {
                    go.GetComponent<Character>().CreateMarker();
                    tempSelected.Add(go);
                }
            }
            selectedUnits = tempSelected;
        }
    }

    void ClearAllMarkers()
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("Marker");
        foreach(GameObject g in markers)
        {
            Destroy(g);
        }
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
            else
            {
                GameManager.HealPlayerCharacters();
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

            // Using vector3 for hp position is weird/bad...
            enemy1.GetComponent<Enemy>().SetAttributes(currentFloors.attack1, currentFloors.health1, currentFloors.speed1, new Vector3(-180, 111, 0));
            enemy2.GetComponent<Enemy>().SetAttributes(currentFloors.attack2, currentFloors.health2, currentFloors.speed2, new Vector3(-60, 111, 0));
            enemy3.GetComponent<Enemy>().SetAttributes(currentFloors.attack3, currentFloors.health3, currentFloors.speed3, new Vector3(60, 111, 0));
            enemy4.GetComponent<Enemy>().SetAttributes(currentFloors.attack4, currentFloors.health4, currentFloors.speed4, new Vector3(180, 111, 0));
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

            btnAbility1.onClick.RemoveListener(() => SetActiveAbility(0));
            btnAbility2.onClick.RemoveListener(() => SetActiveAbility(1));
            btnAbility3.onClick.RemoveListener(() => SetActiveAbility(2));

            btnAbility1.onClick.AddListener(() => SetActiveAbility(0));
            btnAbility2.onClick.AddListener(() => SetActiveAbility(1));
            btnAbility3.onClick.AddListener(() => SetActiveAbility(2));

        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e);
        }
    }

    void SetActiveAbility(int num)
    {
        switch (num)
        {
            case 0:
                selectedAbility = turnOrder.GetFirstMovingPlayer().GetComponent<Character>().Ability1;
                break;
            case 1:
                selectedAbility = turnOrder.GetFirstMovingPlayer().GetComponent<Character>().Ability2;
                break;
            case 2:
                selectedAbility = turnOrder.GetFirstMovingPlayer().GetComponent<Character>().Ability3;
                break;
        }
        eligibleTarget = selectedAbility.eligibleTargets;
        selectedUnits = new(); // Clear targets
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

            isPlayersTurn = turnOrder.GetMoving().GetComponent<Character>().IsPlayer;
        }
        catch (Exception e)
        {
            Debug.LogError("Could not find GameObjects with tag 'Player'" + e);
        }
    }
}

