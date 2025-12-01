using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class SkillSpawn : MonoBehaviour
{
	[SerializeField]
	private int skillSpawnCount;
	[SerializeField]
	private GameObject[] skillPrefabArray;
	[SerializeField]
	private Transform spawnPoint;
	[SerializeField]
	private Transform userPoint;

	private int currentObjectCount = 0;
	private float skillSpawnTime = 0.0f;
	private float delayedTime = 2.0f;
	private GameObject lastSkill = null;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{	
		
		if( currentObjectCount + 1 > skillSpawnCount)
		{
			return;
		}

		skillSpawnTime += Time.deltaTime;

		if ( skillSpawnTime >= 0.5f )
		{
			//Debug.Log(currentObjectCount + "/" + skillSpawnCount);
			int prefabIndex = Random.Range(0, skillPrefabArray.Length);

			Vector3 position = spawnPoint.position;
			//Debug.Log(position);
			//Debug.Log(skillPrefabArray + " " + prefabIndex + " " + skillPrefabArray[prefabIndex]);
			GameObject skill = Instantiate(skillPrefabArray[prefabIndex], position, Quaternion.identity);
			Transform Parent = GameObject.Find("UserSkill").GetComponent<Transform>();
			skill.transform.parent = Parent;
			
			if(lastSkill != null)
			{
				skill.GetComponent<Movement2D>().pPreviousSkill = lastSkill;
				lastSkill.GetComponent<Movement2D>().pNextSkill = skill;
			}
			//Debug.Log("HI " + skill + " "+ skill.GetComponent<Movement2D>());
			//Debug.Log("HI " + skill + " "+ skill.GetComponent<UserSkill>().skillType);

			skill.GetComponent<Movement2D>().skillType = prefabIndex;
			
			lastSkill = skill;

			Vector3 moveDirection = Vector3.right;
			skill.GetComponent<Movement2D>().Setup(moveDirection);
			currentObjectCount++;
			skillSpawnTime = 0.0f; 
		}
	}

	public int UseSkillAndDestroy(GameObject obj, int direction=0, int combo=1)
    {
        Vector3 position = userPoint.position;
        // Vector3 moveDirection = Vector3.left;
		Vector3 moveDirection = new Vector3(-1, Random.Range(0.0f, 1.0f), 0);
		
		obj.transform.localPosition = position;
		obj.GetComponent<Movement2D>().SetRotation(
			Random.Range(100.0f, 150.0f) * (float)Random.Range(-1, 1)
		);
		GameObject prev = obj.GetComponent<Movement2D>().pPreviousSkill;
		GameObject next = obj.GetComponent<Movement2D>().pNextSkill;
		int skillType = obj.GetComponent<Movement2D>().skillType;
		

		if(next != null)
		{
			next.GetComponent<Movement2D>().pPreviousSkill = prev;
		}
		if(prev != null)
		{
			prev.GetComponent<Movement2D>().pNextSkill = next;
		}
		
        obj.GetComponent<Movement2D>().Setup(moveDirection);
        
		currentObjectCount--;
		int originDirection = direction;
		int currentCombo = combo;
		//Debug.Log(direction +" "+ prev +" "+ next);
		
		if(prev != null && prev.GetComponent<Movement2D>().skillType == skillType && originDirection != 1)
		{
			currentCombo = this.UseSkillAndDestroy(prev, direction=-1, combo=currentCombo+1);
		}
		// Debug.Log(direction +" "+ prev +" "+ next);
		
		if(next != null && next.GetComponent<Movement2D>().skillType == skillType && originDirection != -1)
		{
			currentCombo = this.UseSkillAndDestroy(next, direction=1, combo=currentCombo+1);
		}

		Destroy(obj, delayedTime);
		return currentCombo;
    }



}
