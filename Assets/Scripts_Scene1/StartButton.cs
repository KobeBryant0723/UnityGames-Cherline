using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    Button btn;
    public GameObject _Start;
    public GameObject _VideoPlayer;
    public GameObject _SecondImage;

    private void Awake()
    {
        _SecondImage.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        
        btn.onClick.AddListener(delegate
        {
            //_Start.SetActive(false);
            _VideoPlayer.SetActive(false);
            _SecondImage.SetActive(true);
          
            //SceneManager.LoadScene(1);//加载第二个场景
        });

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip);
        }
    }

    public void HHH()
    {
        this.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip);
    }
}
