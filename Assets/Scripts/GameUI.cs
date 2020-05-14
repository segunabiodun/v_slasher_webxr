using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
	[SerializeField] GameObject startPanel;
	float deltaTime = 0.0f;

    //debug
	[SerializeField] Text fpsText = null;
	[SerializeField] Text debugButtonText = null;
	int buttonClickCount = 0;

	private void Awake()
    {
		//if (!Application.isEditor)
		//	startPanel.SetActive(true);

        fpsText.enabled = true;
    }

    void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		//GUI.Label(rect, text, style);
		this.fpsText.text = text;
	}

    public void debugButtonClicked()
    {
		buttonClickCount += 1;
		debugButtonText.text = $"Clicked {buttonClickCount}";
    }
}