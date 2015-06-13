using UnityEngine;

public class RandomPropsGenerator : MonoBehaviour
{

	public bool gen=true;
	public float seconds=0;
	public int updateCounter=0;
	public int maxRange=500;

	public Vector2 playerPosition=new Vector2(0,0);
	public GameObject PenguinPlayer;
	
	// Use this for initialization
	void Start()
	{

	}
	void Update()
	{
		if(gen){
			gen=false;
			int rand = Random.Range(0,2);
			if(rand==0)
				Invoke("GenerateIceFloes",5.0f);
			else if(rand==1)
				Invoke("GenerateNewEggs",10.0f);
//			else
//				Invoke("GenerateNewObstacle",15.0f);


		}
		else
			updateCounter++;
			if(updateCounter >= maxRange)
			{
				gen=true;
				updateCounter=0;
			}
	}

	void RestartTheGame()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	void GenerateNewObstacle()
	{
		//pick obstancle from the path
		Instantiate(Resources.Load("Prefabs/Pillar") as GameObject,new Vector3(this.transform.localPosition.x,
		                                                                       Random.Range(-4.5f,-5.5f),
		                                                                       this.transform.localPosition.z),Quaternion.identity);
	}

	void GenerateNewEggs()
	{
		CancelInvoke ("GenerateNewEggs");
		// spawn at random generator position
		Instantiate(Resources.Load("Prefabs/PillarWithEgg") as GameObject,new Vector3(this.transform.localPosition.x,
		                                                                              Random.Range(-3.5f,-4.5f),
		                                                                              this.transform.localPosition.z)
		           																	 ,Quaternion.identity);
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
			Instantiate (Resources.Load ("Prefabs/" + icefloeName) as GameObject, new Vector3 (this.transform.localPosition.x - 5f,
			                                                                             Random.Range (-2.3f, -3.3f),
			                                                                             this.transform.localPosition.z),Quaternion.identity);
	}
	
}