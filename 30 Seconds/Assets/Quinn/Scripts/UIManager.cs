using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;
    public Canvas UI;
    public Text TimerText;
    public Button SkipWaitButton;
    [Header("Backpack Resources Text")]
    public Text FoodInBackpack;
    private int FoodInBackpackValue;
    public Text WaterInBackpack;
    private int WaterInBackpackValue;
    public Text MedicalSuppliesInBackpack;
    private int MedicalSuppliesInBackpackValue;
    public Text WeaponsInBackpack;
    private int WeaponsInBackpackValue;
    [Header("Bunker Resources Text")]
    public Text FoodInBunker;
    public Text WaterInBunker;
    public Text MedicalSuppliesInBunker;
    public Text WeaponsInBunker;
    public void UpdateBunkerResources()
    {
        FoodInBunker.text = "Food\n" + ResourceHolder.GetFood().Count;
        WaterInBunker.text = "Water\n" + ResourceHolder.GetWater().Count;
        MedicalSuppliesInBunker.text = "Medical Supplies\n" + ResourceHolder.GetMedicalSupplies().Count;
        WeaponsInBunker.text =  "Weapons\n" + ResourceHolder.GetWeapon().Count;
    }
    public void ResetBackPackResources()
    {
        //reset values and text
        FoodInBackpackValue = 0;
        FoodInBackpack.text = "Food\n0";
        WaterInBackpackValue = 0;
        WaterInBackpack.text = "Water\n0";
        MedicalSuppliesInBackpackValue = 0;
        MedicalSuppliesInBackpack.text = "Medical Supplies\n0";
        WeaponsInBackpackValue = 0;
        WeaponsInBackpack.text = "Weapons\n0";
    }
    public void UpdateBackpackFood()
    {
        //add one to value and set the text
        FoodInBackpackValue++;
        FoodInBackpack.text = "Food\n" + FoodInBackpackValue.ToString();
    }
    public void UpdateBackpackWater()
    {
        //add one to value and set the text
        WaterInBackpackValue++;
        WaterInBackpack.text = "Water\n" + WaterInBackpackValue.ToString();
    }
    public void UpdateBackpackMedicalSupplies()
    {
        //add one to value and set the text
        MedicalSuppliesInBackpackValue++;
        MedicalSuppliesInBackpack.text = "Medical Supplies\n" + MedicalSuppliesInBackpackValue.ToString();
    }
    public void UpdateBackpackWeapons()
    {
        //add one to value and set the text
        WeaponsInBackpackValue++;
        WeaponsInBackpack.text = "Weapons\n" + WeaponsInBackpackValue.ToString();
    }
    public void UpdateTimer(float value)
    {
        TimerText.text = "Time Left " + value.ToString("0");
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
            throw new System.Exception("Only one UI manager can exist destroying the second one");
        }
        ResetBackPackResources();
        UpdateBunkerResources();
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
