using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Section", menuName = "Section")]
public class WIS_Section : ScriptableObject
{

    public string sectionName;

    public STG_Sound introductionMonologue;

    public STG_Sound wrongMonologue;

    public STG_Sound ambiantMusic;

    public WIS_EndSection[] endSections;

    public WIS_AnimationManager.form form;
}
