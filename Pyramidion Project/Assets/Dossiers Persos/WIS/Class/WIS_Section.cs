using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Section", menuName = "Section")]
public class WIS_Section : ScriptableObject
{

    public string sectionName;

    public string introductionMonologue;

    public string wrongMonologue;

    public WIS_EndSection[] endSections;


}
