using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashScreen : MonoBehaviour
{
    public static int sceneNumber;
    public int waitingNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (sceneNumber == 0)
        {
            StartCoroutine(ToMainMenu());
        }
    }

    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(waitingNumber);
        Debug.Log("Coroutine Started");
        sceneNumber = 1;
        SceneManager.LoadScene(1);
    }
}
