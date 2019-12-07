using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogController : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float distancia = 10f;

    public float maxhealth = 100f;
    float curhealth;


    public Image health;
    
    public GameObject len;
    private bool lol,ll,move;
    private float angle;
    public int con;
    public string obe;
    private Vector3 lookPos;

    private int Cont;
    private BoxCollider2D box;
    private Vector3 lengua;
    private Rigidbody2D rd2;
    private LayerMask mask;
    private Animator animator;
    private SpriteRenderer sprite;

    private estirolengua estiro;
    
    private Objectivo objectivo;

     void Awake()
    {
        objectivo = FindObjectOfType<Objectivo>();
        estiro = GetComponent<estirolengua>();
    }

    void Start()
    
    {

        sprite = GetComponent<SpriteRenderer>();
        rd2 = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Volver",false);
        curhealth = maxhealth;
        health.fillAmount = curhealth/maxhealth;
        //lineRenderer.enabled = false;  
        lol = true;
    }

    // Update is called once per frame
    void Update()
    {
        Getinput();
        movelengua();
        healthmin();
    }

    void healthmin(){
        curhealth -= 0.1f;
        health.fillAmount = curhealth/maxhealth;
        if(obe == objectivo.objet){
            curhealth += 10f;
            health.fillAmount = curhealth/maxhealth;
        }
    }

       void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Negra" || other.gameObject.tag == "Cafe"){   
                move = false;
                obe = other.gameObject.tag;
                con = 1;
        }
      
    }


    public void Getinput(){
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("up")){
            if(lol){
                lengua = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if(lengua.y <=(transform.position.y+1)){
                    return;
                }else{
                    UpdateState("frog-eat");
                    animator.SetBool("Volver",true);
                    lol = false;
                    move = true;    
                    Debug.DrawLine(transform.position,lengua,Color.blue);
                    len.transform.rotation = Quaternion.LookRotation(Vector3.forward, lengua - len.transform.position);
                    
                }
              
                //RaycastHit2D hit = Physics2D.Raycast(transform.position, lengua - transform.position,distancia,mask);
                //transform.Translate(0,0, 10*Time.deltaTime);
            }
        }
    }

    private void movelengua(){
        if(lol){
            return;
        }

        if(!lol){
            Vector3 temp = len.transform.position;
            Vector3 temp2 = len.transform.position;
            estiro.RenderLine(temp, false);
            len.GetComponent<SpriteRenderer>().sortingOrder = 2;
            if(move){
                temp += len.transform.up * Time.deltaTime *20;
            }else{
                temp -= len.transform.up * Time.deltaTime *20;
                
            }

            len.transform.position = temp;

            if(temp.y >= lengua.y){
                move = false;
                con = 1;
            }
            if(temp.y <= transform.position.y){
                len.transform.position=transform.position;
                print(temp2);
                animator.SetBool("Volver",false);
                len.GetComponent<SpriteRenderer>().sortingOrder = 0;
                lol = true;
                con = 0;
            }
            estiro.RenderLine(temp, true);
        }
    }
    

    public void UpdateState(string state = null){
        if(state!=null){
            animator.Play(state);
        }
    }


}
