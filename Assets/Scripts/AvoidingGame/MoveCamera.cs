using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public bool Go;
    public Transform cameraP;
    public float speed;
    public float distance;
    public float tempDistance;

    public GameObject wall;
    public GameObject position;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(wall.transform.position, position.transform.position));
        tempDistance = Vector3.Distance(wall.transform.position, position.transform.position);
        if (Go)
        {
            transform.position = Vector3.Lerp(transform.position, cameraP.position, speed);

            if (Vector3.Distance(wall.transform.position, position.transform.position) < distance)
            {
                wall.SetActive(false);
                go.SetActive(false);
            }
        }
    }
}
