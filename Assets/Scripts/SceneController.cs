using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SceneBuilder sceneBuilder;
    [SerializeField] private List<JengaStack> stacks;
    [SerializeField] private int selectedStack;

    [SerializeField] private InfoPanel infoPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneBuilder.OnBuildStack += SceneBuilder_OnBuildStack;
        sceneBuilder.OnBuildLastStack += SceneBuilder_OnBuildLastStack;
    }

    private void SceneBuilder_OnBuildStack(JengaStack obj)
    {
        stacks.Add(obj);
    }
    
    private void SceneBuilder_OnBuildLastStack()
    {
        selectedStack = 0;
        FocusSelectedStack();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float horizontalMovement = Input.GetAxis("Mouse X");
            stacks[selectedStack].RotateCamera(horizontalMovement);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    var block = hit.collider.GetComponent<JengaBlock>();
                    var details = block.GetDetails();
                    infoPanel.SetValues(details);
                    infoPanel.gameObject.SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedStack = (selectedStack + 1) % stacks.Count;
            FocusSelectedStack();
        }
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedStack = (selectedStack - 1 + stacks.Count) % stacks.Count;
            FocusSelectedStack();
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            stacks[selectedStack].TestTheStack();
        }
    }

    private void FocusSelectedStack()
    {
        foreach (var stack in stacks)
        {
            if (stack == stacks[selectedStack])
            {
                stack.Focus();
            }
            else
            {
                stack.Unfocus();
            }
        }
    }
}
