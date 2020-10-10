using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    Camera cam;
    public LayerMask mask;
    Movement moves;
    public Clickable Looking;
   
    void Start()
    {
        cam = Camera.main;
        moves = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit,100,mask))
            {
                if(Looking != null)
                {
                    Looking.DeFocus();
                }
                moves.MoveToPoint(hit.point);
                //Maybe Make function Unfollow, could help clarify.
                Looking = null;
                moves.UnFollow();

     
            }

        }
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Clickable clicked = hit.collider.GetComponent<Clickable>();

                if(clicked != null)
                {
                    SetFocus(clicked);
                }
                
            }

        }
        if(Looking != null)
        {
            moves.Follow(Looking);
        }
    }
    void SetFocus(Clickable clicked)
    {
        if(Looking != clicked)
        {
            if(Looking != null)
            {
                Looking = clicked;
            }
            Looking = clicked;

            moves.Follow(Looking);
        }
        Looking.OnFocused(transform);
    }


   
    
}
