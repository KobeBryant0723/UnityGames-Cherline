using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate
        {
            SceneManager.LoadSceneAsync("Home", LoadSceneMode.Additive);
            
            MenuState._MenuState = MenuStates.OPEN;
        });
    }

   
}
