using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class GetJobs : MonoBehaviour
{

    public float timer;
    public float timerDuration;
    public JobList Jlist;
    public bool createJob;
    public bool doneCreatingJobs;
    public bool submittingIdea;
    public GameObject jobPrefab;
    public List<GameObject> allJobs;
    public Transform parent;
    public List<string> jobsAdded;

    // Start is called before the first frame update
    void Start()
    {
        jobsAdded.Clear();
        timer = 0;
        createJob = false;
        doneCreatingJobs = false;
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/listAllJobs"));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timerDuration && !submittingIdea)
        {
            //Debug.Log("Started Coroutine");

            createJob = true;
            doneCreatingJobs = false;
            StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/listAllJobs"));

            timer = 0;
        }

        if (createJob && !doneCreatingJobs)
        {
            //Debug.Log(Jlist.job.Count);
            for (int i = 0; i < Jlist.job.Count; i++)
            {
                if (jobsAdded.Contains(Jlist.job[i].jobID))
                {
                    //Debug.Log("Job Already Created");
                }
                else
                {
                    GameObject temp = Instantiate(jobPrefab, parent.transform);
                    allJobs.Add(temp);
                    JobComponents tempR = temp.GetComponent<JobComponents>();

                    tempR.jobID = Jlist.job[i].jobID;
                    tempR.title.text = Jlist.job[i].jobTitle;
                    tempR.department.text = Jlist.job[i].jobDepartment;
                    tempR.property.text = Jlist.job[i].jobProperty;

                    temp.transform.SetParent(parent);

                    jobsAdded.Add(Jlist.job[i].jobID);
                    SortChildren();
                }
            }

            createJob = false;
            doneCreatingJobs = true;
        }
    }
    public void SortChildren()
    {
        for (int i = 0; i < allJobs.Count; i++)
        {
            allJobs[i].transform.SetSiblingIndex(allJobs.Count - i);
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

            JobList data = JsonUtility.FromJson<JobList>(webRequest.downloadHandler.text);
            //Debug.Log(webRequest.downloadHandler.text);

            foreach (Job test in data.job)
            {
                //Debug.Log("Here Now");

                if (!jobsAdded.Contains(test.jobID))
                {
                    Jlist.job.Add(test);
                }
            }

            createJob = true;
        }
    }

    [System.Serializable]
    public class Job
    {
        public string jobTitle;
        public string jobDepartment;
        public string jobProperty;
        public string jobID;
    }

    [System.Serializable]
    public class JobList
    {
        public List<Job> job;
    }
}
