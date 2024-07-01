using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HookScript : MonoBehaviour
{
    public string[] tagsToCheck;
    public float speed, returnSpeed, range, stopRange;

    //[HideInInspector]
    public Transform caster, collidedWith;
    [SerializeField]
    private LineRenderer line;
    private bool hasCollided;

    // Start is called before the first frame update
    void Start()
    {
        line = transform.GetChild(1).GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(caster)
        {
            line.SetPosition(0, caster.position);
            line.SetPosition(1, transform.position);

            if(hasCollided)
            {
                transform.LookAt(caster);  

                var dist = Vector3.Distance(transform.position, caster.position);

                if (dist < stopRange)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                var dist = Vector3.Distance(transform.position, caster.position);
                if (dist > range)
                {
                    Collision(null, tagsToCheck.Length+1);
                }
            }

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (collidedWith)
                collidedWith.transform.position = transform.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!hasCollided && tagsToCheck.Contains(other.tag))
        {
            int pos = System.Array.IndexOf(tagsToCheck, other.tag);
            Debug.Log("Posición del array: " + pos);
            Collision(other.gameObject, pos);
        }
    }

    void Collision(GameObject col, int item)
    {
        speed = returnSpeed;
        hasCollided = true;

        if(col)
        {
            switch(item)
            {
                case 0:
                    transform.position = col.transform.position;
                    collidedWith = col.transform;
                    break;

                case 1:
                    col.gameObject.GetComponent<ButtonPlatform>().SetBoolPlatform();
                    break;

            }
        }
    }
}
