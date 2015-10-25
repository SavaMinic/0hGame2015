using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TileContainer : MonoBehaviour
{

	public LayerMask clickableLayers;

	public Material[] materials;

	public Text infoText;
	public Button newGameButton;
	public Text translationText;

	private Tile[] tiles;

	private Tile.TileType selectedType = 0;

	public bool startedGame = false;

	private string[] poems = 
	{
		"From time to time\n\nThe clouds give rest\n\nTo the moon-beholders.",
		"Consider me\n\nAs one who loved poetry\n\nAnd persimmons.",
		"Blowing from the west\n\nFallen leaves gather\n\nIn the east.",
		"Don’t weep, insects –\n\nLovers, stars themselves,\n\nMust part.",
		"An old silent pond...\n\nA frog jumps into the pond,\n\nsplash! Silence again.",
		"Over the wintry\n\nforest, winds howl in rage\n\nwith no leaves to blow.",
		"Toward those short trees\n\nWe saw a hawk descending\n\nOn a day in spring.",
		"In the twilight rain\n\nthese brilliant-hued hibiscus -\n\nA lovely sunset",
		"The lamp once out\n\nCool stars enter\n\nThe window frame.",
	};

	public Tile GetTile(int x, int y)
	{
		x = Mathf.Clamp(x, 0, 3);
		y = Mathf.Clamp(y, 0, 3);
		return tiles[x*4 + y];
	}

	protected void Start()
	{
		tiles = GetComponentsInChildren<Tile>();
		//StartCoroutine(GenerateTiles());
		infoText.text = "CONNECTED WORLDS";
		infoText.color = Color.black;
	}

	public void OnNewGameClick()
	{
		translationText.color = Color.black;
		translationText.text = "Translation\nIN PROGRESS";
		StartCoroutine(GenerateTiles());
	}

	protected void Update()
	{
		if (Input.GetMouseButtonDown(0) && startedGame)
		{
			RaycastHit hitInfo;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, clickableLayers))
			{
				var tile = hitInfo.collider.GetComponent<Tile>();
				if (tile != null && tile.Type > 0)
				{
					tile.IsVisible = !tile.IsVisible;
					if (selectedType == 0)
					{
						selectedType = tile.Type;
					}
					else if (tile.Type == selectedType)
					{
						StartCoroutine(CheckForFinish());
					}
					else
					{
						StartCoroutine(Fail());
					}
				}
			}
		}
	}

	public IEnumerator GenerateTiles()
	{
		newGameButton.enabled = false;
		infoText.text = "Memorize board";
		infoText.color = Color.black;
		selectedType = 0;
		for (int i = 0; i < tiles.Length; i++)
		{
			tiles[i].IsVisible = true;
			tiles[i].Type = (Tile.TileType) Random.Range(0, 5);
		}
		yield return new WaitForSeconds(2f);
		infoText.text = "Tap only one type";
		startedGame = true;
		for (int i = 0; i < tiles.Length; i++)
		{
			tiles[i].IsVisible = false;
		}
	}

	private IEnumerator CheckForFinish()
	{
		bool isFinished = true;
		for (int i = 0; i < tiles.Length; i++)
		{
			if (tiles[i].Type == selectedType && !tiles[i].IsVisible)
			{
				isFinished = false;
				break;
			}
		}
		if (isFinished)
		{
			startedGame = false;
			infoText.text = "CONNECTED WORLDS";
			infoText.color = Color.black;

			translationText.color = Tile.GetColor(selectedType);
			translationText.text = poems[Random.Range(0, poems.Length - 1)];

			yield return new WaitForSeconds(0.5f);
			RevealTiles();
			newGameButton.enabled = true;
		}
	}

	private IEnumerator Fail()
	{
		startedGame = false;
		infoText.text = "CONNECTED WORLDS";
		infoText.color = Color.black;

		translationText.color = Color.red;
		translationText.text = "Translation\nFAILED!";

		yield return new WaitForSeconds(0.5f);
		RevealTiles();
		newGameButton.enabled = true;
	}

	private void RevealTiles()
	{
		for (int i = 0; i < tiles.Length; i++)
		{
			tiles[i].IsVisible = true;
		}
	}
}
