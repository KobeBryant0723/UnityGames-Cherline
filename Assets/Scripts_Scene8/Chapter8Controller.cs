using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chapter8Controller : MonoBehaviour
{
    public GameObject m_IntialImage;
    public GameObject m_NextBtn;
    public GameObject m_RawImage;
    public GameObject m_GirlBtn;
    public GameObject m_pic1;
    public GameObject m_pic2;
    public GameObject m_pic3;

    private int num;


    // Start is called before the first frame update
    void Start()
    {
        num = 1;

        m_NextBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate ()
            {
                m_IntialImage.SetActive(false);
                m_RawImage.SetActive(true);
            }, 0.2f));
             
        });
        m_GirlBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate ()
            {
               
                if (num == 1)
                {
                    m_pic1.SetActive(true);
                    m_GirlBtn.GetComponent<AudioSource>().clip = Resources.Load("音符2") as AudioClip;
                }
                else if(num == 2)
                {
                    m_pic2.SetActive(true);
                    m_GirlBtn.GetComponent<AudioSource>().clip = Resources.Load("音符3") as AudioClip;
                }
                else if(num == 3)
                {
                    m_pic3.SetActive(true);
                    num = 1;
                    StartCoroutine(DelayToAction(delegate ()
                    {
                        m_GirlBtn.GetComponent<AudioSource>().clip = Resources.Load("音符1") as AudioClip;
                        SceneManager.LoadScene(8);
                    }, 0.2f));
                }
                num++;
            }, 0.2f));
             
        });

        m_RawImage.SetActive(false);
        m_pic1.SetActive(false);
        m_pic2.SetActive(false);
        m_pic3.SetActive(false);
    }



    IEnumerator DelayToAction(Action action,float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
