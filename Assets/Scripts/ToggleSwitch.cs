using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class ToggleSwitch : MonoBehaviour
{
    //AddUser/:userID/:userName/:userGender/:userSeniority/:userHouse/:userLogin/:userPassword

    public InputField userNameIF;
    public InputField userLoginIF;
    public InputField userPasswordIF;

    public TMP_Dropdown genderDD;

    public int userGenderID;
    public int userID;
    public string userName;
    public string userGender;
    public string userSeniority;
    public string userHouse;
    public string userLogin;
    public string userPassword;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        userName = userNameIF.text;
        userLogin = userLoginIF.text;
        userPassword = userPasswordIF.text;
        userGenderID = genderDD.value;

        if (userGenderID == 0)
        {
            userGender = "Male";
        }
        else
        {
            userGender = "Female";
        }
    }

    public void ChangeHouse(string house)
    {
        userHouse = house;
    }

    public void RegisterUser()
    {
        //AddUser/:userID/:userName/:userGender/:userSeniority/:userHouse/:userLogin/:userPassword
        //https://testserversoubra.herokuapp.com/AddUser/2/ExampleName/Male/CEO/Green/ExampleLogin/E123
        Debug.Log("https://testserversoubra.herokuapp.com/AddUser/"
                + userID + "/" + userName + "/" + userGender + "/" + userSeniority + "/" + userHouse + "/" + userLogin + "/" + userPassword);

        StartCoroutine(GetRequest("https://testserversoubra.herokuapp.com/AddUser/"
            + userID +"/" + userName + "/" + userGender + "/" + userSeniority + "/" + userHouse + "/" + userLogin + "/" + userPassword ));
    }

    IEnumerator GetRequest(string uri)
    {
        Debug.Log("Coroutine Started");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
        }
    }
}
