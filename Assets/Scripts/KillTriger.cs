using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTriger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D theObject){
        if (theObject.tag == "Player") {
            ScriptConejo.shareInstance.KillPlayer();
            Debug.Log("Conejito Muerto");
        };
    }

}
