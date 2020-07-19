using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeSceneScripts : MonoBehaviour
{
    public GameObject _ButtonHome;
    public GameObject _ButtonNewGame;
    public GameObject _ButtonContinue;
    public GameObject _Windows_Menu;
    public GameObject _ButtonYes;
    public GameObject _ButtonNo;
    public GameObject _ButtonReturnTheLastScene;

    public GameObject HomeObjects;
  
    // Start is called before the first frame update
    void Start()
    {
     
        GameObject canvas = GameObject.Find("Canvas");
        GameObject mainCamera = GameObject.Find("Main Camera");
        //Home键，显示是否返回主菜单
        _ButtonHome.GetComponent<Button>().onClick.AddListener(delegate
        {
            _Windows_Menu.SetActive(true);
        });
        //NewGame键，直接返回主菜单
        _ButtonNewGame.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(NewGame());
        });
        //Continue键，表示继续当前场景
        _ButtonContinue.GetComponent<Button>().onClick.AddListener(delegate
        {
            canvas.SetActive(true);
            mainCamera.SetActive(true);
            StartCoroutine(Waiting());
        });
        //yes键
        _ButtonYes.GetComponent<Button>().onClick.AddListener(delegate
        {
            //_Windows_Menu.SetActive(false);
            StartCoroutine(ButtonYes());
        });
        //no键
        _ButtonNo.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(ButtonNo());
        });
        //返回上一个场景按钮
        _ButtonReturnTheLastScene.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(ButtonReturnTheLastScene());
        });
        _ButtonHome.SetActive(false);
        _ButtonNewGame.SetActive(false);
        _ButtonContinue.SetActive(false);
        StartCoroutine(WaitingLoading());
        _Windows_Menu.SetActive(false);
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(0.1f);
        MenuState._MenuState = MenuStates.OPEN;
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Home"),
            UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
    }
    IEnumerator WaitingLoading()
    {
        yield return new WaitForSeconds(0.1f);
        Loading();
    }
    //NewGame
    IEnumerator NewGame()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("FirstScene");
    }
    //_ButtonYes
    IEnumerator ButtonYes()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("FirstScene");
    } 
    //_ButtonNo
    IEnumerator ButtonNo()
    {
        yield return new WaitForSeconds(0.1f);
        _Windows_Menu.SetActive(false);
    }
    //_ButtonReturnTheLastScene
    IEnumerator ButtonReturnTheLastScene()
    {
        yield return new WaitForSeconds(0.1f);
        int index= SceneManager.GetActiveScene().buildIndex-1;
        if (index <= 0) index = 1;
        StartCoroutine(Waiting());
        SceneManager.LoadScene(index);
    }
 



    private void Loading()
    {
        GameObject canvas = GameObject.Find("Canvas");//这个是底层场景的Canvas
        canvas.SetActive(false);
        GameObject mainCamera = GameObject.Find("Main Camera");//这个是底层场景的Canvas
        if(mainCamera!=null)
        mainCamera.SetActive(false);
        _ButtonHome.SetActive(true);
        _ButtonNewGame.SetActive(true);
        _ButtonContinue.SetActive(true);
    }
}
