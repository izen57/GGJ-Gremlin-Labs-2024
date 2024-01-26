using UnityEngine;

namespace Assets.Scripts
{
	public class Spammer: MonoBehaviour
	{
		public string Name { get; private set; }
		public float Money { get; private set; }
		public int SpamSent { get; private set; }

		public int SpamRead { get; private set; }
		private int _internalSpamReadCounter;

		public float ReadFrequency { get; private set; }
		public float MoneyPerRead { get; private set; }

		public void Start()
		{
			Name = name;
			SpamSent = 0;
			SpamRead = 0;
			_internalSpamReadCounter = 0;
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
			if (++_internalSpamReadCounter % ReadFrequency == 0) {
				IncreaseMoney();
				++SpamRead;
			}
		}
	}
}
