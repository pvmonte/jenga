using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StackData : IComparable
{
    public int id;
    public string subject;
    public string grade;
    public int mastery;
    public string domainid;
    public string domain;
    public string cluster;
    public string standardid;
    public string standarddescription;
    
    public int CompareTo(object obj)
    {
        throw new NotImplementedException();
    }
}

[Serializable]
public class StackResponse
{
    public StackData[] data;
}