using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Chapter6Controller : MonoBehaviour
{
    public GameObject canvas;
    private float _CanvasScale;
    public GameObject _Pen;
    public GameObject _Mask;
    public GameObject _Draw;
    public GameObject _Boy;
    public GameObject _HighSchool;
    public Button _HighSchoolBTN;

    public GameObject _Left;
    public GameObject _Right;

    public Texture2D ClickedCursorImg;
    // Start is called before the first frame update
    void Start()
    {
        _CanvasScale = canvas.GetComponent<RectTransform>().localScale.x;
        Debug.Log(_CanvasScale);
        ImagePos = Vector2.zero;
        _Pen.GetComponent<Button>().onClick.AddListener(delegate
        {
            //把鼠标指针改为ClickedCursorImg
            Cursor.visible = false;
            //Cursor.SetCursor(ClickedCursorImg, Vector2.zero, CursorMode.Auto);
            // 重置鼠标指针图标
            StartCoroutine(DrawImageWihtPen());
            //Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        
        });
        _HighSchoolBTN.onClick.AddListener(delegate
        {
            StartCoroutine(HighSchoolBTN());
        });
        _Pen.SetActive(false);
        _Mask.SetActive(false);
        _Boy.SetActive(false);
        _Draw.SetActive(false);
    }
    //_HighSchoolBTN
    IEnumerator HighSchoolBTN()
    {
        yield return new WaitForSeconds(0.1f);
        _HighSchool.SetActive(false);
        _Pen.SetActive(true);
        _Mask.SetActive(true);
        _Boy.SetActive(true);
        _Draw.SetActive(true);
    }
    private Vector2 ImagePos;
    //Pen
    IEnumerator DrawImageWihtPen()
    {
        Destroy(_Pen.GetComponent<ButtonAnimation>());
        Destroy(_Pen.GetComponent<Button>());
        Vector2 initialMaskSize = _Mask.GetComponent<RectTransform>().sizeDelta;
        Vector2 initialMaskPos = _Mask.GetComponent<RectTransform>().position;
        float boundValue = _Left.GetComponent<RectTransform>().position.x;
        float right = _Right.GetComponent<RectTransform>().position.x;
        float length = right - boundValue;
        Debug.Log(boundValue+"?"+ right);
        while (true)
        {
            _Pen.transform.position = Input.mousePosition;
            float proportion = (_Pen.transform.position.x - boundValue) / length;
            if (_Pen.transform.position.x > boundValue && _Pen.transform.position.x < right)
            {
                if((1 - proportion) * initialMaskSize.x <= _Mask.GetComponent<RectTransform>().sizeDelta.x)
                {
                    //_Mask.GetComponent<RectTransform>().sizeDelta = new Vector2((initialMaskSize.x -
                    //_Pen.transform.position.x + boundValue)/ _CanvasScale,
                    //_Mask.GetComponent<RectTransform>().sizeDelta.y);
                 
                    _Mask.GetComponent<RectTransform>().sizeDelta = new Vector2((1-proportion) * initialMaskSize.x,
                      initialMaskSize.y);
                    //_Mask.GetComponent<RectTransform>().position = new Vector2(initialMaskPos.x +
                    //   0.5f * (_Pen.transform.position.x - boundValue)
                    //  , _Mask.GetComponent<RectTransform>().position.y);
                }
            }
            if (_Mask.GetComponent<RectTransform>().sizeDelta.x < 0.8f)
            {
                _Mask.SetActive(false);
                yield return new WaitForSeconds(2);
                Cursor.visible = true;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                SceneManager.LoadSceneAsync(6);
            }
            yield return null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
