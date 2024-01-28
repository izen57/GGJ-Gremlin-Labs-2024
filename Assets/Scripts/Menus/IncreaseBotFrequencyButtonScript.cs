using UnityEngine;
using UnityEngine.UI;

public class IncreaseBotFrequencyButtonScript: MonoBehaviour
{
	[SerializeField] Button m_button;

	// Start is called before the first frame update
	void Start()
	{
		m_button.onClick.AddListener(IncreaseBotFrequency);
	}

	private void IncreaseBotFrequency()
	{
		if (GameController.Instance.Money >= 20) {
			FindObjectOfType<BotController>(true).botSO.time += 10;
			GameController.Instance.DecreaseMoneyDueToBuying(20);
		}
	}
}
