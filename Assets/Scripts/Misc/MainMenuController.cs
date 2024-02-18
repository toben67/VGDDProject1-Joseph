using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    #region Editor Variable
    [SerializeField]
    [Tooltip("The text component highlighting the high score")]
    private TextMeshProUGUI m_HighScore;
    #endregion

    #region Private Variables
    private string m_DeafaultHighScoreText;
    #endregion
  #region Initialize
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        m_DeafaultHighScoreText = m_HighScore.text;
    }

    private void Start()
    {
        UpdateHighScore();
    }
  #endregion

  #region  Play Button Methods
    public void PlayArena()
    {
        SceneManager.LoadScene("Arena");
    }
  #endregion

  #region General Application Buttons
  public void Quit()
  {
    Application.Quit();
  }
  #endregion

  #region High Score Methods
    private void UpdateHighScore()
    {
        if (PlayerPrefs.HasKey("HS"))
        {
            m_HighScore.text = m_DeafaultHighScoreText.Replace("%S", PlayerPrefs.GetInt("HS").ToString());
        }
        else
        {
            PlayerPrefs.SetInt("HS",0);
            m_HighScore.text = m_DeafaultHighScoreText.Replace("%S", "0");
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HS",0);
        UpdateHighScore();
    }
  #endregion
}
