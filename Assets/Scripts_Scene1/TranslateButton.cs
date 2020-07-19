using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TranslateButton : MonoBehaviour
{
   
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();

        btn.onClick.AddListener(delegate
        {
            SceneManager.LoadSceneAsync(1);
          //  SceneManager.LoadScene(1);//加载第二个场景
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
