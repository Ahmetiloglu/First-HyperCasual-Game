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
    [SerializeField] private LevelSO[] levels;
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
        GenerateLevel();

        FinishLine = GameObject.FindWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateLevel()
    {
        int currentLevel = GetLevel();
        currentLevel = currentLevel % levels.Length;
        LevelSO level = levels[currentLevel];
        
        CreateLevel((level.chunks));

    }
    

    private void CreateLevel(Chunk[] levelChunks)
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
    

    public float GetFinishZ()
    {
        return FinishLine.transform.position.z - 2 ;
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("level",0 );
    }
    
}
