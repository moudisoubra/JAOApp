using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class GetBlogs : MonoBehaviour
{
    public float timer;
    public float timerDuration;
    public BlogList blogList;
    public bool createBlogs;
    public bool doneCreatingBlogs;
    public bool submittingIdea;
    public GameObject blogPrefab;
    public GameObject submissionPanel;
    public Transform parent;
    public List<string> blogsAdded;

    // Start is called before the first frame update
    void Start()
    {
        blogsAdded.Clear();
        timer = 0;
        createBlogs = false;
        doneCreatingBlogs = false;
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/listAllBlogPosts"));
    }

    // Update is called once per frame
    void Update()
    {
        if(submissionPanel.activeSelf)
        {
          submittingIdea = true;
        }
        else
        {
            submittingIdea = false;
        }

        timer += Time.deltaTime;

        if (timer > timerDuration && !submittingIdea)
        {
            Debug.Log("Started Coroutine");

            createBlogs = true;
            doneCreatingBlogs = false;
            StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/listAllBlogPosts"));

            timer = 0;
        }

        if (createBlogs && !doneCreatingBlogs)
        {
            Debug.Log(blogList.blog.Count);
            for (int i = 0; i < blogList.blog.Count; i++)
            {
                if (blogsAdded.Contains(blogList.blog[i].blogID))
                {
                    Debug.Log("Blog Already Created");
                }
                else
                {
                    GameObject temp = Instantiate(blogPrefab, parent.transform);
                    temp.GetComponent<TextBoxComponents>().blogName.text = blogList.blog[i].userName;
                    temp.GetComponent<TextBoxComponents>().blogContent.text = blogList.blog[i].blogContent;
                    temp.transform.SetParent(parent);
                    blogsAdded.Add(blogList.blog[i].blogID);
                }
            }

            createBlogs = false;
            doneCreatingBlogs = true;
        }
    }

    IEnumerator GetRequest(string uri)
    {
        Debug.Log("Coroutine Started");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            Debug.Log("Here");
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            BlogList data = JsonUtility.FromJson<BlogList>(webRequest.downloadHandler.text);
            Debug.Log(webRequest.downloadHandler.text);

            foreach (blog test in data.blog)
            {
                Debug.Log("Here Now");

                print("Blog User ID: " + test.userID +
                      "Blog Made By: " + test.userName +
                      "Blog Content: " + test.blogContent +
                      "Blog Unique ID: " + test.blogID);
            
                if (!blogsAdded.Contains(test.blogID))
                {   
                    blogList.blog.Add(test);
                }
            }

            createBlogs = true;
        }
    }

    [System.Serializable]
    public class blog
    {
        public string userID;
        public string userName;
        public string blogContent;
        public string blogID;
    }

    [System.Serializable]
    public class BlogList
    {
        public List<blog> blog;
    }
}
