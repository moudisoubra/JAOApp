using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyDestroyer : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject bigPlatformPrefab;
    public GameObject myPlat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Killer"))
        {
            
        }
        else
        {
            if (Random.Range(0, 6) > 0)
            {
                myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(player.transform.position.x + Random.Range(-4.5f, 4.5f), player.transform.position.y + (6 + Random.Range(0.25f, 0.5f))), Quaternion.identity);
            }
            else
            {
                myPlat = (GameObject)Instantiate(bigPlatformPrefab, new Vector2(player.transform.position.x + Random.Range(-4.5f, 4.5f), player.transform.position.y + (6 + Random.Range(0.25f, 0.5f))), Quaternion.identity);
            }
            Destroy(collision.gameObject);
        } 
    }
}
