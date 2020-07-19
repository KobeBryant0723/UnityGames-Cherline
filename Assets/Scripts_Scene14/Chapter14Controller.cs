using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chapter14Controller : MonoBehaviour
{
    public GameObject m_back;
    public GameObject m_yellow;
    public GameObject m_sporting;
    public GameObject m_sportingUp;
    public GameObject m_sportingDown;
    private int sportingCount;
    public GameObject m_GrayLeft;
    public GameObject m_GrayLeftBtn;
    public GameObject m_SitUp;
    public GameObject m_SitUpUp;
    public GameObject m_SitUpDown;
    private int sitUpCount;
    public GameObject m_GrayAll;
    public GameObject m_GaryNext;
    public GameObject m_Ending;
    public GameObject m_EndingBtnNext;
    public GameObject m_EndCloth;
    // Start is called before the first frame update
    void Start()
    {
        sportingCount = 0;
        sitUpCount = 0;
        m_yellow.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_sporting.SetActive(true);
                m_sportingDown.SetActive(!m_sportingDown.activeInHierarchy);
                m_sportingUp.SetActive(!m_sportingUp.activeInHierarchy);
                sportingCount++;
                if (sportingCount == 8)
                {
                    sportingCount = 0;
                    m_sporting.SetActive(false);
                    m_GrayLeft.SetActive(true);
                }
            }, 0.2f));
        });

        m_GrayLeftBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_SitUp.SetActive(true);
                m_SitUpDown.SetActive(!m_SitUpDown.activeInHierarchy);
                m_SitUpUp.SetActive(!m_SitUpUp.activeInHierarchy);
                sitUpCount++;
                if (sitUpCount == 8)
                {
                    sitUpCount = 0;
                    m_SitUp.SetActive(false);
                    m_GrayLeft.SetActive(false);
                    m_GrayAll.SetActive(true);
                }
            }, 0.2f));
        });
        m_GaryNext.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_Ending.SetActive(true);
            }, 0.2f));
        });
        m_EndingBtnNext.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_Ending.SetActive(false);
                m_EndCloth.SetActive(true);
                int count = Chapter12Controller.cloth;
                m_EndCloth.transform.GetChild(count).gameObject.SetActive(true);
            }, 0.2f));
        });

        m_sporting.SetActive(false);
        m_GrayLeft.SetActive(false);
        m_SitUp.SetActive(false);
        m_GrayAll.SetActive(false);
        m_Ending.SetActive(false);
        m_EndCloth.SetActive(false);


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
