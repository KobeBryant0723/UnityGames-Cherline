using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chapter1Controller : MonoBehaviour
{
    public GameObject _ChapterButton;
    public Button nextButton;

    public GameObject _VideoPlayer;
    public Button _VideoButton;

    public GameObject _Windows;
    public Button _WindowsButton;
    public GameObject _WindowsPlayer;
    public Button _OutdoorButton;

    public GameObject _SpeakingSelf;
    public Button _SpeakingButton;
    public Button _NextChapterBTN;
    private int num=1;

    public GameObject _PrimaryVideo;
    public Button _PrimaryBtn;

    public GameObject _ExamVideo;
    public Button _ExamBtn;
    
    // Start is called before the first frame update
    void Start()
    {
        _VideoPlayer.SetActive(false);
        _VideoButton.gameObject.SetActive(false);
        _Windows.SetActive(false);
        _WindowsPlayer.SetActive(false);
        _SpeakingSelf.SetActive(false);
        _ExamVideo.SetActive(false);

        nextButton.onClick.AddListener(delegate
        {
            StartCoroutine(NextVideoLoading());
        });

        _VideoButton.onClick.AddListener(delegate
        {
            StartCoroutine(VideoLoading());
        });

        _WindowsButton.onClick.AddListener(delegate
        {
            StartCoroutine(WindowsLoading());
        });

        _OutdoorButton.onClick.AddListener(delegate
        {
            StartCoroutine(OutdoorLoading());
        });

        _SpeakingButton.onClick.AddListener(delegate
        {
            StartCoroutine(SpeakingLoading());
          
        });

        _NextChapterBTN.onClick.AddListener(delegate
        {
            StartCoroutine(NextChapterButton());
        });
        _PrimaryBtn.onClick.AddListener(delegate
        {
            StartCoroutine(PrimarySchool());
        });
        _ExamBtn.onClick.AddListener(delegate
        {
            StartCoroutine(Exam());
        });
        _NextChapterBTN.gameObject.SetActive(false);
        _PrimaryVideo.gameObject.SetActive(false);
        _ExamBtn.gameObject.SetActive(false);
    }
    //NextButton
    IEnumerator NextVideoLoading()
    {
        _VideoButton.gameObject.SetActive(true);
        _VideoPlayer.SetActive(true);
     
        yield return new WaitForSeconds(0.2f);
        _ChapterButton.SetActive(false);
        yield return null;

    }
    //VideoButton
    IEnumerator VideoLoading()
    {
        _Windows.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _VideoPlayer.SetActive(false);
    }
    //WinodowButton
    IEnumerator WindowsLoading()
    {
        _WindowsPlayer.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _Windows.SetActive(false);
    }
    //OutdoorButton
    IEnumerator OutdoorLoading()
    {
        _SpeakingSelf.SetActive(true);
         yield return new WaitForSeconds(0.3f);
        _WindowsPlayer.SetActive(false);
    }
    IEnumerator DelayToAction(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }
    //SpeakingButton
    IEnumerator SpeakingLoading()
    {
        if (num <= 3)
        {
            Debug.Log(num);
            _SpeakingSelf.GetComponent<Image>().overrideSprite = Resources.Load("幼儿园/1" + num.ToString(), typeof(Sprite)) as Sprite;
            num++;
            yield return null;
        }
        if (num == 4)
        {
            yield return new WaitForSeconds(0.1f);
            _SpeakingButton.gameObject.SetActive(false);
            _NextChapterBTN.gameObject.SetActive(true);
            num++;
        
        }
     

    }
    //NextChapterButton
    IEnumerator NextChapterButton()
    {
        _PrimaryVideo.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        _SpeakingSelf.SetActive(false);
        _PrimaryBtn.gameObject.SetActive(true);
    }
    //PrimarySchool
    IEnumerator PrimarySchool()
    {
        _ExamVideo.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _ExamBtn.gameObject.SetActive(true);
        _PrimaryVideo.SetActive(false);
    }
    //ExamAnimation
    IEnumerator Exam()
    {
        SceneManager.LoadSceneAsync(3);
        yield return new WaitForSeconds(0.2f);
    }
}
