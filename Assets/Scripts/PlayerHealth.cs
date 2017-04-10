using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;                            // 游戏初始生命值
	public int currentHealth;                                   // 当前生命值
	public Slider healthSlider;                                 // 界面生命值的UI
	public Slider shieldSlider;
	public int currentShield;
	public GameObject shieldOnImg;
	public Image damageImage;                                   
	public float flashSpeed = 5f;                               //损害后颜色变化的速度
	public Color flashColour = new Color(1f, 0f, 0f, 1f);       //设置受到损害后生命值UI显示红色 

	bool isDead;                                                // 是否死亡
	bool damaged;                                               // 是否受到伤害

	private GameController gameController;
	public GameObject player;
	public Collider playerPower;
	private float countDownTime;
	private TutorialGameOverInfo tutorialGameOverInfo;

	void Awake ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		} 
	
		if (gameController == null){
			Debug.Log ("Cannot find GameController");
		}
		GameObject playerPowerObject = GameObject.FindWithTag ("Player");
		if (playerPowerObject != null) {
			playerPower = playerPowerObject.GetComponent <Collider> ();
		} 
		
		if (playerPowerObject == null){
			Debug.Log ("Cannot find playerPowerObjects");
		}
		// 设置初始数据
		currentHealth = startingHealth;
		currentShield = 0;
	}
	void Start()
	{
		GameObject gameOverObject = GameObject.FindGameObjectWithTag ("gameOverObject");
		if (gameOverObject != null)
		{
			tutorialGameOverInfo = gameOverObject.GetComponent <TutorialGameOverInfo>();
		}
		if (tutorialGameOverInfo == null)
		{
			Debug.Log ("Cannot find 'TutorialGameOverInfo' script");
		}
	}
	
	void Update ()
	{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);

	}
	
	public void TakeDamage (int amount)
	{
		
		currentHealth -= amount;

		healthSlider.value = currentHealth;

		if(currentHealth <= 0 && !isDead)
		{
			Death ();
			gameController.GameOver ();
			//显示游戏结束界面
			tutorialGameOverInfo.ShowGameOverScreen ();
		}
	}
		
	/*预留方法，等添加增加生命值的道具后可用
		public void AddHealth (int amount){
			if (currentHealth < startingHealth) {
				currentHealth += amount;
				healthSlider.value = currentHealth;
			}
		}
	*/
	void Death ()
	{
		isDead = true;
	}       
}