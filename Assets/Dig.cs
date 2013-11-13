using UnityEngine;
using System.Collections;

	
	

public class Dig : MonoBehaviour {
	
	public int m_toughness;
	public int m_curToughness;
	
	// Use this for initialization
	void Start () {
		m_curToughness=m_toughness;
	}
	
	// Update is called once per frame
	void Update () {
		CheckDestroyed();
		RestoreToughness();
	}
	void RestoreToughness(){
		if (m_curToughness<m_toughness)
		{
			m_curToughness+=1;
		}
	}
	void CheckDestroyed(){
		if (m_curToughness<=0)
		{
			Destroy(this.gameObject);
		}
	}
	void OnCollisionEnter(Collision other)
	{
		//HandleCollision(other.gameObject);
	}
	
	void HandleCollision (GameObject other) {
		Debug.DrawLine(gameObject.transform.position, other.transform.position, Color.green, 1F);
		if (other.CompareTag("Player"))
		{
			m_curToughness-=3;
		}		
	}
	void OnCollisionStay(Collision other)
	{
		HandleCollision(other.gameObject);	
	}
}
