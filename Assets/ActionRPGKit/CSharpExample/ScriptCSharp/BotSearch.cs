using UnityEngine;
using System.Collections;

public class BotSearch : MonoBehaviour {

	private GameObject map;
	private GameObject player;
	public GameObject arrow1, arrow2, arrow3, arrow4;
	public float Speed = 1f;
	private Vector3 wayPoint;
	private bool found = false;
	NavMeshAgent agent;
	private float time=0;
	private Vector3 point = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
		if(!player){
			player = GameObject.FindWithTag ("Player");
		}
		if(!map){
			map = GameObject.FindWithTag ("Map");
		}
		agent = GetComponent<NavMeshAgent>();
		Wander ();
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (transform.position, player.transform.position);
		if (dist <= 2) {
			map.GetComponent<Timer>().caught=true;
		}

		if (dist <= (map.GetComponent<Timer> ().time * 0.0005 + 6)) {
			agent.destination = player.transform.position;
			found = true;
		}

		if ( found == true && dist >= (map.GetComponent<Timer> ().time * 0.0005 + 6)){
			found=false;
			Wander();
		}

		//transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(wayPoint), Time.deltaTime);

		Speed = (float)(map.GetComponent<Timer>().time*0.05+1);
		agent.speed = Speed;

		float dist1 = Vector3.Distance (transform.position, player.transform.position);

		if(Vector3.Distance(transform.position,point)<=3){
			Wander();
		}


		/*if (Vector3.Distance (transform.position, arrow1.transform.position) <= 1) {
			Wander();
		}else

		if (Vector3.Distance (transform.position, arrow2.transform.position) <= 1) {
			Wander();
		}else

		if (Vector3.Distance (transform.position, arrow3.transform.position) <= 1) {
			Wander();
		}else

		if (Vector3.Distance (transform.position, arrow4.transform.position) <= 1) {
			Wander();
		}*/

		/*Vector3 fwd = transform.TransformDirection (Vector3.forward);
		Vector3 fwd2 = new Vector3 (fwd.x, fwd.y-5, fwd.z);
		Vector3 fwd3 = new Vector3 (fwd.x, fwd.y+5, fwd.z);
		if (Physics.Raycast (transform.position, fwd, 4)==true && Physics.Raycast (transform.position, fwd2, 4)==true && Physics.Raycast (transform.position, fwd3, 4)==true) {
			wall=true;
			Wander ();
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(wayPoint), Time.deltaTime);

		} else {
			transform.position += transform.TransformDirection(Vector3.forward)*Speed*Time.deltaTime;
		}

		if (Physics.Raycast (transform.position, fwd, 10)) {
			wall=false;
		}

		if ((transform.position - wayPoint).magnitude < 3) {
			Wander();
		}*/

		time =time + Time.deltaTime;

		if (time > 100 && found==false) {
			//transform.position = new Vector3(0,0,0);
			time=0;
		}

	}

	void Wander(){
		point = new Vector3(Random.Range(-28f,28f),-2f,Random.Range(-38f,38f));
		agent.destination = point;
		/*int r = (int)Random.Range (0, 100);
		print (r);

		if(r<=100&&r>=80)
			agent.destination = arrow1.transform.position;
		else
		if(r<=80&&r>=60)
			agent.destination = arrow2.transform.position;
		else
		if(r<=60&&r>=40)
			agent.destination = arrow3.transform.position;
		else
		if(r<=40&&r>=0)
			agent.destination = arrow4.transform.position;
		//wayPoint =  new Vector3(Random.Range(transform.position.x - Range, transform.position.x + Range), 0, Random.Range(transform.position.z - Range, transform.position.z + Range));
		//transform.LookAt(wayPoint);*/

	}
}
