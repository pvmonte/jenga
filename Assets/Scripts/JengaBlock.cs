using System;
using TMPro;
using UnityEngine;

public enum Mastery
{
    Glass = 0,
    Wood = 1,
    Stone = 2
}

public class JengaBlock : MonoBehaviour
{
    private Mastery mastery;
    [SerializeField] private Renderer meshRenderer;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private TextMeshPro[] masteryTexts;

    public void Setup(StackData data)
    {
        mastery = (Mastery)data.mastery;
    }

    public void SetMaterial(Material[] piecesMaterials)
    {
        meshRenderer.material = piecesMaterials[(int)mastery];
    }

    public Mastery StartStackTestAndReturnMastery()
    {
        rb.isKinematic = false;
        return mastery;
    }

    private void OnMouseUpAsButton()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Right-clicked! " + mastery);
        }
    }
}