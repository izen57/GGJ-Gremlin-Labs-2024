using UnityEngine;
using UnityEngine.UI;

public class DecreaseReadFrequencyButtonScript : MonoBehaviour
{
	[SerializeField] Button m_button;

	// Start is called before the first frame update
	void Start()
	{
		m_button.onClick.AddListener(DecreaseReadFrequency);
	}

	private void DecreaseReadFrequency()
	{
		if (GameController.Instance.Money >= 1) {
			GameController.Instance.DecreaseReadFrequency(3);
			GameController.Instance.DecreaseMoneyDueToBuying(1);
		}
	}
}
