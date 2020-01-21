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

    private ControlScore control;
    public int Score;
    // Start is called before the first frame update
     void Awake() {
        control = FindObjectOfType<ControlScore>();
        
    }
    void Start()
    {
        frog = FindObjectOfType<FrogController>();
        insecto = GetComponent<GameObject>();
        numb = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numb == 0){
            insecto = Instantiate(GetGameObject(), transform.position, Quaternion.identity);
            numb = 1;
        }

        
    }

    public void se(string ds){
        if(ds == objet && frog.con == 0){
            control.score +=Score;
            Destroy(insecto);
            numb = 0;
        }
    }


    
    private GameObject GetGameObject(){
        numb  = Random.Range(0,2);
        if(numb == 1){
            objet = "Negra";
            Score = 10;
            return Negra;
        }else{
            objet = "Cafe";
            Score = 10;
            return Cafe;
        }
    }


}
