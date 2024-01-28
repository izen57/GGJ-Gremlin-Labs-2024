using TMPro;

using UnityEngine;

public class SpamReadText : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI m_Object;

	// Start is called before the first frame update
	void Start()
	{
		m_Object.text = GameController.Instance.SpamRead.ToString();
	}

	public void ChangeText(string text)
	{
		m_Object.text = text;
		Debug.Log("SpamReadText has been changed.");
	}
}
