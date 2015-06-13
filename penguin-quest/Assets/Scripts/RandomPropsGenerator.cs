using UnityEngine;

public class RandomPropsGenerator : MonoBehaviour
{

	public bool gen;
	public float seconds=0;
	public int updateCounter=0;
	public int maxRange=250;

	public Vector2 playerPosition=new Vector2(0,0);
	public GameObject PenguinPlayer;
	public GameObject lastGeneratedObj;
	public Vector2 lastGeneratedObjPos;
	
	// Use this for initialization
	void Start(){
		Invoke("GenerateIceFloes",2.0f);

	}
	void Update()
	{
		if(gen){
			gen=false;
			int rand = Random.Range(0,3);
			if(rand==0)
				Invoke("GenerateIceFloes",5.0f);
			else if(rand==1)
				Invoke("GenerateNewEggs",10.0f);
			else
				Invoke("GenerateNewEnemies",15.0f);


		}
		else
			updateCounter++;
			if(updateCounter >= maxRange)
			{
				gen=true;
				updateCounter=0;
			}
	}

	void GenerateNewEnemies()
	{
		CancelInvoke ("GenerateNewEnemies");
		//pick obstancle from the path
		lastGeneratedObj = Instantiate(Resources.Load("Prefabs/SealOnIce") as GameObject,new Vector3(this.transform.localPosition.x,
		                                                                       Random.Range(-4.5f,-5.5f),
		                                                                       0),Quaternion.identity) as GameObject;
	}

	void GenerateNewEggs()
	{
		CancelInvoke ("GenerateNewEggs");
		// spawn at random generator position
		lastGeneratedObj = Instantiate(Resources.Load("Prefabs/PillarWithEgg") as GameObject,new Vector3(this.transform.localPosition.x,
		                                                                              Random.Range(-3.5f,-4.5f),
		                                                                              0)
		           																	 ,Quaternion.identity) as GameObject;
	}

	void GenerateIceFloes()
	{
		CancelInvoke("GenerateIceFloes");
		int rand = Random.Range (0, 2);
		string icefloeName = "";
		// spawn at random generator position

		if (rand == 0)
			icefloeName = "IceFloe_Small";
		else
			icefloeName = "IceFloe_Large";

		if(icefloeName!="")
			lastGeneratedObj = Instantiate (Resources.Load ("Prefabs/" + icefloeName) as GameObject, new Vector3 (15.0f,
			                                                                             Random.Range (-2.3f, -3.3f),
			                                                                             0),Quaternion.identity) as GameObject;
	}
	
}