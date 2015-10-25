using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileContainer : MonoBehaviour
{

	public LayerMask clickableLayers;

	public Texture[] textures;

	private Tile[] tiles;

	public Tile GetTile(int x, int y)
	{
		x = Mathf.Clamp(x, 0, 3);
		y = Mathf.Clamp(y, 0, 3);
		return tiles[x*4 + y];
	}

	protected void Start()
	{
		tiles = GetComponentsInChildren<Tile>();
		for (int i = 0; i < tiles.Length; i++)
		{
			tiles[i].IsVisible = false;
		}
	}

	protected void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, clickableLayers))
			{
				Debug.Log("CLICK");
				var tile = hitInfo.collider.GetComponent<Tile>();
				if (tile != null)
				{
					Debug.Log("TILE");
					tile.IsVisible = !tile.IsVisible;
				}
			}
		}
	}
}
