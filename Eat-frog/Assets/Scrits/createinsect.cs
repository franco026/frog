 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createinsect : MonoBehaviour
{
    public BeeManager insects;
    private GameObject bees;
    public GameObject frog;

    private int numb;
    public float tiempocreate = 2f, rango = 2f;
    // Start is called before the first frame update

    void Start()
    {   
        InvokeRepeating("creando",0.0f,tiempocreate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void creando(){
        Vector3 spawsposition = new Vector3(0,0,0);
        spawsposition = this.transform.position + Random.onUnitSphere * rango;
        spawsposition = new Vector3(this.transform.position.x,spawsposition.y,0);
        if(frog.transform.position.y+1 <= spawsposition.y){
            GameObject insecto = Instantiate(GetGameObject(), spawsposition, Quaternion.identity);
        }

        
    }

    private GameObject GetGameObject(){
        numb  = Random.Range(0,2);
        print(numb);
        if(numb == 1){
            return insects.Negra;
        }else{
            return insects.Cafe;
        }
    }

   
}
