using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class GetRecruits : MonoBehaviour
{

    public float timer;
    public float timerDuration;
    public RecruitList Rlist;
    public bool createRecruits;
    public bool doneCreatingRecruits;
    public bool submittingIdea;
    public GameObject recruitPrefab;
    public GameObject submissionPanel;
    public Transform parent;
    public List<string> recruitsAdded;

    // Start is called before the first frame update
    void Start()
    {
        recruitsAdded.Clear();
        timer = 0;
        createRecruits = false;
        doneCreatingRecruits = false;
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/listAllRecruits"));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timerDuration && !submittingIdea)
        {
            Debug.Log("Started Coroutine");

            createRecruits = true;
            doneCreatingRecruits = false;
            StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/listAllBlogPosts"));

            timer = 0;
        }

        if (createRecruits && !doneCreatingRecruits)
        {
            Debug.Log(Rlist.recruit.Count);
            for (int i = 0; i < Rlist.recruit.Count; i++)
            {
                if (recruitsAdded.Contains(Rlist.recruit[i].recruit_ID))
                {
                    Debug.Log("Recruit Already Created");
                }
                else
                {
                    GameObject temp = Instantiate(recruitPrefab, parent.transform);
                    RecruitComponents tempR = temp.GetComponent<RecruitComponents>();

                    tempR.name.text = Rlist.recruit[i].recruit_Name;
                    tempR.nationality.text = Rlist.recruit[i].recruit_Nationality;
                    tempR.property.text = Rlist.recruit[i].recruit_Property;
                    tempR.department.text = Rlist.recruit[i].recruit_Department;
                    tempR.position.text = Rlist.recruit[i].recruit_Position;
                    tempR.doj.text = Rlist.recruit[i].recruit_DOJ;
                    
                    temp.transform.SetParent(parent);

                    recruitsAdded.Add(Rlist.recruit[i].recruit_ID);
                }
            }

            createRecruits = false;
            doneCreatingRecruits = true;
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

            RecruitList data = JsonUtility.FromJson<RecruitList>(webRequest.downloadHandler.text);
            Debug.Log(webRequest.downloadHandler.text);

            foreach (Recruit test in data.recruit)
            {
                Debug.Log("Here Now");

                if (!recruitsAdded.Contains(test.recruit_ID))
                {
                    Rlist.recruit.Add(test);
                }
            }

            createRecruits = true;
        }
    }

    [System.Serializable]
    public class Recruit
    {
        public string recruit_ID;
        public string recruit_Name;
        public string recruit_Nationality;
        public string recruit_Department;
        public string recruit_Position;
        public string recruit_DOJ;
        public string recruit_Property;
    }

    [System.Serializable]
    public class RecruitList
    {
        public List<Recruit> recruit;
    }
}
