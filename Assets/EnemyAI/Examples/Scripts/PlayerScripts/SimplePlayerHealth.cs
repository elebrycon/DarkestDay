using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class is created for the example scene. There is no support for this script.
public class SimplePlayerHealth : HealthManager
{
	public float health = 100f;
	public string healthText = "Health: ";

	public Transform canvas;
	public GameObject hurtPrefab;
	public float decayFactor = 0.8f;

	private HurtHUD hurtUI;
    public GameObject LoseScreen;

    private void Start()
	{
		AudioListener.pause = false;
		hurtUI = this.gameObject.AddComponent<HurtHUD>();
		hurtUI.Setup(canvas, hurtPrefab, decayFactor, this.transform);
	}

	public override void TakeDamage(Vector3 location, Vector3 direction, float damage, Collider bodyPart, GameObject origin)
	{
		health -= damage;

		if (hurtPrefab && canvas)
			hurtUI.DrawHurtUI(origin.transform, origin.GetHashCode());
	}

	public void OnGUI()
	{
        if (health > 0f)
        {
            GUIStyle textStyle = new GUIStyle
            {
                fontSize = 50
            };
            textStyle.normal.textColor = Color.white;

            float labelWidth = 100;
            float labelHeight = 60;

            
            GUI.Label(new Rect(Screen.width - labelWidth - 10, Screen.height - labelHeight - 10, labelWidth, labelHeight), health.ToString(), textStyle);
            GUI.Label(new Rect(Screen.width - labelWidth - 180, Screen.height - labelHeight - 10, labelWidth, labelHeight), healthText, textStyle);
        }
        else if (!dead)
		{
            dead = true;
            StartCoroutine(ReloadScene());
        }
	}

    private IEnumerator ReloadScene()
	{
        SendMessage("PlayerDead", SendMessageOptions.DontRequireReceiver);
        yield return new WaitForSeconds(0.5f);
		canvas.gameObject.SetActive(false);
		AudioListener.pause = true;
		Camera.main.clearFlags = CameraClearFlags.SolidColor;
		Camera.main.backgroundColor = Color.black;
		Camera.main.cullingMask = LayerMask.GetMask();
        LoseScreen.SetActive(true);
        yield return new WaitForSeconds(2);

		SceneManager.LoadScene(1);
	}
}