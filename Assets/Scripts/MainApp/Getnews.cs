using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class Getnews : MonoBehaviour
{

    public float timer;
    public float timerDuration;
    public NewsList newsList;
    public bool createNews;
    public bool doneCreatingEvents;
    public bool submittingIdea;
    public bool start;
    public GameObject newsPrefab;
    public List<GameObject> allNews;
    public Transform parent;
    public List<string> newsAdded;
    public

    // Start is called before the first frame update
    void Start()
    {
        newsAdded.Clear();
        timer = 0;
        createNews = false;
        doneCreatingEvents = false;
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/ListAllNews"));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timerDuration && !submittingIdea)
        {
            //Debug.Log("Started Coroutine");

            createNews = true;
            doneCreatingEvents = false;
            StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/ListAllNews"));

            timer = 0;
        }

        if (createNews && !doneCreatingEvents && start)
        {
            Debug.Log(newsList.news.Count);
            for (int i = 0; i < newsList.news.Count; i++)
            {
                if (newsAdded.Contains(newsList.news[i].newsID))
                {
                    Debug.Log("Event Already Created");
                }
                else
                {
                    GameObject temp = Instantiate(newsPrefab, parent.transform);
                    allNews.Add(temp);
                    NewsComponents tempR = temp.GetComponent<NewsComponents>();

                    tempR.ID = newsList.news[i].newsID;
                    tempR.Title.text = newsList.news[i].newsTitle;
                    tempR.Content.text = newsList.news[i].newsContent;

                    temp.transform.SetParent(parent);

                    newsAdded.Add(newsList.news[i].newsID);
                    SortChildren();
                }
            }

            createNews = false;
            doneCreatingEvents = true;
        }
    }
    public void SortChildren()
    {
        for (int i = 0; i < allNews.Count; i++)
        {
            allNews[i].transform.SetSiblingIndex(allNews.Count - i);
        }
    }
    IEnumerator GetRequest(string uri)
    {
        //Debug.Log("Coroutine Started");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            //Debug.Log("Here");
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            NewsList data = JsonUtility.FromJson<NewsList>(webRequest.downloadHandler.text);
            Debug.Log("THIS IS THE NEWS: " + webRequest.downloadHandler.text);

            foreach (News test in data.news)
            {
                //Debug.Log("Here Now");

                if (!newsAdded.Contains(test.newsID))
                {
                    Debug.Log("Create News");
                    newsList.news.Add(test);
                }
                else
                {
                    Debug.Log("DONT CREATE NEWS");
                }
            }

            createNews = true;
        }
    }

    [System.Serializable]
    public class News
    {
        public string newsTitle;
        public string newsContent;
        public string newsID;
    }

    [System.Serializable]
    public class NewsList
    {
        public List<News> news;
    }
}
