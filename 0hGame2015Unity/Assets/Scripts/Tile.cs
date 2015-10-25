using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{

	public enum TileType
	{
		Green = 0,
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
		Color color;
		if (IsVisible)
		{
			switch (Type)
			{
				case TileType.Green:
					color = Color.yellow;
					break;
				case TileType.Red:
					color = Color.yellow;
					break;
				case TileType.Blue:
					color = Color.yellow;
					break;
				case TileType.Yellow:
					color = Color.yellow;
					break;
				case TileType.Orange:
					color = Color.yellow;
					break;
				default:
					color = Color.white;
					break;
			}
			renderer.material.mainTexture = container.textures[(int)Type];
		}
		else
		{
			color = Color.black;
			renderer.material.mainTexture = null;
		}
		renderer.material.color = color;
	}

}
