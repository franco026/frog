using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbejaMove : MonoBehaviour
{
    // Start is called before the first frame update
    private FrogController from;

    GameObject player;
    private int zigzag;
    private float vel;
    private bool cambio,toco,ataca;
    private int min,lo,ran;

    private Animator animator;
    private ControlScore control;
    private Vector3 initialposition,target;
    private bool mm = false;
    void Awake() {
        
        from = FindObjectOfType<FrogController>();
        control = FindObjectOfType<ControlScore>();
        
    }
    void Start()
    {
        
        ran = 3;//Random.Range(1,5);
        print("baja"+ran);
        target = from.transform.position;
        initialposition  = transform.position;
        animator = GetComponent<Animator>();
        cambio = true;
        zigzag = 0;
        min  = Random.Range(1,3);
        
    }

    void upvel(int score){
        if(score>=50){
            vel = Random.Range(2.5f,3.5f);

        }else{
            vel = Random.Range(0.5f,1.0f);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        lo = from.con;
        upvel(control.score);
        move();
        attack();
    }

    void attack(){
        if(ran == 3){
            StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        if(!toco){
            moveAttack();
        }
        else{
            retirada();
        }

    }
    
    void moveAttack(){
        animator.SetBool("Attack",true);
        ataca= true;
        if(animator.GetBool("Attack")){
            if(!mm){
            flip();
            mm=true;
        }
        }
        
    }

    void retirada(){
        Vector3 target = initialposition;
        if(!mm){
            flip();
            mm=true;
        }
    }

    void flip(){
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void move(){
        if(!ataca)
            switch(min){
                case 1:
                    transform.position += transform.right * vel * Time.deltaTime;
                        if(cambio){
                            transform.position += transform.up * vel * Time.deltaTime;
                            zigzag +=1;
                            if(zigzag ==50){
                                cambio= false;
                            }
                    }else{
                        transform.position -= transform.up * vel * Time.deltaTime;
                        zigzag -=1;
                        if(zigzag == 0){
                                cambio= true;;
                            }
                    }
                    break;
                case 2:
                        transform.position += transform.right * vel * Time.deltaTime;
                    break;
            }else{
                if(!toco){
                    transform.position = Vector3.MoveTowards(transform.position,target,10*Time.deltaTime);
                }else{
                    if(transform.position.y < initialposition.y){
                        transform.position += transform.up * 10 * Time.deltaTime;
                        transform.position += transform.right * 10 * Time.deltaTime;
                    }else{
                        flip();
                        mm= false;
                        ataca=false;
                    }
                }
            }
            
        }

        void OnTriggerExit2D(Collider2D other) {
        
            if(other.gameObject.tag == "lengua"){   
            if(lo == 0 && from.notoco){
                Destroy(gameObject);
            }
            }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag ==  "Destroyer"){
            Destroy(gameObject);
        }else{
            if(other.gameObject.tag ==  "Frog"){
                toco= true;
                animator.SetBool("Attack",false);
                from.curhealth -= 10f;
                from.healthlive.fillAmount = from.curhealth/100;
            }
        }
    }
}
