using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chapter10Controller : MonoBehaviour
{
    public GameObject pic1;
    public GameObject pic2;
    public GameObject pic3;
    public GameObject pic4;
    public GameObject pic5;
    public GameObject pic6;
    public GameObject gril;
    public GameObject boy;

    // Start is called before the first frame update
    void Start()
    {
        gril.GetComponent<Button>().onClick.AddListener(delegate
        {
            boy.SetActive(true);
            gril.SetActive(false);
        });
        pic2.SetActive(false);
        pic3.SetActive(false);
        pic4.SetActive(false);
        pic5.SetActive(false);
        pic6.SetActive(false);
        gril.SetActive(false);
        boy.SetActive(false);

    }
    public GameObject back;
    IEnumerator PlayPic()
    {
        pic1.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        GameObject temp1= GameObject.Instantiate(Resources.Load("Empty1") as GameObject,back.transform);
        GameObject temp2 = GameObject.Instantiate(Resources.Load("Empty") as GameObject,back.transform);
        //temp1.transform.SetParent(back.transform);
        //temp2.transform.SetParent(back.transform);
        temp1.transform.SetAsLastSibling();
        while (temp1.transform.childCount != 0)
        {
            yield return null;
        }
        Destroy(temp1);
        Destroy(temp2);
        gril.SetActive(true);
        pic1.SetActive(false);
        pic2.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        while(!boy.activeInHierarchy)
        {
            yield return null;
        }
      
        GameObject temp11 = GameObject.Instantiate(Resources.Load("Empty1") as GameObject, back.transform);
        GameObject temp22 = GameObject.Instantiate(Resources.Load("Empty") as GameObject, back.transform);
        temp11.transform.SetAsLastSibling();
        while (temp11.transform.childCount != 0)
        {
            yield return null;
        }
        boy.SetActive(false);
        Destroy(temp11);
        Destroy(temp22);
        gril.SetActive(true);
        pic2.SetActive(false);
        pic3.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        while (!boy.activeInHierarchy)
        {
            yield return null;
        }
     
        GameObject temp111 = GameObject.Instantiate(Resources.Load("Empty1") as GameObject, back.transform);
        GameObject temp222 = GameObject.Instantiate(Resources.Load("Empty") as GameObject, back.transform);
        temp111.transform.SetAsLastSibling();
        while (temp111.transform.childCount != 0)
        {
            yield return null;
        }
        boy.SetActive(false);
        Destroy(temp111);
        Destroy(temp222);
        gril.SetActive(true);
        pic3.SetActive(false);
        pic4.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        while (!boy.activeInHierarchy)
        {
            yield return null;
        }
     
        GameObject temp1111 = GameObject.Instantiate(Resources.Load("Empty1") as GameObject, back.transform);
        GameObject temp2222 = GameObject.Instantiate(Resources.Load("Empty") as GameObject, back.transform);
        temp1111.transform.SetAsLastSibling();
        while (temp1111.transform.childCount != 0)
        {
            yield return null;
        }
        boy.SetActive(false);
        Destroy(temp1111);
        Destroy(temp2222);
        gril.SetActive(true);
        pic4.SetActive(false);
        pic5.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        while (!boy.activeInHierarchy)
        {
            yield return null;
        }
     
        GameObject temp11111 = GameObject.Instantiate(Resources.Load("Empty1") as GameObject, back.transform);
        GameObject temp22222 = GameObject.Instantiate(Resources.Load("Empty") as GameObject, back.transform);
        temp11111.transform.SetAsLastSibling();
        while (temp11111.transform.childCount != 0)
        {
            yield return null;
        }
        boy.SetActive(false);
        Destroy(temp11111);
        Destroy(temp22222);
        pic5.SetActive(false);
        pic6.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(10);
    }

    IEnumerator DelayToAction(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(PlayPic());
    }
    private void OnDisable()
    {
        pic2.SetActive(false);
        pic3.SetActive(false);
        pic4.SetActive(false);
        pic5.SetActive(false);
        pic6.SetActive(false);
    }
  
}
