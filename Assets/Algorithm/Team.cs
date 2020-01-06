using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public int totalMembers;
    public int numberOfMales;
    public int numberOfFemales;

    public Gender male;
    public Gender female;

    public Occupation A;
    public Occupation B;
    public Occupation C;
    public Occupation D;

    public OccupationNumber numberOfA;
    public OccupationNumber numberOfB;
    public OccupationNumber numberOfC;
    public OccupationNumber numberOfD;

    public List<Occupation> allOccupations;
    public List<OccupationNumber> allOccupationsNumbers;

    public List<Member> allMembers;

    private void Start()
    {
        male.gender = 0;
        female.gender = 1;

        A.name = "A";
        B.name = "B";
        C.name = "C";
        D.name = "D";

        numberOfA.name = "A";
        numberOfB.name = "A";
        numberOfC.name = "A";
        numberOfD.name = "A";

        allOccupations.Add(A);
        allOccupations.Add(B);
        allOccupations.Add(C);
        allOccupations.Add(D);

        allOccupationsNumbers.Add(numberOfA);
        allOccupationsNumbers.Add(numberOfB);
        allOccupationsNumbers.Add(numberOfC);
        allOccupationsNumbers.Add(numberOfD);
    }
}
