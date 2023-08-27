using System;
using TMPro;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    // Static fields
    private static short keyCount = 0;
    private static int scrapCount = 0;
    
    // Serialized fields
    [SerializeField] private GameObject _keyCountDisplay;
    [SerializeField] private GameObject _scrapCountDisplay;
    [SerializeField] private GameObject _winMessage;

    // Components
    private static TextMeshProUGUI _keyCountText;
    private static TextMeshProUGUI _scrapCountText;

    // Events
    public static event Action OnGettingAllKeys;

    // Parameters
    private const short REQUIRED_KEY_COUNT = 4;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Exit.OnReachingExit += DisplayWinText;
        _keyCountText = _keyCountDisplay.GetComponent<TextMeshProUGUI>();
        _scrapCountText = _scrapCountDisplay.GetComponent<TextMeshProUGUI>();
    }

    public static void IncreaseKeyCount() {
        keyCount++;
        _keyCountText.text = keyCount + "/" + REQUIRED_KEY_COUNT; 
        if (keyCount == REQUIRED_KEY_COUNT) {
            OnGettingAllKeys?.Invoke();
        }
    }

    public static void IncreaseScrapCount() {
        scrapCount++;
        _scrapCountText.text = scrapCount.ToString();
    }

    private void DisplayWinText() {
        _winMessage.GetComponent<TextMeshProUGUI>().text = "YOU WIN!!!";
    }
}
