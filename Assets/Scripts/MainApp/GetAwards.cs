using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;
public class GetAwards : MonoBehaviour
{

    public float timer;
    public float timerDuration;
    public AwardList AList;
    public bool createRecruits;
    public bool doneCreatingRecruits;
    public bool submittingIdea;
    public GameObject recruitPrefab;
    public List<GameObject> allRecruits;
    public Transform parent;
    public List<string> awardsAdded;
    public

    // Start is called before the first frame update
    void Start()
    {
        awardsAdded.Clear();
        timer = 0;
        createRecruits = false;
        doneCreatingRecruits = false;
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/listAllAwardPosts"));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timerDuration && !submittingIdea)
        {
            //Debug.Log("Started Coroutine");

            createRecruits = true;
            doneCreatingRecruits = false;
            StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/listAllAwardPosts"));

            timer = 0;
        }

        if (createRecruits && !doneCreatingRecruits)
        {
            //Debug.Log(AList.award.Count);
            for (int i = 0; i < AList.award.Count; i++)
            {
                if (awardsAdded.Contains(AList.award[i].userID))
                {
                    //Debug.Log("Recruit Already Created");
                }
                else
                {
                    GameObject temp = Instantiate(recruitPrefab, parent.transform);
                    allRecruits.Add(temp);
                    AwardComponents tempR = temp.GetComponent<AwardComponents>();

                    tempR.ID = AList.award[i].userID;
                    tempR.awardContent.text = AList.award[i].awardContent;


                    temp.transform.SetParent(parent);

                    awardsAdded.Add(AList.award[i].userID);
                    SortChildren();
                }
            }

            createRecruits = false;
            doneCreatingRecruits = true;
        }
    }
    public void SortChildren()
    {
        for (int i = 0; i < allRecruits.Count; i++)
        {
            allRecruits[i].transform.SetSiblingIndex(allRecruits.Count - i);
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

            AwardList data = JsonUtility.FromJson<AwardList>(webRequest.downloadHandler.text);
            //Debug.Log(webRequest.downloadHandler.text);

            foreach (Award test in data.award)
            {
                //Debug.Log("Here Now");

                if (!awardsAdded.Contains(test.awardID))
                {
                    AList.award.Add(test);
                }
            }

            createRecruits = true;
        }
    }

    [System.Serializable]
    public class Award
    {
        public string userID;
        public string awardContent;
        public string awardID;
    }

    [System.Serializable]
    public class AwardList
    {
        public List<Award> award;
    }
}
