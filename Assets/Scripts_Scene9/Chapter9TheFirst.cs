using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter9TheFirst : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        hasArrange = false;
    }

    public bool hasArrange;

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 1 == 0)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                if (this.transform.GetChild(i).name == (i+1).ToString()) continue;
                else
                {
                    hasArrange = false; return;
                }
            }
            hasArrange = true;
        }
    }
}
