using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chapter13Controller : MonoBehaviour
{
    public GameObject m_chapter;
    public GameObject m_next;
    public GameObject m_catch;
    public GameObject m_fitIn;
    public GameObject m_fitInYes;
    public GameObject m_fitInNo;
    public GameObject m_Maybe;
    public GameObject m_MaybeYes;
    public GameObject m_MaybeNo;
    public GameObject m_videoFire;
    public GameObject m_videroFireBtn;
    // Start is called before the first frame update
    void Start()
    {
        m_next.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_chapter.SetActive(false);
                m_catch.SetActive(true);
              
            }, 0.2f));
        });
        m_catch.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_fitIn.SetActive(true);
            }, 0.2f));
        });
        m_fitInYes.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_fitIn.SetActive(false);
                m_Maybe.SetActive(true);
            }, 0.2f));
        });
        m_fitInNo.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_fitIn.SetActive(false);
                m_Maybe.SetActive(true);
            }, 0.2f));
        });
        m_MaybeYes.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                //运动章节
                m_Maybe.SetActive(false);
                m_videoFire.SetActive(true);
            }, 0.2f));
        });
        m_MaybeNo.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                //争吵章节
                m_Maybe.SetActive(false);
                SceneManager.LoadScene(14);
            }, 0.2f));
        });
        m_videroFireBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                //运动章节
                SceneManager.LoadScene(13);
                m_Maybe.SetActive(false);
            }, 0.2f));
        });

        m_catch.SetActive(false);
        m_fitIn.SetActive(false);
        m_Maybe.SetActive(false);
        m_videoFire.SetActive(false);
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
}
