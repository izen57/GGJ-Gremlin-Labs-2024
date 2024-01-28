using UnityEngine;
using UnityEngine.UI;

public class IncreaseMoneyPerReadButtonScript: MonoBehaviour
{
	[SerializeField] Button m_button;

	// Start is called before the first frame update
	void Start()
	{
		m_button.onClick.AddListener(IncreaseMoneyPerRead);
	}

	private void IncreaseMoneyPerRead()
	{
		if (GameController.Instance.Money >= 5) {
			GameController.Instance.IncreaseMoneyPerRead(10);
			GameController.Instance.DecreaseMoneyDueToBuying(5);
		}
	}
}
