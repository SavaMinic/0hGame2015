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
			renderer.material = container.materials[(int)Type];
		}
		else
		{
			renderer.material = container.materials[0];
		}
	}

	public static Color GetColor(TileType Type)
	{
		switch (Type)
		{
			case TileType.Green:
				return Color.green;
			case TileType.Red:
				return Color.red;
			case TileType.Blue:
				return Color.blue;
			case TileType.Yellow:
				return Color.yellow;
			case TileType.Orange:
				return new Color(0.9f, 0.5f, 0f);
		}
		return Color.blue;
	}

}
