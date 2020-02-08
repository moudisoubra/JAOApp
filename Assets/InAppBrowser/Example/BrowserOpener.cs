using UnityEngine;
using System.Collections;

public class BrowserOpener : MonoBehaviour {

	public string pageTitle;
	public string pageToOpen;

	// check readme file to find out how to change title, colors etc.
	public void OnButtonClicked() {
		InAppBrowser.DisplayOptions options = new InAppBrowser.DisplayOptions();
		options.displayURLAsPageTitle = false;
		options.pageTitle = pageTitle;

		InAppBrowser.OpenURL(pageToOpen, options);
		Debug.Log("HERE ");
	}

	public void OnClearCacheClicked() {
		InAppBrowser.ClearCache();
	}
}
