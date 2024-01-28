using UnityEngine;
using UnityEngine.UI;

public class IncreaseBotSendLetterEachTimeButtonScript: MonoBehaviour
{
	[SerializeField] Button m_button;

	// Start is called before the first frame update
	void Start()
	{
		m_button.onClick.AddListener(IncreaseBotFrequency);
	}

	private void IncreaseBotFrequency()
	{
		if (GameController.Instance.Money >= 30) {
			FindObjectOfType<BotController>(true).botSO.time += 20;
			GameController.Instance.DecreaseMoneyDueToBuying(30);
		}
	}
}
