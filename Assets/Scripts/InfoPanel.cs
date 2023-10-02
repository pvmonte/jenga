using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI domainText;
    [SerializeField] private TextMeshProUGUI clusterText;
    [SerializeField] private TextMeshProUGUI standardIdText;

    public void SetValues(StackData data)
    {
        domainText.text = string.Format("{0}: {1}", data.grade, data.domain);
        clusterText.text = string.Format("{0}", data.cluster);
        standardIdText.text = string.Format("{0}: {1}", data.standardid, data.standarddescription);
    }
}
