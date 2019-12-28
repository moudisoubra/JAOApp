using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertical : MonoBehaviour
{
    public bool move;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObjectDestroyer"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject)
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}
