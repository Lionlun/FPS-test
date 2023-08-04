using TMPro;
using UnityEngine;

public class HintTrigger : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI popupText;
	const string PLAYER_TAG = "Player";

	void PopupHint()
	{
		popupText.gameObject.SetActive(true);
	}

	void HideHint()
	{
		popupText.gameObject.SetActive(false);
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == PLAYER_TAG)
		{
			PopupHint();
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == PLAYER_TAG)
		{
			HideHint();
		}
	}
}
