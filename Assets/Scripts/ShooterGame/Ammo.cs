using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Asteroid>())
        {
            other.GetComponent<Asteroid>().life -= 1;
            Destroy(this.gameObject);
        }
        if (other.CompareTag("ObjectDestroyer"))
        {
            Destroy(this.gameObject);
        }
    }
}
