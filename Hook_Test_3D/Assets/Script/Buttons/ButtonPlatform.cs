using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platform;

    [SerializeField]
    public MovablePlatform[] platform_script;

    // Start is called before the first frame update
    void Start()
    {
        platform_script = new MovablePlatform[platform.Length];

        for(int i = 0; i < platform.Length; ++i)
        {
            platform_script[i] = platform[i].GetComponent<MovablePlatform>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBoolPlatform()
    {
        for(int i = 0; i < platform.Length; ++i)
        {
            platform_script[i].MovePlatform();
        }
    }
}
