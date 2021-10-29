using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public static LevelGeneration sharedInstance;
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();
    public List<LevelBlock> currentLevelBlock = new List<LevelBlock>();
    public Transform levelInitialPoint;
    // Start is called before the first frame update
    void Awake(){
        sharedInstance = this;
        AddNewBlock();
        AddNewBlock();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Crear un valor aleatorio de 0 hasta el nunero total de blocjkes
    public void AddNewBlock(){
        int randomIndex = Random.Range(0,allTheLevelBlocks.Count);//creamos una instancia del objecto dependiendo el numero de bloques
        LevelBlock block = (LevelBlock)Instantiate(allTheLevelBlocks[randomIndex]);
        block.transform.SetParent(this.transform, false);//posicionar el blque creado
        Vector3 blockPosition = Vector3.zero;
        if (currentLevelBlock.Count == 0)
        {
            blockPosition = levelInitialPoint.position;
        }else
        {
            blockPosition = currentLevelBlock[currentLevelBlock.Count-1].exitPoint.position;
        }
        block.transform.position = blockPosition;
        currentLevelBlock.Add(block);
    }
}
