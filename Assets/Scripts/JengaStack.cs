using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;

public class JengaStack : MonoBehaviour
{
    [SerializeField] private TextMeshPro label;
    private List<StackData> datas = new ();
    private int currentData;
    private Transform stackTransform;
    [SerializeField]private JengaBlock blockPrefab;

    private Vector3 nextPiecePosition = new Vector3(-1, 0.5f, 0);
    
    [SerializeField] private Material[] piecesMaterials;

    public void Setup(string grade)
    {
        name = "Stack " + grade;
        label.text = grade;
        stackTransform = transform;
    }

    public void AddBlock(StackData data)
    {
        datas.Add(data);
    }

    public void BuildStack()
    {
        datas.Sort();
        
        int rowsCount = datas.Count / 3;
        int blocksLeft = datas.Count % 3;

        for (int i = 0; i < rowsCount; i++)
        {
            if (i % 2 == 0)
            {
                BuildEvenRow(i == 0);
            }
            else
            {
                BuildOddRow();
            }
        }

        if (blocksLeft > 0)
        {
            if (rowsCount % 2 == 0)
            {
                BuildEvenRow(false, blocksLeft);
            }
            else
            {
                BuildOddRow(blocksLeft);
            }
        }
    }

    private void BuildEvenRow(bool isFirstRow, int numberOfBlocks = 3)
    {
        int currentBlock = 0;
        var pieceRotation = Quaternion.Euler(0, 0, 0);
        nextPiecePosition.x = -1;
        
        if(!isFirstRow) nextPiecePosition.y += 1;
        
        nextPiecePosition.z = 0;

        for (int i = 0; i < numberOfBlocks; i++)
        {
            SpawnPiece(pieceRotation);
            nextPiecePosition.x += 1;
        }
    }

    

    private void BuildOddRow(int numberOfBlocks = 3)
    {
        int currentBlock = 0;
        var pieceRotation = Quaternion.Euler(0, 90, 0);
        nextPiecePosition.x = 0;
        nextPiecePosition.y += 1;
        nextPiecePosition.z = -1;

        for (int i = 0; i < numberOfBlocks; i++)
        {
            SpawnPiece(pieceRotation);
            nextPiecePosition.z += 1;
        }
    }
    
    private void SpawnPiece(Quaternion pieceRotation)
    {
        var block = Instantiate(blockPrefab, nextPiecePosition, pieceRotation, stackTransform);
        block.transform.SetLocalPositionAndRotation(nextPiecePosition, pieceRotation);
        block.Setup(datas[currentData]);
        block.SetMaterial(piecesMaterials);
        currentData++;
    }
}