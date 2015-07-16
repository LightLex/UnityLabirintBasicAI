using UnityEngine;
using System.Collections;

public class BotSearch : MonoBehaviour {

	private GameObject map;
	private GameObject player;
	public float Speed = 1f;
	private Vector3 wayPoint;
	private bool found = false;
	NavMeshAgent agent;
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

		//Jugador atrapado
		if (dist <= 2) {
			map.GetComponent<Timer>().caught=true;
		}


		//Jugador detectado serca
		if (dist <= (map.GetComponent<Timer> ().time * 0.0005 + 6)) {
			agent.destination = player.transform.position;
			found = true;
		}

		//Jugador perdido de rango de deteccion
		if ( found == true && dist >= (map.GetComponent<Timer> ().time * 0.0005 + 6)){
			found=false;
			Wander();
		}

		//Velocidad aumentada por 0.05 por cada segundo del juego
		Speed = (float)(map.GetComponent<Timer>().time*0.05+1);
		agent.speed = Speed;

		float dist1 = Vector3.Distance (transform.position, player.transform.position);

		if(Vector3.Distance(transform.position,point)<=3){
			Wander();
		}

	}


	//Asignando nueva direccion aleatoria
	void Wander(){
		point = new Vector3(Random.Range(-28f,28f),-2f,Random.Range(-38f,38f));
		agent.destination = point;

	}
}
