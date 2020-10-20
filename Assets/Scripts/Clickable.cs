using UnityEngine;

public class Clickable : MonoBehaviour
{

    public float range = 3f; // interactable range

    public bool isFocus;
    public Transform player;
    public bool interacted = false;
    public bool isEnemy;
    public GameObject p;
    public Player joueur;
    protected void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");

        joueur = p.GetComponent<Player>();
        if (this.tag == "Enemy")
        {

            isEnemy = true;
            
        }
        joueur = p.GetComponent<Player>();
    }
    private void Update()
    {

      
        if (isFocus && (interacted == false))
        {
     
            if (isEnemy == true)
            {
                range = joueur.cRange;
            }
            else
            {
                range = joueur.talkRange;
            }
            float distance = Vector3.Distance(joueur.transform.position, transform.position);

            if (distance <= range)
            {
               
                interact();
                interacted = true;

            }
        }




    }
    public void OnFocused(Transform transform)
    {
       
        interacted = false;
        isFocus = true;
        player = transform;
        
    }
    public virtual void DeFocus()
    {

        interacted = false;
        isFocus = false;
        player = null;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public virtual void interact()
    {

    }
}
