using UnityEngine;
using System.Collections;

public class MusicPlay : MonoBehaviour
{
    static MusicPlay _instance;
    // Use this for initialization
    void Start()
    {

    }
    public static MusicPlay instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MusicPlay>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    void Awake()
    {

        //此脚本永不消毁，并且每次进入初始场景时进行判断，若存在重复的则销毁
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != _instance)
        {
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}