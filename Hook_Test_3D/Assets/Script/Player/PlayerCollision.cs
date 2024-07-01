using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
            spawn = other.gameObject;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Lava") && spawn != null)
        {
            transform.position = spawn.transform.position;
        }

        if (hit.gameObject.CompareTag("Platform"))
        {
            hit.gameObject.GetComponent<MovablePlatform>().MovePlatform();
        }

    }
}
