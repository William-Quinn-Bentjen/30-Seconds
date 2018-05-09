using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour {
    public static ResourceSpawner instance;
    public int ResourcesToBeSpawned;
    public GameObject SpawnPoints;
    public GameObject Resources;
    public List<GameObject> SpawnableResources = new List<GameObject>();
    public void ClearSpawnedResources()
    {
        //destroy all children of the resources gameobject
        //int kiddoCount = Resources.transform.childCount;
        //while (kiddoCount != 0)
        //{
        //    kiddoCount--;
        //    Destroy(Resources.transform.GetChild(0));
            
        //}

        //removes objects that aren't "in backpack or bunker"
        for (int i = 0; i < Resources.transform.childCount; i++)
        {
            GameObject resource = Resources.transform.GetChild(i).gameObject;
            //is it in a backpack or bunker?
            if (resource.activeSelf)
            {
                //if not destroy it
                Destroy(resource);
            }
            //Transform kiddo = Resources.transform.GetChild(i);
            //if(kiddo != null)
            //{
                
            //    Destroy(kiddo);
            //    i--;
            //}
           
            
        }
    }
    public void SpawnResources()
    {
        ClearSpawnedResources();
        List<Transform> spawns = FindSpawnPoints();
        if (spawns.Count >= ResourcesToBeSpawned && SpawnableResources.Count > 0)
        {
            for (int i = 0; i < ResourcesToBeSpawned; i++)
            {
                int rando = Random.Range(0, spawns.Count);
                int randoItem = Random.Range(0, SpawnableResources.Count);
                Instantiate(SpawnableResources[randoItem], spawns[rando].transform.position, spawns[rando].transform.rotation, Resources.transform);
                spawns.Remove(spawns[rando]);
            }
        }
        else
        {
            throw new System.Exception("not enough places to spawn resources");
        }
        
    }
    public List<Transform> FindSpawnPoints()
    {
        List<Transform> validSpawns =  new List<Transform>();
        foreach (Transform child in SpawnPoints.transform)
        {
            if (Physics.CheckSphere(child.position, .05f) == false)
            {
                validSpawns.Add(child);
            }
        }
        return validSpawns;
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
            throw new System.Exception("can't have a second resource spawner destroying the second one");
        }
    }
}
