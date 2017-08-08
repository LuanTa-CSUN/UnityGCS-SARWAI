using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrefab : SingletonBase<UIPrefab> {

    // Plan to use this to keep UI between individual drone scenes
    protected UIPrefab () {}

	public void Awake () {
        transform.Translate(transform.parent.position);
	}
}
