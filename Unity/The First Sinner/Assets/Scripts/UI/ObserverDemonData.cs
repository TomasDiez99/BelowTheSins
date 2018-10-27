using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	[RequireComponent(typeof(Image))]
	public class ObserverDemonData : MonoBehaviour
	{

		private Image Image => GetComponent<Image>();


		public DemonData Data;


		private void Update()
		{
			Image.fillAmount = Data.Health;
		}
	}
}

