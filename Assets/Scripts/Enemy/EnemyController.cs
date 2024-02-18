using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Editior Variable
    [SerializeField]
    [Tooltip("How much health this enemy has")]
    private int m_MaxHeath;

    [SerializeField]
    [Tooltip("How fast the enemy can move")]
    private float m_Speed;

    [SerializeField]
    [Tooltip("Approximate amount of damage dealth per frame")]
    private float m_Damage;

    [SerializeField]
    [Tooltip("The explosion that occurs when this enemy dies")]
    private ParticleSystem m_DeathExplosion;

    [SerializeField]
    [Tooltip("The probability that an enemy drops a health pill")]
    private float m_HealthPillDropRate;

    [SerializeField]
    [Tooltip("The type of health pill this enemy will drop")]
    private GameObject m_HealthPill;

    [SerializeField]
    [Tooltip("How many points killing this enemy provides")]
    private int m_Score;
    #endregion

    #region Private Variable
    private float p_cureHealth;
    #endregion

    #region  Cached Components
    private Rigidbody cc_Rb;
    #endregion

    #region  Cached Refrences
    private Transform cr_Player;
    #endregion

    #region Initialization
    private void Awake()
    {
        p_cureHealth = m_MaxHeath;

        cc_Rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        cr_Player = FindObjectOfType<PlayerController>().transform;
    }
    #endregion

    #region  Main Updates
    private void FixedUpdate()
    {
        Vector3 dir = cr_Player.position - transform.position;
        dir.Normalize();
        cc_Rb.MovePosition(cc_Rb.position + dir * m_Speed * Time.fixedDeltaTime);
    }
    #endregion

    #region Collision Methods
    private void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.collider.gameObject;
        if (other.CompareTag("Player"))
        {
            
            other.GetComponent<PlayerController>().DecreaseHealth(m_Damage);
        }
    }
    #endregion

    #region Health Methods
    public void DecreaseHealth(float amount)
    {
        p_cureHealth -= amount;
        if (p_cureHealth <= 0)
        ScoreManager.singleton.IncreaseScore(m_Score);
        {
            if(Random.value < m_HealthPillDropRate)
            {
                Instantiate(m_HealthPill,transform.position, Quaternion.identity);
            }
            Instantiate(m_DeathExplosion,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    #endregion
}
