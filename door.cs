using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	[SerializeField]
	private GameObject thedoor;


void OnTriggerEnter ( Collider obj  ){
	///thedoor= GameObject.FindWithTag("SF_Door");
	thedoor.GetComponent<Animation>().Play("open");
}

void OnTriggerExit ( Collider obj  ){
	///thedoor= GameObject.FindWithTag("SF_Door");
	thedoor.GetComponent<Animation>().Play("close");
}
}