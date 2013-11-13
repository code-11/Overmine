using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
	
	public float m_speed;
	public float m_gravity;
	public Transform m_leftBottom;
	public Transform m_rightBottom;
	public Transform m_leftTop;
	public Transform m_rightTop;
	
	// Use this for initialization
	void OnEnable ()
	{
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float horiz = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");
		CheckSides(horiz,vert);
		gameObject.transform.Translate(new Vector3(horiz, 0, 0) * m_speed * Time.fixedDeltaTime);
		ApplyGravity();
		//OnCheckDeath();
	}
	
	void CheckSides(float horiz,float vert)
	{
		RaycastHit hitFromSide;
		Vector3 curPos=gameObject.transform.position;
		Vector3 sideVector=new Vector3(horiz,0,0);
		Vector3 fromCenter=curPos+sideVector+new Vector3((gameObject.transform.localScale.x/2.0F)*Mathf.Sign(horiz),0,0);
		Vector3 complete=fromCenter;
		//bool willCollide=Physics.Raycast(curPos,complete, out hitFromSide);
		
		if (horiz!=0)
		{	
			Debug.DrawLine(curPos,complete,Color.red, 0.02F);
		}
	}
	
	void ApplyGravity ()
	{
		Debug.DrawLine(m_leftBottom.transform.position, m_leftBottom.transform.position+Vector3.down*0.01F, Color.white, 1F);
		Debug.DrawLine(m_rightBottom.transform.position, m_rightBottom.transform.position+Vector3.down*0.01F, Color.gray, 1F);
		bool leftOpen=!Physics.Raycast(m_leftBottom.transform.position,Vector3.down,0.01F);
		bool rightOpen=!Physics.Raycast(m_rightBottom.transform.position,Vector3.down,0.01F);
		
		if (leftOpen && rightOpen)
		{
			gameObject.transform.Translate(new Vector3(0, m_gravity, 0) * m_speed * Time.fixedDeltaTime);	
		}
	}
	void OnCheckDeath()
	{
		RaycastHit leftHitInfo;
		RaycastHit rightHitInfo;
		bool leftHit=Physics.Raycast(m_leftTop.transform.position, Vector3.up,out leftHitInfo);
		bool rightHit=Physics.Raycast(m_rightTop.transform.position, Vector3.up,out rightHitInfo);
		
		if ((leftHit || rightHit) && ((leftHitInfo.distance<0.2F) || (rightHitInfo.distance<0.2F)))
		{
			ActivatePlayerDeath();
		} 	
	}
	/*
	void OnTriggerEnter(Collider other)
	{
		if(!other.gameObject.CompareTag("Player"))
		{
			ActivatePlayerDeath();
		}
	}
	*/
	void ActivatePlayerDeath()
	{
		Time.timeScale = 0.3F;
		Destroy(this.gameObject);
		Debug.Log("Game Over");
	}
}
