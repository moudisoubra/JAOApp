using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Vector3 cameraVector;
    public GameObject currentCube;
    public GameObject lastCube;
    public GameObject endText;
    public GameObject tapp;
    public Text score;
    public int level;
    public bool done;
    public Swipe swipe;
    public Material newMaterial;
    public Material oldMaterial;
    // Start is called before the first frame update
    void Start()
    {
        NewBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            return;
        }

        var time = Mathf.Abs(Time.realtimeSinceStartup % 2f - 1f);

        var pos1 = lastCube.transform.position + Vector3.up * 10f;
        var pos2 = pos1 + ((level % 2 == 0) ? Vector3.left : Vector3.forward) * 120;

        if (level % 2 == 0)
        {
            currentCube.transform.position = Vector3.Lerp(pos2, pos1, time);
        }
        else
        {
            currentCube.transform.position = Vector3.Lerp(pos1, pos2, time);
        }

        if (swipe.Tap)
        {
            // score.text = level.ToString("0");
            // currentCube.GetComponent<MeshRenderer>().material = oldMaterial;
            // NewBlock();
        }
    }

    public void Tappity()
    {
            score.text = level.ToString("0");
            currentCube.GetComponent<MeshRenderer>().material = oldMaterial;
            NewBlock();
    }

    public void NewBlock()
    {
        if (lastCube != null)
        {
            currentCube.transform.position = new Vector3(Mathf.Round(currentCube.transform.position.x),
                currentCube.transform.position.y,
                 Mathf.Round(currentCube.transform.position.z));
            currentCube.transform.localScale = new Vector3(lastCube.transform.localScale.x - Mathf.Abs(currentCube.transform.position.x - lastCube.transform.position.x),
                lastCube.transform.localScale.y,
                lastCube.transform.localScale.z - Mathf.Abs(currentCube.transform.position.z - lastCube.transform.position.z));

            currentCube.transform.position = Vector3.Lerp(currentCube.transform.position, lastCube.transform.position, 0.5f) + Vector3.up * 5f;

            if (currentCube.transform.localScale.x <= 0f || currentCube.transform.localScale.z <= 0f)
            {
                done = true;
                endText.gameObject.SetActive(true);
                endText.GetComponentInChildren<Text>().text = "Your Score: " + level;
                tapp.SetActive(false);
            }
           

        }
        lastCube = currentCube;
        currentCube = Instantiate(lastCube);
        currentCube.name = level + "";
        currentCube.GetComponent<MeshRenderer>().material = newMaterial;
        level++;
        Camera.main.transform.position = currentCube.transform.position + cameraVector;
        Camera.main.transform.LookAt(currentCube.transform.position);
    }
}
