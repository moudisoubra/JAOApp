using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyAsteroid : MonoBehaviour
{
    public GameObject parent;
    public Vector3 position;
    public float speed;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        position = parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = transform.position + position * speed;
        transform.position = Vector2.MoveTowards(transform.position, position, -1 * speed);
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(this.gameObject);
        }
    }
}
