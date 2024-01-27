using UnityEngine;
using UnityEngine.UI;

public class IncreaseReadFrequencyButtonScript : MonoBehaviour
{
    [SerializeField] Button m_button;
    // Start is called before the first frame update
    void Start()
    {
        m_button.onClick.AddListener(IncreaseReadFrequency);
    }

    private void IncreaseReadFrequency()
    {
        GameController.Instance.IncreaseReadFrequency(3);
    }
}
