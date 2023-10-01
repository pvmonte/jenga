using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Plastic.Newtonsoft.Json;

public class StacksRequester : MonoBehaviour
{
    public event Action<StackData[]> OnStacksReceived;
    
    private void Start()
    {
        StartCoroutine(RequestStacks());
    }

    private IEnumerator RequestStacks()
    {
        
        
        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack"))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    var json = webRequest.downloadHandler.text;
                    var response = JsonConvert.DeserializeObject<StackData[]>(json);
                    OnStacksReceived?.Invoke(response);
                    break;
            }
        }
    }
    
    
}