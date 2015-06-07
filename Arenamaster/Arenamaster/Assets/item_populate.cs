﻿using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Collections.Generic;

public class item_populate : MonoBehaviour {


	public int id; // unique id generated by this class 


	public Dictionary<string, GameObject> itemsDict = new Dictionary<string, GameObject>();

	void Start () {

		id = 0;

		XmlReader reader = XmlReader.Create ("assets/items.xml");
		while (reader.Read()) {
			if( (reader.IsStartElement("item"))  ){
				id++;
				GameObject item = Instantiate(Resources.Load("item")) as GameObject;

				string uid = reader.GetAttribute("bid") + id;

				item.name =  uid;

				item.GetComponent<item_script>().bid = reader.GetAttribute("bid");
				item.GetComponent<item_script>().uid = uid;

				item.GetComponent<item_script>().itemname = reader.GetAttribute("name");
				item.GetComponent<item_script>().examine = reader.GetAttribute("examine");
				item.GetComponent<item_script>().type = reader.GetAttribute("type");

				itemsDict.Add( reader.GetAttribute("bid")   , item);
			}
		}

		/*foreach (KeyValuePair<string, GameObject> entry in itemsDict) {
			Debug.Log(entry);
		}*/


	}


	void Update () {
	
	}
}
