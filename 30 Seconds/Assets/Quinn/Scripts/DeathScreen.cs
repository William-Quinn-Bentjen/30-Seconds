using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {
    public static DeathScreen instance;
    public Canvas DeathScreenCanvas;
    public Text DeathInfo;
    public void Quit()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game Starting Scene");
    }
    public void EnableDeathScreen(string deathInfo)
    {
        if (DeathScreenCanvas.enabled == false)
        {
            UIManager.instance.UI.enabled = false;
            WaitManager.instance.PlayerMovement.enabled = false;
            DeathInfo.text = deathInfo;
            DeathScreenCanvas.enabled = true;
            //backpack and bunker clear
            ResourceHolder.Bunker.Clear();
            ResourceHolder.Backpack.Clear();
        }
        else
        {
            throw new System.Exception("can't enable death screen when it's already enabled, check your code");
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
            throw new System.Exception("Only one instance of death screen may be alive at once, destroying the second one");
        }
        DeathScreenCanvas.enabled = false;
    }
}
