using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class GetEvents : MonoBehaviour
{

    public float timer;
    public float timerDuration;
    public EventList eventList;
    public bool createEvent;
    public bool doneCreatingEvents;
    public bool submittingIdea;
    public bool start;
    public GameObject eventPrefab;
    public List<GameObject> allEvents;
    public Transform parent;
    public List<string> eventsAdded;
    public

    // Start is called before the first frame update
    void Start()
    {
        eventsAdded.Clear();
        timer = 0;
        createEvent = false;
        doneCreatingEvents = false;
        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/ListEvents"));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timerDuration && !submittingIdea)
        {
            //Debug.Log("Started Coroutine");

            createEvent = true;
            doneCreatingEvents = false;
            StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/ListEvents"));

            timer = 0;
        }

        if (createEvent && !doneCreatingEvents && start)
        {
            Debug.Log(eventList.events.Count);
            for (int i = 0; i < eventList.events.Count; i++)
            {
                if (eventsAdded.Contains(eventList.events[i].eventID))
                {
                    Debug.Log("Event Already Created");
                }
                else
                {
                    GameObject temp = Instantiate(eventPrefab, parent.transform);
                    allEvents.Add(temp);
                    EventComponents tempR = temp.GetComponent<EventComponents>();

                    tempR.ID = eventList.events[i].eventID;
                    tempR.title.text = eventList.events[i].eventName;
                    tempR.description.text = eventList.events[i].eventDescription;
                    tempR.votedFor = eventList.events[i].numberVotedForString;
                    tempR.votedAgainst = eventList.events[i].numberVotedAgainstString;
                    tempR.totalVoted = eventList.events[i].totalNumberVotedString;

                    temp.transform.SetParent(parent);

                    eventsAdded.Add(eventList.events[i].eventID);
                    SortChildren();
                }
            }

            createEvent = false;
            doneCreatingEvents = true;
        }
    }
    public void SortChildren()
    {
        for (int i = 0; i < allEvents.Count; i++)
        {
            allEvents[i].transform.SetSiblingIndex(allEvents.Count - i);
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

            EventList data = JsonUtility.FromJson<EventList>(webRequest.downloadHandler.text);
            Debug.Log("THIS IS THE EVENTS: " + webRequest.downloadHandler.text);

            foreach (Event test in data.events)
            {
                //Debug.Log("Here Now");

                if (!eventsAdded.Contains(test.eventID))
                {
                    eventList.events.Add(test);
                }
            }

            createEvent = true;
        }
    }

    [System.Serializable]
    public class Event
    {
        public string eventName;
        public string eventDescription;
        public string totalNumberVotedString;
        public string numberVotedAgainstString;
        public string numberVotedForString;
        public string eventID;
    }

    [System.Serializable]
    public class EventList
    {
        public List<Event> events;
    }
}
