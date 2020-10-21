using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    private float maxHp;

    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Camera mainCamera;

    private Slider healthBar;
    
    public float hp;
    
    public UnityEvent onDeath = new UnityEvent();

    private void Start()
    {
        maxHp = hp;
        healthBar = Instantiate(healthBarPrefab, transform).GetComponent<Slider>();
        healthBar.maxValue = maxHp;
    }

    private void LateUpdate()
    {
        healthBar.value = hp;
        healthBar.gameObject.transform.LookAt(healthBar.gameObject.transform.position + mainCamera.transform.forward);
    }

    public void TakeDmg(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            onDeath.Invoke();
        }
    }
}
