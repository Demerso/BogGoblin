using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Clickable : MonoBehaviour
{

    public float range = 3f; // interactable range
    bool isFocus = false;
    Transform player;
    bool interacted = false;
    private void Update()
    {
        if (isFocus && interacted == false)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= range)
            {
                Debug.Log("interact");
                interacted = true;
            }
        }
    }
    public void OnFocused(Transform transform)
    {
        interact();
        interacted = false;
        isFocus = true;
        player = transform;
    }
    public void DeFocus()
    {
        interacted = false;
        isFocus = false;
        player = null;  
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,range);
    }

    public virtual void interact()
    {
        Debug.Log(this.name);
    }
}
