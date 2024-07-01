using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    [SerializeField]
    private Transform EndPoint;

    [SerializeField]
    private Collider colliderPlatform;

    public float speed;
    private float startTime;
    private float journeyLength;
    private Vector3 distanceCollider;

    [SerializeField]
    public bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        colliderPlatform = GetComponent<Collider>();
        journeyLength = Vector3.Distance(transform.position, EndPoint.position);
        distanceCollider = new Vector3(0, colliderPlatform.bounds.size.y / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove && transform.position != EndPoint.position)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, EndPoint.position - distanceCollider, fractionOfJourney);
        }
    }

    public void MovePlatform()
    {
        if (!canMove)
            canMove = true;
    }

    public bool getStateMovePlatform()
    {
        return canMove;
    }

}
