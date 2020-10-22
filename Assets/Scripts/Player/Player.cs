using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // PLAYER DOESNT KEEP ATTACKING, HAVE TO PRESS.
    public float dmg = 10f;
    private float mAttackRate = 4f;
    private float nextAttack = 0f;
    private float mAttackRange = 3f;
    private float rAttackRange = 8f;
    private float rAttackRate = 4f;
    public bool melee = true;
    public float cRange = 4f;
    private float cRate = 2f;
    public float talkRange = 3f;
    public Animator animator = null;
    public string animName = "Slash";
    public LineRenderer shot;
    public Transform shootP;
    public AudioSource aud;
    public Health health;
    public GameObject axe;
    public GameObject bow;
    public AudioSource weapon;
    public AudioClip[] clip = new AudioClip[2];

    private void Start()
    {
        shot = GetComponent<LineRenderer>();
        shot.endWidth = 0.2f;
        shot.startWidth = 0.2f;
        aud = GetComponent<AudioSource>();
        health.onDeath.AddListener(Die);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeWeapon();
        }
    }

    public bool Attack()
    {


        if (nextAttack <= Time.time)
        {
            Debug.Log("Can Attack");
            nextAttack = Time.time + cRate;
            return true;
        }
        return false;

    }
    void ChangeWeapon()
    {
        melee = !melee;
        if (melee == true)
        {
            cRange = mAttackRange;
            cRate = mAttackRate;
            animName = "Slash";
            axe.SetActive(true);
            bow.SetActive(false);
            weapon.clip = clip[0];
            weapon.Play();
            
            
        }
        else
        {
            cRange = rAttackRange;
            cRate = rAttackRate;
            animName = "Shoot";
            bow.SetActive(true);
            axe.SetActive(false);
            weapon.clip = clip[1];
            weapon.Play();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, cRange);
    }
}
