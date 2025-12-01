using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserSkill : MonoBehaviour
{
    private int score=0;
    private int defaultScore=10;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0)) 
        {
            GameObject target = CastRay();
            if(target != null)
            {
                target.transform.parent.GetComponent<UserSkillFunctions>().onClick(target.name);
                int combo = GameObject.Find("SkillSpawner").GetComponent<SkillSpawn>().UseSkillAndDestroy(target);
                UpdateScore(combo);

            }
        }
    }

    void UpdateScore(int combo=0)
    {
        int c = combo;
        this.score += (this.defaultScore * c * c);
        this.scoreText.text = "Score: " + this.score;
    }

    GameObject CastRay() 
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero, 0f);

        if (hit.collider != null) { 
            //Debug.Log("HI " + hit.collider.gameObject.name);
            return hit.collider.gameObject;  
        }
        else
        {
            return null;
        }
    }


}
