using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager instance;
    
    [Header("Elements")] 
    [SerializeField] private Chunk[] chunkPrefabs;
    [SerializeField] private Chunk[] levelChunks;
    private GameObject FinishLine;


    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
        
            
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateOrderedLevel();

        FinishLine = GameObject.FindWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateOrderedLevel()
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < levelChunks.Length ; i++)
        {
            Chunk chunkToCreate = levelChunks[i];

            if (i == 0)
            {
                chunkPosition.z = chunkToCreate.GetLength() / 2;
            }

            if (i > 0)
            {
                chunkPosition.z += chunkToCreate.GetLength() / 2 ;
            }
            
            Chunk chunkInstance =  Instantiate(chunkToCreate, chunkPosition, Quaternion.identity ,transform);

            chunkPosition.z += chunkInstance.GetLength() / 2 ;
            
        }
    }


    private void CreateRandomLevel()
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < 5; i++)
        {
            Chunk chunkToCreate = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];

            if (i > 0)
            {
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            }
            
            Chunk chunkInstance =  Instantiate(chunkToCreate, chunkPosition, Quaternion.identity ,transform);

            chunkPosition.z += chunkInstance.GetLength() / 2 ;
            
        }
    }

    public float GetFinishZ()
    {
        return FinishLine.transform.position.z - 2 ;
    }
    
}
