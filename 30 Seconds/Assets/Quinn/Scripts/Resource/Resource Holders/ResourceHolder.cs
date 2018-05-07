using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHolder : MonoBehaviour {
    public static List<Resource> Backpack = new List<Resource>();
    public static List<Resource> Bunker = new List<Resource>();
    public static void AddToBackPack(Resource resource)
    {
        Food foodCheck = resource.GetComponent<Food>();
        Water waterCheck = resource.GetComponent<Water>();
        MedicalSupplies medicalSuppliesCheck = resource.GetComponent<MedicalSupplies>();
        Weapon weaponCheck = resource.GetComponent<Weapon>();
        if (foodCheck)
        {
            //add food
            UIManager.instance.UpdateBackpackFood();
        }
        else if (waterCheck)
        {
            //add water
            UIManager.instance.UpdateBackpackWater();
        }
        else if (medicalSuppliesCheck)
        {
            //add meds
            UIManager.instance.UpdateBackpackMedicalSupplies();
        }
        else if (weaponCheck)
        {
            //add weapon
            UIManager.instance.UpdateBackpackWeapons();
        }
        Backpack.Add(resource);
        resource.gameObject.SetActive(false);
    }
    public static void EmptyBackpack(bool emptyIntoBunker = true)
    {
        if (emptyIntoBunker)
        {
            while (Backpack.Count != 0)
            {
                //take item in first slot of list and dump it into the bunker
                Bunker.Add(Backpack[0]);
                Backpack.RemoveAt(0);
            }
        }
        //reset the UI for the backpack
        UIManager.instance.ResetBackPackResources();
        UIManager.instance.UpdateBunkerResources();
    }
    public static List<Food> GetFood()
    {
        List<Food> retVal = new List<Food>();
        foreach (Resource resource in Bunker)
        {
            Food foodCheck = resource.GetComponent<Food>();
            if (foodCheck)
            {
                retVal.Add(foodCheck);
            }
        }
        return retVal;
    }
    public static List<Water> GetWater()
    {
        List<Water> retVal = new List<Water>();
        foreach (Resource resource in Bunker)
        {
            Water waterCheck = resource.GetComponent<Water>();
            if (waterCheck)
            {
                retVal.Add(waterCheck);
            }
        }
        return retVal;
    }
    public static List<MedicalSupplies> GetMedicalSupplies()
    {
        List<MedicalSupplies> retVal = new List<MedicalSupplies>();
        foreach (Resource resource in Bunker)
        {
            MedicalSupplies medicalSuppliesCheck = resource.GetComponent<MedicalSupplies>();
            if (medicalSuppliesCheck)
            {
                retVal.Add(medicalSuppliesCheck);
            }
        }
        return retVal;
    }
    public static List<Weapon> GetWeapon()
    {
        List<Weapon> retVal = new List<Weapon>();
        foreach (Resource resource in Bunker)
        {
            Weapon weaponCheck = resource.GetComponent<Weapon>();
            if (weaponCheck)
            {
                retVal.Add(weaponCheck);
            }
        }
        return retVal;
    }
}
