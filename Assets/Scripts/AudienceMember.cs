using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceMember : MonoBehaviour
{
    Animator animator;
    float time = 0;
    float randomTime;
    public void Start()
    {
        animator = GetComponent<Animator>();
        randomTime = Random.Range(1f, 10f);
    }
    public void Update()
    {
        if (time >= randomTime)
        {
            animator.SetTrigger("RandomOffset");
            time = 0;
        }
        time += Time.deltaTime;
    }
}
