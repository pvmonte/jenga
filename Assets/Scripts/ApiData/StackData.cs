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
        if (obj == null) return 1;

        StackData otherStackData = obj as StackData;
        if (otherStackData != null)
        {
            int domainComparison = string.Compare(this.domain, otherStackData.domain, StringComparison.Ordinal);
            if (domainComparison != 0)
                return domainComparison;
         
            int clusterComparison = string.Compare(this.cluster, otherStackData.cluster, StringComparison.Ordinal);
            if (clusterComparison != 0)
                return clusterComparison;

            return string.Compare(this.standardid, otherStackData.standardid, StringComparison.Ordinal);
        }
        else
        {
            throw new ArgumentException("Object is not a StackData");
        }
    }
}

[Serializable]
public class StackResponse
{
    public StackData[] data;
}