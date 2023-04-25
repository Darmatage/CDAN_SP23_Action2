using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerEchoReveal : MonoBehaviour{

       public Tilemap destructableTilemap;
       private List<Vector3> tileWorldLocations;
       public float rangeDestroy = 2f;
       //public bool canExplode = true;
       //public GameObject boomFX;
	   public Color colorGone;
	   public Color colorBack;

	public GameObject Tilemap_Lines;


       void Start(){
		   Tilemap_Lines.SetActive(false);
              TileMapInit();
       }

       void Update(){
              if ((Input.GetKeyDown("space"))&&(GameHandler_Lights.torchOn == false)&&(GameHandler_Lights.canEcho)){
				  Tilemap_Lines.SetActive(true);
                  destroyTileArea();
              }
       }

       void TileMapInit(){
              tileWorldLocations = new List<Vector3>();

              foreach (var pos in destructableTilemap.cellBounds.allPositionsWithin){
                     Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
                     Vector3 place = destructableTilemap.CellToWorld(localPlace) + new Vector3(0.5f, 0.5f, 0f);

                     if (destructableTilemap.HasTile(localPlace)){
                            tileWorldLocations.Add(place);
                     }
              }
       }
	   
	   public void TurnOffEchoLines(){
		   Tilemap_Lines.SetActive(false);
	   }

       void destroyTileArea(){
             foreach (Vector3 tile in tileWorldLocations){
                     if (Vector2.Distance(tile, transform.position) <= rangeDestroy){
                            //Debug.Log("in range");
                            Vector3Int localPlace = destructableTilemap.WorldToCell(tile);
                            if (destructableTilemap.HasTile(localPlace)){
                                   //StartCoroutine(BoomVFX(tile));
								   
								   //The default script, to set a tile at a position to null:
                                   //destructableTilemap.SetTile(destructableTilemap.WorldToCell(tile), null);
								   
									// Flag the tile, so it can change colour (By default it's set to "Lock Colour").
									// Tilemap.SetTileFlags(position, TileFlags.None);
									destructableTilemap.SetTileFlags(destructableTilemap.WorldToCell(tile), TileFlags.None);
								   
								   //change the color: Tilemap.SetColor(position, color);
								   destructableTilemap.SetColor(destructableTilemap.WorldToCell(tile), colorGone);
								   //NOTE: this successfully changes white to black but not the reverse...?
								   //BUT, can change transparency, so if we have TWO tilemaps, black on top and color below, we can make the top one temporarily invisiblw.
								   StartCoroutine(BringBackBlack(destructableTilemap.WorldToCell(tile)));
                            }
                     //tileWorldLocations.Remove(tile);
                     }
              }
       }

	IEnumerator BringBackBlack(Vector3Int position){
		yield return new WaitForSeconds(1f);
		destructableTilemap.SetColor(position, colorBack);
		
		/*
		float t = 0;
		
		while (t < 1){ // while t below the end limit...
			Color colorShift = Color.Lerp(colorGone, colorBack, t);
			destructableTilemap.SetColor(position, colorShift);
			// increment it at the desired rate every update:
			t += Time.deltaTime/5;
			Debug.Log("current LERP time: " + t);
			Debug.Log("current LERP color: " + colorShift);
		}
		*/
	}


       //IEnumerator BoomVFX(Vector3 tilePos){
              //GameObject tempVFX = Instantiate(boomFX, tilePos, Quaternion.identity);
              //yield return new WaitForSeconds(.5f);
              //Destroy(tempVFX);
       //}

       //NOTE: To help see the attack sphere in editor:
       void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(transform.position, rangeDestroy);
       }
}