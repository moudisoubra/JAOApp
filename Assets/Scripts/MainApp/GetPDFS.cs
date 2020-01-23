using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class GetPDFS : MonoBehaviour
{

    public float timer;
    public float timerDuration;
    public PDFList pdfList;
    public bool createBooks;
    public bool doneCreatingBooks;
    public GameObject bookPrefab;
    public Transform scrollRect;

    public List<string> pdfNames;

    // Start is called before the first frame update
    void Start()
    {
        pdfNames.Clear();
        timer = 0;
        createBooks = false;
        doneCreatingBooks = false;
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/listAllPDFs"));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timerDuration)
        {
            Debug.Log("Started Coroutine");

            createBooks = false;
            doneCreatingBooks = false;
            StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/listAllPDFs"));

            timer = 0;
        }

        if (createBooks && !doneCreatingBooks)
        {
            Debug.Log(pdfList.pdf.Count);
            for (int i = 0; i < pdfList.pdf.Count; i++)
            {
                if (pdfNames.Contains(pdfList.pdf[i].pdfName))
                {
                    Debug.Log("PDF Already Created");
                }
                else
                {
                    GameObject temp = Instantiate(bookPrefab, scrollRect.transform);
                    temp.GetComponentInChildren<TextMeshProUGUI>().text = pdfList.pdf[i].pdfName;
                    temp.GetComponentInChildren<BrowserOpener>().pageToOpen = "https://testserversoubra.herokuapp.com/showPic/" + pdfList.pdf[i].pdfName;
                    Debug.Log("https://testserversoubra.herokuapp.com/showPic/" + pdfList.pdf[i].pdfName);
                    temp.transform.parent = scrollRect;
                    pdfNames.Add(pdfList.pdf[i].pdfName);
                }

            }

            createBooks = false;
            doneCreatingBooks = true;
        }
    }

    IEnumerator GetRequest(string uri)
    {
        Debug.Log("Coroutine Started");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            PDFList data = JsonUtility.FromJson<PDFList>(webRequest.downloadHandler.text);

            foreach (PDF test in data.pdf)
            {
                print("PDF Name: " + test.pdfName +
                "PDF FullName: " + test.pdfFullName);
            
                if (pdfNames.Contains(test.pdfName))
                {
                    Debug.Log("PDF Already Created");
                }
                else
                {
                    pdfList.pdf.Add(test);
                }
            }

            createBooks = true;
        }
    }

    [System.Serializable]
    public class PDF
    {
        public string pdfName;
        public string pdfFullName;
    }

        [System.Serializable]
    public class PDFList
    {
        public List<PDF> pdf;
    }
}
