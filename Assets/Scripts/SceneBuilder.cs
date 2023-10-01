using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBuilder : MonoBehaviour
{
    private Dictionary<string, JengaStack> stacks = new Dictionary<string, JengaStack>();
    private int currentStack;
    [SerializeField] private JengaStack stackPrefab;
    private Vector3 lastStackPosition = new ();

    [SerializeField]private StacksRequester requester;
    
    public event Action<JengaStack> OnBuildStack; 
    public event Action OnBuildLastStack; 

    private void Start()
    {
        requester.OnStacksReceived += Requester_OnStacksReceived;
    }

    private void Requester_OnStacksReceived(StackData[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            AddBlockToCorrespondentStack(obj[i].grade, obj[i]);
        }

        foreach (var stack in stacks)
        {
            stack.Value.BuildStack();
            OnBuildStack?.Invoke(stack.Value);
        }
        
        OnBuildLastStack?.Invoke();
    }

    public void AddBlockToCorrespondentStack(string grade, StackData data)
    {
        if (!stacks.ContainsKey(grade))
        {
            JengaStack stack = Instantiate(stackPrefab, lastStackPosition, Quaternion.identity);
            stack.Setup(grade);
            lastStackPosition.x += 12;
            stacks.Add(grade, stack);
        }

        stacks[grade].AddBlock(data);
    }
}