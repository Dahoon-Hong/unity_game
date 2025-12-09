using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.EventSystems;

[System.Serializable]
public class CardEffect
{
    public string target_stat;
    public string operator_type;
    public float base_value;
    public float value_per_level;
}

[System.Serializable]
public class CardData
{
    public string id;
    public string category;
    public string text_key;
    public string grade;
    public string icon_path;
    public int max_level;
    public List<CardEffect> effects;
}


