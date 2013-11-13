using UnityEngine;
using System.Collections;

public class MakeLevelTest : MonoBehaviour {
	
	public float gridX = 5f;
	public float gridY = 5f;
	public float spacing = 2f;
	public GameObject prefab;
	
	// Use this for initialization
	void Start () {
		/*Vector3 pos=new Vector3(0,0,0);
		Instantiate(prefab,pos,Quaternion.identity);*/
		for (int y = 0; y < gridY; y++) {
			for (int x = 0; x < gridX; x++) {
				Vector3 pos = new Vector3(x, y, 0) * spacing;
				Instantiate(prefab, pos, Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
