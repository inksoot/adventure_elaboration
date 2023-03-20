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
    public GameObject textBox;
    public GameObject tempdialogue;

    // Start is called before the first frame update
    void Start()
    {
        chickenText.SetActive(false);
        talismanObtained.SetActive(false);
        jobDone.SetActive(false);
        tempdialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
   
        Vector3 newPos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            newPos.y += movementSpd * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPos.y -= movementSpd * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= movementSpd * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPos.x += movementSpd * Time.deltaTime;
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
            Destroy(collision.gameObject);
        }
        if (wandAcquired && collision.gameObject.name == "enemy")
        {
            Destroy(collision.gameObject);
            talismanObtained.SetActive(false);
            chickenText.SetActive(false);
            jobDone.SetActive(true);
            tempdialogue.SetActive(true);
        } else if (!wandAcquired && collision.gameObject.name == "enemy")
        {
            chickenText.SetActive(true);
            talismanObtained.SetActive(false);
            jobDone.SetActive(false);
            tempdialogue.SetActive(true);
        }
    }

}

//deltaTime = change in time, standardizing movement (independent on frames)
