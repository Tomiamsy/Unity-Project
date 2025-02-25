using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public int CoinCount = 0;
    public Text CoinText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        CoinText.text = CoinCount.ToString();
    }

    public void AddCoin()
    {
        CoinCount = CoinCount + 1;
        UpdateCoinText();
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
