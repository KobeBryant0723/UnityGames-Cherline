using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chapter15Controller : MonoBehaviour
{
    public GameObject emmmm1;
    public GameObject emmmm;

    public GameObject m_Argue;
    public GameObject m_DontFit;
    public GameObject m_DontThink;
    public GameObject m_Tear;
    public GameObject m_Move;
    public GameObject m_MoveBoy;

    public GameObject m_hug1;
    public GameObject m_hug2;
    public GameObject m_hug3;
    public GameObject m_hug4;
    public GameObject m_hug4NextBtn;

    public GameObject m_Ending;
    public GameObject m_EndingNextbtn;
    public GameObject m_EndingWedding;

    // Start is called before the first frame update
    void Start()
    {
        m_Argue.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_Argue.SetActive(false);
                m_DontFit.SetActive(true);
            }, 0.2f));
        });
        m_DontFit.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_DontFit.SetActive(false);
                m_DontThink.SetActive(true);
            }, 0.2f));
        });
        m_DontThink.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_DontThink.SetActive(false);
                m_Tear.SetActive(true);
            }, 0.2f));
        });
        m_Tear.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_Tear.SetActive(false);
                m_Move.SetActive(true);
            }, 0.2f));
        });

        m_hug1.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_hug1.SetActive(false);
                m_hug2.SetActive(true);
            }, 0.2f));
        });
        m_hug2.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_hug2.SetActive(false);
                m_hug3.SetActive(true);
            }, 0.2f));
        });
        m_hug3.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_hug3.SetActive(false);
                m_hug4.SetActive(true);
            }, 0.2f));
        });
        m_hug4NextBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_hug4.SetActive(false);
                m_Ending.SetActive(true);
            }, 0.2f));
        });
        m_EndingNextbtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_Ending.SetActive(false);
                m_EndingWedding.SetActive(true);
            }, 0.2f));
        });

        m_Argue.SetActive(false);
        m_DontFit.SetActive(false);
        m_DontThink.SetActive(false);
        m_Tear.SetActive(false);
        m_Move.SetActive(false);
        m_hug1.SetActive(false);
        m_hug2.SetActive(false);
        m_hug3.SetActive(false);
        m_hug4.SetActive(false);
        m_Ending.SetActive(false);
        m_EndingWedding.SetActive(false);
        StartCoroutine(Play());
    }
    IEnumerator DelayToAction(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }
    
    IEnumerator Play()
    {
        while (emmmm1.transform.childCount != 0)
        {
            yield return null;
        }
       
        yield return new WaitForSeconds(1.2f);
        emmmm.SetActive(false);
        emmmm1.SetActive(false);
        m_Argue.SetActive(true);
    }

}
