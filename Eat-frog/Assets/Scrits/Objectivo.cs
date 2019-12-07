using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectivo : MonoBehaviour
{

    public GameObject Negra, Cafe;
    private GameObject insecto;

    private FrogController frog;

    public string objet;
    
    private int numb;
    // Start is called before the first frame update
    void Start()
    {

        insecto = GetComponent<GameObject>();
        frog = FindObjectOfType<FrogController>();
        numb = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numb == 0){
            insecto = Instantiate(GetGameObject(), transform.position, Quaternion.identity);
            numb = 1;
        }
        
        if(frog.obe == objet){
            Destroy(insecto);
            numb = 0;
        }
       
    }

    
    private GameObject GetGameObject(){
        numb  = Random.Range(0,2);
        print(numb);
        if(numb == 1){
            objet = "Negra";
            return Negra;
        }else{
            objet = "Cafe";
            return Cafe;
        }
    }


}
