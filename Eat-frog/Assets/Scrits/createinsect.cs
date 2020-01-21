 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createinsect : MonoBehaviour
{
    public GameObject[] bees;
    public GameObject frog;
    private int cont;
    
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
            cont+=1;
            if(cont ==5){
                foreach (GameObject obj in bees ){
                    if (obj.tag=="Mariposa"){
                       GameObject butterfly = Instantiate(obj, spawsposition, Quaternion.identity);
                    }
                }   
            }else{
                if(cont==10){
                        foreach (GameObject obj in bees ){
                            if (obj.tag=="Mariposa_dorada"){
                            GameObject butterfly = Instantiate(obj, spawsposition, Quaternion.identity);
                        }
                    }
                }else{
                     GameObject insecto = Instantiate(bees[Random.Range(0,bees.Length)], spawsposition, Quaternion.identity);
                }
            }
            
        }
    }
   
}
