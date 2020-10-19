using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera cam;
    private Movement moves;
    public Clickable looking;
    private GameObject particle;

    private void Start()
    {
        cam = Camera.main;
        moves = GetComponent<Movement>();

    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit,100))
            {
                if (GroundLayerHit(hit))
                {
                    if(looking != null)
                    {
                        looking.DeFocus();
                    }

                    moves.MoveToPoint(hit.point);
                    //Maybe Make function Unfollow, could help clarify.
                    looking = null;
                    moves.UnFollow();
                    
                    if (Input.GetMouseButtonDown(1))
                    {
                        DrawClickRipple(hit);
                    }
                    
                }

            }

        }
        
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, 100))
            {
                Clickable clicked = hit.collider.GetComponent<Clickable>();

                if(clicked != null)
                {
                    SetFocus(clicked);
                }
                
            }

        }
        if(looking != null)
        {
            moves.Follow(looking);
        }
    }

    void SetFocus(Clickable clicked)
    {
        if(looking != clicked)
        {
            if(looking != null)
            {
                looking = clicked;
            }
            looking = clicked;

            moves.Follow(looking);
        }
        looking.OnFocused(transform);
    }

    private void DrawClickRipple(RaycastHit hit)
    {
        particle = ObjectPooler.SharedInstance.GetPooledObject();
        if (particle == null)
        {

            ObjectPooler.SharedInstance.DestroyFirst();
            particle = ObjectPooler.SharedInstance.GetPooledObject();

        }
        particle.transform.position = hit.point + Vector3.up * 0.5f;
        particle.SetActive(true);
    }

    private static bool GroundLayerHit(RaycastHit hit)
    {
        return hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground");
    }
   
    
}
