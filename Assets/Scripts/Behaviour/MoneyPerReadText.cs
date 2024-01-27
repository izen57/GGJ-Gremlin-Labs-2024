using TMPro;

using UnityEngine;

public class MoneyPerReadText : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI m_Object;

	// Start is called before the first frame update
	void Start()
	{
		m_Object.text = "$" + GameController.Instance.MoneyPerRead.ToString();
	}

	public void ChangeText(string text)
	{
		m_Object.text = text;
		Debug.Log("MoneyPerReadText has been changed.");
	}
}
