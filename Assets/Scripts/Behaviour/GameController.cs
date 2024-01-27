using UnityEngine;

public class GameController
{
	public float Money { get; private set; }
	//private MoneyText moneyText;

	public int SpamSent { get; private set; }
	//private SpamSentText spamSentText;

	public int SpamRead { get; private set; }
	private int _internalSpamReadCounter;

	public float ReadFrequency { get; private set; }
	public float MoneyPerRead { get; private set; }

	private static GameController _instance = null;
	public static GameController Instance
	{
		get {
			_instance ??= new GameController();
			return _instance;
		}
	}

	private GameController()
	{
		Debug.Log("The spammer has been initialized.");

		SpamSent = 0;
		SpamRead = 0;
		_internalSpamReadCounter = 0;
		Money = 0f;
		MoneyPerRead = 0.2f;
		ReadFrequency = 10f;

		//spamSentText = GameObject.Instantiate(spamSentText);
		//moneyText = GameObject.Instantiate(moneyText);
	}

	public void IncreaseSpam()
	{
		SpamSent++;
		Object.FindObjectOfType<SpamSentText>().ChangeText(SpamSent.ToString());
		Debug.Log("SpamSent has been increased.");
	}

	public void IncreaseSpam(int spamCount)
	{
		SpamSent += spamCount;
		Object.FindObjectOfType<SpamSentText>().ChangeText(SpamSent.ToString());
		Debug.Log($"SpamSent has been increased by {spamCount}.");
	}

	public void IncreaseMoney()
	{
		Money += MoneyPerRead;
		Object.FindObjectOfType<MoneyText>().ChangeText(Money.ToString());
		Debug.Log("Money has been increased.");
	}

	public void OnSpamRead()
	{
		if (++_internalSpamReadCounter % ReadFrequency == 0) {
			IncreaseMoney();
			SpamRead++;
			Object.FindObjectOfType<SpamReadText>().ChangeText(SpamRead.ToString());
			Debug.Log("SpamRead has been increased.");
		}
	}

	public void SendSpam(int spamCount)
	{
		IncreaseSpam(spamCount);
		OnSpamRead();
	}
}
