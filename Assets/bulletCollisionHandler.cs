using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class bulletCollisionHandler : MonoBehaviour
{
	public int damage = 1;
	public bool isEnemy = false;
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.transform.CompareTag("Wall"))
		{
			Destroy(gameObject);
		}

		if(coll.transform.CompareTag("Block"))
		{
            var currX = coll.contacts[0].point.x<0 ? (int)coll.contacts[0].point.x - 1: (int)coll.contacts[0].point.x;
            var currY = coll.contacts[0].point.y<0 ? (int)coll.contacts[0].point.y - 1: (int)coll.contacts[0].point.y;
            Debug.Log(coll.contacts[0].point.x.ToString() + " "+ coll.contacts[0].point.y.ToString());
            coll.gameObject.GetComponent<Tilemap>().SetTile(new Vector3Int(currX, currY, 0), null);
			//Destroy(coll.transform.gameObject);
			Destroy(gameObject);
		}

		if(!isEnemy)
		{
			if(coll.transform.CompareTag("Enemy"))
			{
				//EnemyControl enemy = coll.transform.GetComponent<EnemyControl>();
				//enemy.HP -= damage;
				Destroy(gameObject);
			}
		}
		else
		{
			if(coll.transform.CompareTag("Player1"))
			{
				Player player = coll.transform.GetComponent<Player>();
				//player.HP -= damage;
				Destroy(gameObject);
			}
		}
	}
}
