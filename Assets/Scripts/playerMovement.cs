using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//public UnityEngine.UI.Text textbox;

public class playerMovement : MonoBehaviour
{
    public float movementSpd = 0.7f;
    bool wandAcquired = false;
    public GameObject chickenText;
    public GameObject talismanObtained;
    public GameObject jobDone;
    //public GameObject textBox;
    public GameObject tempdialogue;
    public GameObject signDialogue;
    public GameObject cakeDialogue;
    public GameObject doorDialogue; 

    Animator myAnim;

    //bool walkUp = false;
    //bool walkDown = false;
    //bool walkLeft = false;
    //bool walkRight = false;

    // Start is called before the first frame update
    void Start()
    {
        chickenText.SetActive(false);
        talismanObtained.SetActive(false);
        jobDone.SetActive(false);
        tempdialogue.SetActive(true);
        cakeDialogue.SetActive(false);
        signDialogue.SetActive(false);
        doorDialogue.SetActive(false);

        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
   
        Vector3 newPos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            newPos.y += movementSpd * Time.deltaTime;
            myAnim.SetBool("playerUp", true);
            myAnim.SetBool("playerIdle", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            newPos.y -= movementSpd * Time.deltaTime;
            myAnim.SetBool("walkDown", true);
            myAnim.SetBool("playerIdle", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= movementSpd * Time.deltaTime;
            myAnim.SetBool("walkLeft", true);
            myAnim.SetBool("playerIdle", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            newPos.x += movementSpd * Time.deltaTime;
            myAnim.SetBool("walkRight", true);
            myAnim.SetBool("playerIdle", false);
        }
        else
        {
            myAnim.SetBool("playerUp", false);
            myAnim.SetBool("walkDown", false);
            myAnim.SetBool("walkLeft", false);
            myAnim.SetBool("walkRight", false);
            myAnim.SetBool("playerIdle", true);
        }



        transform.position = newPos;
    }

    void OnCollisionEnter2D(Collision2D collision) //can change "collision" to custom name
    {
       // Debug.Log(collision.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       //Debug.Log(collision.gameObject.name);
       //destroying wand with collision on player
       if(collision.gameObject.name == "wand")
        {
            wandAcquired = true;
            talismanObtained.SetActive(true);
            chickenText.SetActive(false);
            tempdialogue.SetActive(true);
            signDialogue.SetActive(false);
            cakeDialogue.SetActive(false);
            doorDialogue.SetActive(false);
            Destroy(collision.gameObject);
        }
        if (wandAcquired && collision.gameObject.name == "enemy")
        {
            Destroy(collision.gameObject);
            talismanObtained.SetActive(false);
            chickenText.SetActive(false);
            jobDone.SetActive(true);
            tempdialogue.SetActive(true);
            signDialogue.SetActive(false);
            cakeDialogue.SetActive(false);
            doorDialogue.SetActive(false);
        } else if (!wandAcquired && collision.gameObject.name == "enemy")
        {
            chickenText.SetActive(true);
            talismanObtained.SetActive(false);
            jobDone.SetActive(false);
            tempdialogue.SetActive(true);
            signDialogue.SetActive(false);
            cakeDialogue.SetActive(false);
            doorDialogue.SetActive(false);
        }

        if(collision.gameObject.name == "sign")
        {
            signDialogue.SetActive(true);
            talismanObtained.SetActive(false);
            chickenText.SetActive(false);
            jobDone.SetActive(false);
            //tempdialogue.SetActive(true);

        }

        if (collision.gameObject.name == "cake")
        {
            doorDialogue.SetActive(false);
            signDialogue.SetActive(false);
            cakeDialogue.SetActive(true);
            talismanObtained.SetActive(false);
            chickenText.SetActive(false);
            jobDone.SetActive(false);
            //tempdialogue.SetActive(true);

        }

        if (collision.gameObject.name == "exit")
        {
            cakeDialogue.SetActive(false);
            signDialogue.SetActive(false);
            doorDialogue.SetActive(true);
            talismanObtained.SetActive(false);
            chickenText.SetActive(false);
            jobDone.SetActive(false);
           // tempdialogue.SetActive(true);

        }
    }

}

//deltaTime = change in time, standardizing movement (independent on frames)
