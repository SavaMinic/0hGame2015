using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{

	public enum TileType
	{
		Green = 1,
		Red,
		Blue,
		Yellow,
		Orange
	};

	public bool IsVisible;
	public TileType Type = TileType.Yellow;

	private Renderer renderer;
	private TileContainer container;

	protected void Start()
	{
		renderer = GetComponent<Renderer>();
		container = FindObjectOfType<TileContainer>();
	}

	protected void Update()
	{
		if (IsVisible)
		{
			switch (Type)
			{
				case TileType.Green:
					break;
				case TileType.Red:
					break;
				case TileType.Blue:
					break;
				case TileType.Yellow:
					break;
				case TileType.Orange:
					break;
				default:
					break;
			}
			renderer.material = container.materials[(int)Type];
		}
		else
		{
			renderer.material = container.materials[0];
		}
	}

}
