using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllengua : MonoBehaviour
{
    private ControlScore control;
    private FrogController frog;
    // Start is called before the first frame update
    private void Awake() {
        control = FindObjectOfType<ControlScore>();
        frog = FindObjectOfType<FrogController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Negra" || other.gameObject.tag == "Cafe" || other.gameObject.tag == "Blanca"){   
                control.score +=10;
                frog.move = false;
                frog.curhealth += 25f;
                frog.healthlive.fillAmount =frog.curhealth/frog.maxhealth;
                if(!frog.notoco){
                    frog.con = 0;
                    frog.notoco = true;
                }

        }else{
            if(other.gameObject.tag =="Mariposa"){
                control.score +=10;
                frog.move = false;
                frog.liveup.SetActive(true);
                frog.live.SetActive(false);
                frog.healthlive = frog.healthliveup;
                frog.curhealth += 25f;
                frog.healthlive.fillAmount =frog.curhealth/frog.maxhealth;
                frog.LiveMAx = true;
                if(!frog.notoco){
                    frog.con = 0;
                    frog.notoco = true;
                }
            }else{
                if(other.gameObject.tag =="Mariposa_dorada"){
                    control.score +=20;
                    frog.vel_lengua = 35;
                    frog.move = false;
                    frog.healthlive = frog.healthliveup;
                    frog.curhealth += 25f;
                    frog.healthlive.fillAmount =frog.curhealth/frog.maxhealth;
                    frog.LiveMAx = true;
                    if(!frog.notoco){
                        frog.con = 0;
                        frog.notoco = true;
                    }
                }
            }
        }
      
    }

}
