using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InheritedTeam : Team
{
    public TextMeshProUGUI totalCount;
    public TextMeshProUGUI maleCount;
    public TextMeshProUGUI femaleCount;
    public TextMeshProUGUI oA;
    public TextMeshProUGUI oB;
    public TextMeshProUGUI oC;
    public TextMeshProUGUI oD;

    void Update()
    {
        totalCount.text = totalMembers.ToString();
        maleCount.text = numberOfMales.ToString();
        femaleCount.text = numberOfFemales.ToString();
        oA.text = numberOccupationA.ToString();
        oB.text = numberOccupationB.ToString();
        oC.text = numberOccupationC.ToString();
        oD.text = numberOccupationD.ToString();
    }
}
