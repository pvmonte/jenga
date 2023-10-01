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
}