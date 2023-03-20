using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickManager : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
 
    }

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null)
                {
                    Debug.Log("CLICKED " + hit.collider.name);
                    ChangeSprite(newSprite);

            }
            //Debug.Log("Mouse Clicked");
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            //RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            //if (hit.collider != null)
            //{
            //    Debug.Log(hit.collider.gameObject.name);
            //    //hit.collider.attachedRigidbody.AddForce(Vector2.up);
            //}
        }
    }
}
