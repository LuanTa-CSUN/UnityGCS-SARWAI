using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPrefab : SingletonBase<TerrainPrefab> {

    // May end up using this
	public Terrain baseTerrain;

	protected TerrainPrefab () {}

	void Awake () {
        transform.Translate(transform.parent.position);
	}
}
