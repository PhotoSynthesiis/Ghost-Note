using UnityEngine;
using System.Collections;

public class Npc_dialog_detect : MonoBehaviour {


	private NPC_Dialog d1;
	private Vector3 screenPosition;
	
	// Use this for initialization




	private int success;
	private int swith;
	// Use this for initialization
	
	
	private string userPassword;//密码
	private string info;//信息
	private string title;
	private string tester;
	
	private GameObject door;

	private int key1;
	private int key2;


	void Start()
	{
		swith = 0;
		
		
		
		userPassword = "";
		info = "";
		title = "Please type the password to open the door !";
		tester="";

		key1 = 0;
		key2 = 0;

		success = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		
		
		if(Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机发出到点击坐标的射线
			RaycastHit hitInfo;
			if(Physics.Raycast(ray,out hitInfo))
			{
				Debug.DrawLine(ray.origin,hitInfo.point);//划出射线，只有在scene视图中才能看到
				GameObject gameObj = hitInfo.collider.gameObject;
				//Debug.Log("click object name is " + gameObj.name);
				if(gameObj.name == "passwordgate")//当射线碰撞目标为boot类型的物品 ，执行拾取操作
				{
					swith=1;
				}

				if(gameObj.name == "bookwall1")//当射线碰撞目标为boot类型的物品 ，执行拾取操作
				{
					d1= gameObj.GetComponent<NPC_Dialog>();// dialog content
					d1.displayDialog = true;
					key1=1;
				}


				if(gameObj.name == "bookwall2")//当射线碰撞目标为boot类型的物品 ，执行拾取操作
				{
					d1= gameObj.GetComponent<NPC_Dialog>();// dialog content
					d1.displayDialog = true;
					key2=1;
				}

				if(gameObj.name == "keygate1"&&key1==1)//当射线碰撞目标为boot类型的物品 ，执行拾取操作
				{
					d1= gameObj.GetComponent<NPC_Dialog>();// dialog content
					d1.displayDialog = true;
					Destroy (gameObj);
					key1=0;
				}


				if(gameObj.name == "keygate2"&&key2==1)//当射线碰撞目标为boot类型的物品 ，执行拾取操作
				{
					d1= gameObj.GetComponent<NPC_Dialog>();// dialog content
					d1.displayDialog = true;
					Destroy (gameObj);
					key2=0;
				}

			}
			
		}


		if (success == 1) {
			door = GameObject.Find ("passwordgate");
			Destroy (door);
		}
		
		
		
	}




	void OnGUI()
	{
		//用户名
		//GUI.Label(new Rect(20,20,50,20),"用户名");
		//userName = GUI.TextField(new Rect(80,20,100,20),userName,15);//15为最大字符串长度
		//密码
		if (swith == 1) {	
			GUI.TextArea (new Rect (20, 20, 290, 20), title);  
			
			GUI.Label (new Rect (20, 50, 60, 20), "password");
			userPassword = GUI.PasswordField (new Rect (80, 50, 100, 20), userPassword, '*');//'*'为密码遮罩
			//信息
			GUI.Label (new Rect (20, 100, 100, 120), info);
			//登录按钮
			
			if (GUI.Button (new Rect (80, 80, 50, 20), "open")) {
			
		     
				
				if (userPassword == "1030") {
					info = "Success,Press Open !";
					//for(int i=0;i<90;i++)
					//	Door();
					swith = 0;
					success=1;
					
				} else {
					info = "Password is not correct, try again ！";

				}


			}
			
			
			
		}
	}

}
