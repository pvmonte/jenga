using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;

public class JengaStack : MonoBehaviour
{
    public JengaBlock blockPrefab;

    [FormerlySerializedAs("startPosition")]
    public Vector3 stackPosition;

    public float blockSpacing;

    private int blockCount;

    private Vector3 nextPiecePosition = new Vector3(-1, 0.5f, 0);
    private int currentRow = 0;
    private Vector3[] evenRowBlockPositions;
    private Vector3[] oddRowBlockPositions;

    private void Start()
    {
        blockCount = 10; // Set the desired number of blocks in the stack

        BuildStack();
    }

    private void BuildStack()
    {
        int rowsCount = blockCount / 3;
        int blocksLeft = blockCount % 3;

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
            var block = Instantiate(blockPrefab, nextPiecePosition, pieceRotation, transform);
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
            var block = Instantiate(blockPrefab, nextPiecePosition, pieceRotation, transform);

            nextPiecePosition.z += 1;
        }

        
    }

    private void PlaceLeftingBlocks()
    {
        
    }
}