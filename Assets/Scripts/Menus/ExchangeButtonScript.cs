using UnityEngine;
using UnityEngine.UI;

public class ExchangeButtonScript : MonoBehaviour
{
	[SerializeField] Button m_button;

	// Start is called before the first frame update
	void Start()
	{
		m_button.onClick.AddListener(Exchange);
	}

	private void Exchange()
	{
		if (GameController.Instance.Money >= 100) {
			GameController.Instance.DecreaseSpamSent(500);
			GameController.Instance.DecreaseMoneyDueToBuying(100);
		}
	}
}
