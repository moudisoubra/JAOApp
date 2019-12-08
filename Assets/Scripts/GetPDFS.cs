using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class GetPDFS : MonoBehaviour
{

    public PDFList pdfList;
    public bool createBooks;
    public bool doneCreatingBooks;
    public GameObject bookPrefab;
    public Transform scrollRect;

    // Start is called before the first frame update
    void Start()
    {
        createBooks = false;
        doneCreatingBooks = false;
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/listAllPDFs"));
    }

    // Update is called once per frame
    void Update()
    {
        if (createBooks && !doneCreatingBooks)
        {
            Debug.Log(pdfList.pdf.Count);
            for (int i = 0; i < pdfList.pdf.Count; i++)
            {
                GameObject temp = Instantiate(bookPrefab, scrollRect.transform);
                temp.GetComponentInChildren<TextMeshProUGUI>().text = pdfList.pdf[i].pdfName;
                temp.transform.parent = scrollRect;
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
            

                pdfList.pdf.Add(test);
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
