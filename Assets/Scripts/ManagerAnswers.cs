using UnityEngine;

public class ManagerAnswers : MonoBehaviour
{
    public int score;
    public int totalCount = 1;

    [SerializeField] private GameObject _panel;

    [Header("Sound")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _winSound;

    private bool _isWin;

    private void OnEnable()
    {
        ItemSlot.ItemPlaced += ChekAnswers;
    }

    private void OnDisable()
    {
        ItemSlot.ItemPlaced -= ChekAnswers;
    }

    public void ChekAnswers()
    {
        score++;

        if (score == totalCount && !_isWin)
        {
            _isWin = true;
            WinPanel();
        }
    }

    private void WinPanel()
    {
        Debug.LogWarning("Win");

      
        
            _audioSource.PlayOneShot(_winSound);
        

        _panel.SetActive(true);
    }
}