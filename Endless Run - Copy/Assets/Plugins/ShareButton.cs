using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShareButton : MonoBehaviour
{

	private string Message;
	public void ClickShareButton()
    {
		Message = " Mainkan Pengen Sarjana dan Kalahkan Score Ku ! \n\n Download gamenya disini! : \n";
		StartCoroutine(TakeScreenshotAndShare());
    }
	private IEnumerator TakeScreenshotAndShare()
	{
		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		// To avoid memory leaks
		Destroy(ss);
		
		/*new NativeShare().AddFile(filePath)
			.SetSubject("Subject goes here").SetText("Hello world!").SetUrl(" =LINK GAME= ")
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();*/

		new NativeShare().AddFile(filePath)
			.SetSubject("PENGEN SARJANA").SetText(Message).SetUrl("absurd869.itch.io/pengen-sarjana ").Share();

		// Share on WhatsApp only, if installed (Android only)
		//if( NativeShare.TargetExists( "com.whatsapp" ) )
		//	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
	}
}
