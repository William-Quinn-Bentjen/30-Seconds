using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitManager : MonoBehaviour {
    public static WaitManager instance;
    public player_movment PlayerMovement;
    public timer RoundTimer;
    public bool isWaiting = false;
    [Header("BASE Resource reduction")]
    public int foodReduction = 1;
    public int waterReduction = 1;
    public int medicalSuppliesReduction = 1;
    public int weaponsReduction = 1;
    [Header("Resource reduction increase per wait")]
    public int foodReductionIncrease;
    public int waterReductionIncrease;
    public int medicalSuppliesReductionIncrease;
    public int weaponsReductionIncrease;
    //private
    private GameObject Player;
    private Transform OutOfBunker;
    //functions
    private void IncreaseReduction()
    {
        foodReduction += foodReductionIncrease;
        waterReduction += waterReductionIncrease;
        medicalSuppliesReduction += medicalSuppliesReductionIncrease;
        weaponsReduction += weaponsReductionIncrease;
    }
    public bool ReduceResources()
    {
        List<Food> food = ResourceHolder.GetFood();
        List<MedicalSupplies> medicalSupplies = ResourceHolder.GetMedicalSupplies();
        List<Water> water = ResourceHolder.GetWater();
        List<Weapon> weapon = ResourceHolder.GetWeapon();
        //did the player die? if so don't even bother with anything else
        if (food.Count < foodReduction || water.Count < waterReduction || medicalSupplies.Count < medicalSuppliesReduction || weapon.Count < weaponsReduction)
        {
            //player is dead...... do something
            Debug.Log("Player died from lack of resources");
            DeathScreen.instance.EnableDeathScreen("Not having enough resources to survive");
            return false;
        }
        else
        {
            //remove food from bunker
            for (int i = 0; i < foodReduction; i++)
            {
                ResourceHolder.Bunker.Remove(food[i]);
            }
            //remove water from bunker
            for (int i = 0; i < waterReduction; i++)
            {
                ResourceHolder.Bunker.Remove(water[i]);
            }
            //remove meds from player
            for (int i = 0; i < medicalSuppliesReduction; i++)
            {
                ResourceHolder.Bunker.Remove(medicalSupplies[i]);
            }
            //remove weapons from player
            for (int i = 0; i < weaponsReduction; i++)
            {
                ResourceHolder.Bunker.Remove(weapon[i]);
            }
            //increase the reduction for next time this function is called
            IncreaseReduction();
            //update the UI for in bunker
            UIManager.instance.UpdateBunkerResources();
            //had enough resources to live?
            return true;
        }
        
        
    }
    public void StartTimer()
    {
        RoundTimer.timeleft = 30;
    }
    
    //start gather phase (when over kill player or if the player got to the bunker the wait phase will be called)
    public void StartGatherPhase()
    {
        ResourceSpawner.instance.SpawnResources();
        Player.transform.position = OutOfBunker.transform.position;
        StartTimer();
        isWaiting = false;
        PlayerMovement.enabled = true;
        UIManager.instance.SkipWaitButton.gameObject.SetActive(false);
    }
    //got to bunker wait for next gather phase
    public void StartWaitPhase()
    {
        ResourceSpawner.instance.ClearSpawnedResources();
        StartTimer();
        isWaiting = true;
        PlayerMovement.enabled = false;
        UIManager.instance.SkipWaitButton.gameObject.SetActive(true);
    }
    public void SkipWait()
    {
        if (isWaiting)
        {
            //reduce resources and see if the player survived 
            if (ReduceResources())
            {
                //start the next phase (the reduce resources checks for death so this will only be run if the player didn't die)
                StartGatherPhase();
            }
        }
        else
        {
            throw new System.Exception("can't skip wait if isWaiting is false");
        }
    }
    private bool playerDead = false;
    public void OnTimeUp()
    {
        if (isWaiting)
        {
            StartGatherPhase();
        }
        else
        {
            if (playerDead != true)
            {
                //player didn't make it to the bunker.....
                Debug.Log("player died from not getting to the bunker fast enough");
                DeathScreen.instance.EnableDeathScreen("Not getting to the bunker in time");
                playerDead = true;
            }
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            throw new System.Exception("Wait manager already exists destroying the sencond one");
        }
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        OutOfBunker = GetComponent<Bunker>().OutOfBunker;
        StartGatherPhase();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
