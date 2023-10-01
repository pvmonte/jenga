using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StackData
{
    public int id { get; set; }
    public string subject { get; set; }
    public string grade { get; set; }
    public int mastery { get; set; }
    public string domainid { get; set; }
    public string domain { get; set; }
    public string cluster { get; set; }
    public string standardid { get; set; }
    public string standarddescription { get; set; }
}

[Serializable]
public class StackResponse
{
    public List<StackData> data { get; set; }
}
