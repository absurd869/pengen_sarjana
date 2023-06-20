using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //public Slider NonActiveslide;
    // Start is called before the first frame update
    //Animator anim;
    //public Animator[] lol;

    private CharacterController controller;
    

    //public Animator[] allAnim;
    //public Transform[] rstPos;

    //public animasi[] Animasi;

    public karakterclass[] karakter;
    //public Transform pos;
    //public Animator anim;

    public Transform Cubepos;
    private Transform pos;
    private Animator anim;


    public static bool upButton, LeftButton, RightButton, DownButton;
    /* public GameObject upButton;
     public GameObject LeftButton;
     public GameObject RightButton;*/
   // public Button InteractDownButton; 

    public static Vector3 direction;
    public float forwardSpeed;
    public float MaxSpeed;

    public int jalur;
    public float jarakgaris;

    public float lompat;
    public float gravitasi;

    public float contheight;
    public float contY;

    private Vector3 ContCenter;
    private float ContHeight,speedMultiplier;
    private int PilihanPemain;
    private bool crRunning;

    void Start()
    {
        
        //scene = SceneManager.GetActiveScene().buildIndex;

        //Application.targetFrameRate = 100;
        controller = GetComponent<CharacterController>();
       
        ContCenter = controller.center;
        ContHeight = controller.height;

        PilihanPemain = PlayerPrefs.GetInt("karakter", 0);

        if (LevelSkripsi.LevelSkrip == true)
            PilihanPemain = 1;
        
       
        foreach (karakterclass a in karakter)
        {
            if(PilihanPemain == a.index)
            {
                anim = a.animator;
                pos = a.transform;
                a.gameObject.SetActive(true);
            }
        }

        anim.SetBool("Run", true);
    }

    /* 
      //SCRIPT KONTROLLER/NAVIGASI
    public static void ButtonUp(int click)
    {
        if (click == 1)
        {
            upButton = true;
        }
    }
    public static void ButtonLeft(int click)
    {
        if (click == 1)
        {
            LeftButton = true;
        }
    }
    public static void ButtonRight(int click)
    {
        if (click == 1)
        {
            RightButton = true;
        }
    }
    public static void ButtonDown(int click)
    {
        if (click == 1)
        {
            DownButton = true;
        }
    }
    */

    // Update is called once per frame
    void Update()
    {

        if (forwardSpeed < MaxSpeed && PlayerManager.LevelWisuda == true)
        {
            //Debug.Log("Level Sekarang " + LevelNow);
            forwardSpeed += 0.1f * Time.deltaTime;
              
        }

        direction.z = forwardSpeed;

        if (controller.isGrounded)
        {
            //if(Input.GetKeyDown(KeyCode.UpArrow))
            anim.SetBool("Jump", false);

            if (SwipeManager.swipeUp || upButton == true)
            {
                Jump();
                upButton = false;

            }

        }
        else
        {

            direction.y += gravitasi * Time.deltaTime;

        }

        if (SwipeManager.swipeDown || DownButton == true)
        {

            
            //anim.SetTrigger("JumpInAir");
            direction.y += gravitasi * 0.6f;
            DownButton = false;
            
            if(!crRunning)
            {
                anim.SetBool("SlideInAir", true);
                StartCoroutine(Slide());
            }
           
            //Debug.Log("SWIPED DOWN");
    
        }

        //if (Input.GetKeyDown(KeyCode.Mouse0))
        if(SwipeManager.swipeRight || RightButton == true)
        {
            jalur++;
            if (jalur == 3)
                jalur = 2;

            RightButton = false;
          //  Debug.Log("SWIPERIGHT");
        }

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        if(SwipeManager.swipeLeft || LeftButton == true)
        {
            jalur--;
            if (jalur == -1)
                jalur = 0;

            LeftButton = false;
           // Debug.Log("SWIPELEFT");
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        
        if (jalur == 0)
        {
            targetPosition += Vector3.left * jarakgaris;
        }

        else if (jalur == 2)
        {
            targetPosition += Vector3.right * jarakgaris;
        }

       transform.position = Vector3.Lerp(transform.position,targetPosition,80*Time.deltaTime);
       controller.center = controller.center;

        /*
        if(transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;

            if(moveDir.sqrMagnitude < diff.magnitude)
            {
                controller.Move(moveDir);
            }
            else
            {
                controller.Move(diff);
            }
        }
        */

        controller.Move(direction * Time.deltaTime);


        //Debug.Log(ContCenter);
        //forwardSpeed += newforwardSpeed;
        pos.position = new Vector3(Cubepos.position.x, Cubepos.position.y - 1.3f, Cubepos.position.z);
    }
    private void FixedUpdate()
    {
       // pos.position = new Vector3(Cubepos.position.x, Cubepos.position.y - 1.3f, Cubepos.position.z);
     
    }


    void correcting()
    {
        pos.rotation = Quaternion.Euler(new Vector3(0, 0.00000f, 0));
       // pos.position = new Vector3(Cubepos.position.x, 0.00000f, Cubepos.position.z);
        controller.center = ContCenter;
        controller.height = ContHeight;

        //Debug.Log("EXCETUDET");
    }
       
    private void Jump()
    {
        direction.y = lompat;

        //anim.SetBool("Jump", true);
        
        if (!crRunning)
        {
            anim.SetBool("Jump", true);
        }
        
        
    } 

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if(hit.transform.tag == "Obstacle")
       if (hit.transform.CompareTag ("Obstacle"))
        {
            PlayerManager.gameOver = true; //WISUDA LEVEL
            Level_1.gameOver = true;
            Level_2.gameOver = true;
            Level_3.gameOver = true;
            Level_4.gameOver = true;
            Level_5.gameOver = true;
            Level_6.gameOver = true;
            LevelSkripsi.gameOver = true;
        }
    }


    
    private IEnumerator Slide()
    {
        
        crRunning = true;
        controller.center = new Vector3(0, contY, 0);
        controller.height = contheight;
        
        anim.SetBool("Slide", true);

        if (forwardSpeed >= 17f && forwardSpeed <= 19f)
        {
            yield return new WaitForSeconds(0.8f);
            anim.speed = 1.1f;
            Debug.Log(anim.speed);
        }
        else if(forwardSpeed >= 19f)
        {
            yield return new WaitForSeconds(0.7f);
            anim.speed = 1.2f;
            Debug.Log(anim.speed);
        }
        else
        {
            yield return new WaitForSeconds(0.9f);
            Debug.Log(anim.speed);
        }


        correcting();
        crRunning = false;
        anim.SetBool("Slide", false);
        anim.SetBool("SlideInAir", false);
        
        yield return new WaitForSeconds(0.2f);
        correcting();
        //pos.rotation = Quaternion.Euler(new Vector3(0, 0.00000f, 0));

        
        //Debug.Log("EXCETUDET AGAIN");

    }





}
