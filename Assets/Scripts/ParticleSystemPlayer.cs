using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemPlayer : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;
    [SerializeField] float defaultRadius;
    Transform head;
    public void Start()
    {
        head = transform.GetChild(0);
    }
    public void StartHitEffect(float angleRad)
    {
        GameObject curParticle = Instantiate(hitEffect, new Vector3(
            head.position.x + defaultRadius * Mathf.Cos(angleRad),
            head.position.y + defaultRadius * Mathf.Sin(angleRad), 
            hitEffect.transform.position.z), Quaternion.identity);
        //curParticle.transform.parent = transform;
        StartCoroutine(killEffect(curParticle, 1f));
    }
    IEnumerator killEffect(GameObject particles, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(particles);
    }

}
