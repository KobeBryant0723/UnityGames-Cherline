using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chapter3Controller : MonoBehaviour
{
  
    public GameObject classroom;
    public GameObject classroomNName;

    public Button _NameTrigger;

    public GameObject deskGarbage;

    public Button 瓶;
    public Button 果核;
    public Button 纸团;
    public Button 香蕉皮;
    public Button _BackClassRoomBtn;

    public GameObject _DeskSeeingWindows;
    public Button _DiaryBtn;
    public GameObject _DiaryContents;
    public Button _FinishedBtn;

    // Start is called before the first frame update
    void Start()
    {
        _NameTrigger.onClick.AddListener(delegate
        {
            if(scene==0)
            StartCoroutine(DeskWindow());
            else
            StartCoroutine(DeskSeeingWindow());
        });

        瓶.onClick.AddListener(delegate
        {
            StartCoroutine(PING());

        });
        果核.onClick.AddListener(delegate
        {
            StartCoroutine(GUOHE());
        });
        纸团.onClick.AddListener(delegate
        {
            StartCoroutine(ZHITUAN());
        });
        香蕉皮.onClick.AddListener(delegate
        {
            StartCoroutine(XIAOJIAOPI());
        });
        _BackClassRoomBtn.onClick.AddListener(delegate
        {
            StartCoroutine(BackClassRoomBtn());
        });
        _DiaryBtn.onClick.AddListener(delegate
        {
            StartCoroutine(DiaryBtn());
        });
        _FinishedBtn.onClick.AddListener(delegate
        {
            StartCoroutine(FinishedBtn());
        });
        classroomNName.SetActive(false);
        deskGarbage.SetActive(false);
        _DeskSeeingWindows.SetActive(false);
        _DiaryContents.SetActive(false);
        _BackClassRoomBtn.gameObject.SetActive(false);

    }
    //_FinishedBtn
    IEnumerator FinishedBtn()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadSceneAsync(5);
    }
    //_DiaryBtn
    IEnumerator DiaryBtn()
    {
        yield return new WaitForSeconds(0.1f);
        _DeskSeeingWindows.SetActive(false);
        _DiaryContents.SetActive(true);
    }
    //_BackClassRoomBtn
    IEnumerator BackClassRoomBtn()
    {
        yield return new WaitForSeconds(0.1f);
        deskGarbage.SetActive(false);
        classroom.SetActive(true);
        _NameTrigger.gameObject.SetActive(true);
        scene = 1;
    }

    private int scene = 0;
    //DeskWindow
    IEnumerator DeskWindow()
    {
        yield return new WaitForSeconds(0.1f);
        classroomNName.SetActive(false);
        classroom.SetActive(false);
        _NameTrigger.gameObject.SetActive(false);
        deskGarbage.SetActive(true);
        yield return null;
    }

    IEnumerator DeskSeeingWindow()
    {
        yield return new WaitForSeconds(0.1f);
        classroomNName.SetActive(false);
        classroom.SetActive(false);
        _NameTrigger.gameObject.SetActive(false);
        _DeskSeeingWindows.SetActive(true);
        yield return null;
    }
    private void Update()
    {
        if(deskGarbage.activeInHierarchy&&
            !瓶.gameObject.activeInHierarchy&&
            !果核.gameObject.activeInHierarchy&&
            !纸团.gameObject.activeInHierarchy&&
            !香蕉皮.gameObject.activeInHierarchy)
        {
            _BackClassRoomBtn.gameObject.SetActive(true);
        }

    }


    //垃圾
    IEnumerator PING()
    {
        yield return new WaitForSeconds(0.1f);
        瓶.gameObject.SetActive(false);
    }
    IEnumerator GUOHE()
    {
        yield return new WaitForSeconds(0.1f);
        果核.gameObject.SetActive(false);
    }
    IEnumerator ZHITUAN()
    {
        yield return new WaitForSeconds(0.1f);
        纸团.gameObject.SetActive(false);
    }
    IEnumerator XIAOJIAOPI()
    {
        yield return new WaitForSeconds(0.1f);
        香蕉皮.gameObject.SetActive(false);
    }
}
