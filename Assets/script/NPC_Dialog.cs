using UnityEngine;
using System.Collections;

public class NPC_Dialog : MonoBehaviour
{
	
	public string[] dialogButton;
	public string[] dialogText;
	

	public Texture2D imageTexture;
	
	//private bool clickable = false;
	public bool displayDialog = false;

	
	public bool hasDoneQuest = false;
	
	private Vector3 screenPosition;
	
	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{


	}
	

	void OnGUI()
	{
		//GUI.skin = talkSkin;
		GUILayout.BeginArea(new Rect(100,100,200, 400));

		if (displayDialog) {
			GUI.DrawTexture(new Rect(0, 20,200, 200),imageTexture);

			for(int i=0; i<dialogText.Length;i++){
			GUILayout.Label(dialogText [i]);
			}

			if (GUI.Button(new Rect(70, 200,60, 30),dialogButton [0])) {
			
				displayDialog = false;
				hasDoneQuest = false;
				Debug.Log("click object name is " + gameObject.name);

			}
			
			//if (GUI.Button(dialogButton [1])) {
			//	displayDialog = false;
			//}
		}
		
		//if (displayDialog && hasDoneQuest) {
		//	GUI.Label(dialogText [2]);
			//if (GUI.Button(dialogButton [2])) {
			//	displayDialog = false;
			//}
		//}
		GUILayout.EndArea();
	}
}