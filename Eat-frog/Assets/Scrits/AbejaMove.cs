using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbejaMove : MonoBehaviour
{
    // Start is called before the first frame update
    private FrogController from;
    private int target;

    void Start()
    {
        from = FindObjectOfType<FrogController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * 0.5f * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) {
     
        if(other.gameObject.tag == "Destroyer" || other.gameObject.tag == "lengua"){   
            if(from.con == 0){
                 Destroy(gameObject);
            }
        }
         
    }
}
