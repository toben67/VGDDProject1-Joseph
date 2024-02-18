using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("All of the main information about this particular ability.")]
    protected AbilityInfo m_info;
    #endregion

    #region Cached Components
    protected ParticleSystem cc_PS;
    #endregion
    #region Initalization
    private void Awake()
    {
        cc_PS = GetComponent<ParticleSystem>();
    }
    #endregion

    #region  Use Methods
    public abstract void Use(UnityEngine.Vector3 spawnPos);
    #endregion
}
