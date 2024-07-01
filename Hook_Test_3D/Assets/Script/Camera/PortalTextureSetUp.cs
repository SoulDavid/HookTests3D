using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetUp : MonoBehaviour
{
    [SerializeField]
    private Camera cameraA;
    [SerializeField]
    private Camera cameraB;

    [SerializeField]
    private Material cameraMatA;
    [SerializeField]
    private Material cameraMatB;

    // Start is called before the first frame update
    void Start()
    {
        #region Camera A
        if (cameraA.targetTexture != null)
            cameraA.targetTexture.Release();

        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatA.mainTexture = cameraA.targetTexture;
        #endregion

        #region Camera B
        if (cameraB.targetTexture != null)
            cameraB.targetTexture.Release();

        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = cameraB.targetTexture;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
