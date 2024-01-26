using UnityEngine;

namespace Assets.Scripts
{
	public class Spammer: MonoBehaviour
	{
		public string Name { get; private set; }
		public float Money { get; private set; }
		public float SpamSent { get; private set; }
		public float SpamRead { get; private set; }
		public float ReadFrequency { get; private set; }
		public float MoneyPerRead { get; private set; }

		public void Start()
		{
			Name = name;
			SpamSent = 0f;
			SpamRead = 0f;
			Money = 0f;
			MoneyPerRead = 10f;
			ReadFrequency = 5f;
		}
		
		public void IncreaseSpam()
		{
			SpamSent++;
		}

		public void IncreaseMoney()
		{
			Money += MoneyPerRead;
		}

		public void OnSpamRead()
		{
			IncreaseMoney();
		}
	}
}
