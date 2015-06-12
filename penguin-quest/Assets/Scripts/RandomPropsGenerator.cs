using UnityEngine;

public class RandomPropsGenerator : MonoBehaviour
{

	public bool gen=true;
	public float seconds=0;
	public int updateCounter=0;
	public int maxRange=200;

	public Vector2 playerPosition=new Vector2(0,0);
	public GameObject PenguinPlayer;
	
	// Use this for initialization
	void Start()
	{

	}
	void Update()
	{

		if(gen)
		{
			gen=false;
			//Invoke("GenerateNewObstacle" , Random.Range(4,8));
			Invoke("GenerateNewEggs",5.0f);
		}
		else
			updateCounter++;
			if(updateCounter >= maxRange)
			{
				gen=true;
				updateCounter=0;
			}

	
//		if(PenguinPlayer.transform.position.y >= 6.206661 || PenguinPlayer.transform.position.y < -12.7736)
//			RestartTheGame();
	}

	void RestartTheGame()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	void GenerateNewObstacle()
	{
		//pick obstancle from the path
		Instantiate(Resources.Load("Prefabs/Pillar") as GameObject,new Vector3(this.transform.localPosition.x,
		                                                                       Random.Range(-3.5f,-4.5f),
		                                                                       this.transform.localPosition.z),Quaternion.identity);
	}

	void GenerateNewEggs()
	{
		// spawn at random generator position
		Instantiate(Resources.Load("Prefabs/PillarWithEgg") as GameObject,new Vector3(this.transform.localPosition.x,
		                                                                              Random.Range(-3.5f,-4.5f),
		                                                                              this.transform.localPosition.z)
		           																	 ,Quaternion.identity);
	}

	void GenerateIceFloes()
	{
		// spawn at random generator position
		Instantiate(Resources.Load("Prefabs/IceFloe") as GameObject,Vector3.zero,Quaternion.identity);
	}
	
}