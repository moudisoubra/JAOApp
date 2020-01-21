using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignTeam : MonoBehaviour
{
    public Team[] teams;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void AddMember( )
    {

    }

    public Team CheckGender()
    {
        Team tempTeam = null;
        for (int i = 0; i < teams.Length; i++)
        {
            if (tempTeam = null)
            {
                tempTeam = teams[i];
            }
            else if(teams[i].totalMembers < tempTeam.totalMembers)
            {
                tempTeam = teams[i];
            }
        }

        return tempTeam;
    }

    public void CheckOccupation(Member member)
    {
        Team lowestFemaleCount = null;
        Team lowestMaleCount = null;
        Team lowestNumberofOccupation = null;
        Occupation tempOccupation = member.occupation;
        List<Team> allTeamsApplied = null;

        for (int i = 0; i < teams.Length; i++)
        {
            if (teams[i].numberOfFemales > teams[i + 1].numberOfFemales)
            {
                lowestFemaleCount = teams[i + 1];
            }

            if (teams[i].numberOfMales > teams[i + 1].numberOfMales)
            {
                lowestMaleCount = teams[i + 1];
            }
        }
    }
}
