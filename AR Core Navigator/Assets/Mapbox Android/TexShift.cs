using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexShift : MonoBehaviour {


	public Material mat;

	public Texture tex;

	
	void Start()
	{
		mat = new Material(Shader.Find("UI/Default"));
		mat.color = Random.ColorHSV(.5f, 1f, 1f, 1f, 0.5f, 1f);
		mat.SetTexture("_MainTex", tex);
		mat.mainTextureScale = new Vector2(20, 1);
		GetComponent<LineRenderer>().material = mat;
		mat.shader = Shader.Find("Custom/AlwaysOnTop");
	}
	
	void Update () 
	{
		float index = Time.time * 2;
		Vector2 textureShift = new Vector2(-index, 0);
 		mat.SetTextureOffset("_MainTex", new Vector2(Time.time * -2f, 0));
		
		for(int i = 0; i < transform.childCount; i++)
		{
			GetComponent<LineRenderer>().SetPosition(i,transform.GetChild(i).transform.position);
		}
		
		transform.localPosition = new Vector3(0,2,0);
	}
}
