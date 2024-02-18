using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : Ability
{
    public override void Use(Vector3 spawnPos)
    {
       RaycastHit hit;
       float newLength = m_info.Range;
       if (Physics.SphereCast(spawnPos, 0.5f, transform.forward, out hit, m_info.Range))
       {
        newLength = (hit.point - spawnPos).magnitude;
        if (hit.collider.CompareTag("Enemy"))
        {
            hit.collider.GetComponent<EnemyController>().DecreaseHealth(m_info.Power);
        }
       }
       var emitterShape = cc_PS.shape;
       emitterShape.length = newLength;
       cc_PS.Play();
    }

    
}
