using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBezierCurve : MonoBehaviour
{
    [SerializeField]
    public Transform[] routes;
    public int routeToGo;
    public float tParam;
    public Vector2 position;
    public float speed;
    public bool coroutineAllowed;
    public bool playerFollow;
    public Transform endPosition;

    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(FollowRoute(routeToGo));
        }
    }

    private IEnumerator FollowRoute(int routeNumber)
    {
        coroutineAllowed = true;

        Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speed;

            position = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

            transform.position = position;
            playerFollow = true;
            yield return new WaitForEndOfFrame();
        }

        playerFollow = false;
    }


}
