using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStuff : MonoBehaviour {

	public bool can;
	public bool onNormalBox;
	public bool click;
	public bool reverse;

	public bool gameActive;

	public GameObject damNum;

	public Vector3 playerPosition;
	public int monstersSlain;
	public int comboDamage;
	public int health;
	public int maxHealth;
	public int combo;
	public int minDamage;
	public int maxDamage;
	public int damage;

	public TextMesh playerDam;
	public TextMesh enemyDam;
	public TextMesh txtcombo;
	public TextMesh txtcomboDamage;
	public TextMesh txtplayerHealth;
	public TextMesh txtenemyHealth;

	public GameObject healthBar;
	public GameObject enHealthBar;
	public Vector3 enemyPosition;
	public int enemyHealth;
	public int enemyMaxHealth;
	public string[] ennames;
	public string enname;
	public int enminDamage;
	public int enmaxDamage;
	public Sprite enemy;
	public int enDamage;


	public SpriteRenderer player;
	public Sprite attacking;
	public Sprite still;
	public int boxCount = 0 ;
	public GameObject box;
	public GameObject enemyBox;
    //public bool canAttack = false;

    // Use this for initialization

    void Start () {
		gameActive = true;
		update ();
		StartCoroutine (thing ());
		StartCoroutine (enemyBoxSpawn ());

	}
	
	// Update is called once per frame
	void Update () {
		can = false;
		onNormalBox = false;
	}

	void update()
	{
		playerDam.text = ("Damage: " + minDamage + " - " + maxDamage);
		enemyDam.text = ("Damage: " + enminDamage + " - " + enmaxDamage);
		txtplayerHealth.text = (health + "/" + maxHealth);
		txtenemyHealth.text = (enemyHealth + "/" + enemyMaxHealth);
		txtcomboDamage.text = ("Combo DMG: " + comboDamage);
		txtcombo.text = ("" + combo);
		healthBar.transform.localScale = new Vector3 (1.0f * health / maxHealth * 3, 2, 0);
		enHealthBar.transform.localScale = new Vector3 (1.0f * enemyHealth / enemyMaxHealth * 3, 2, 0);

	}

	public void attack()
	{
		
			combo++;
			txtcombo.text = ("" + combo);
			int dam = Random.Range (minDamage, maxDamage);
		if (enemyHealth - dam <= 0) {
			enemyHealth = 0;
			enemyDie ();

		} else 
			enemyHealth = enemyHealth - dam;
			txtenemyHealth.text = (enemyHealth + "/" + enemyMaxHealth);
			damNum.GetComponent<TextMesh> ().text = ("" + dam);
			Instantiate (damNum, enemyPosition, new Quaternion (0, 0, 0, 0));
			update ();



	}

	public void useCombo()
	{
		if (combo >= 5)
			reverse = true;
		StartCoroutine (comboThing ());
		

	}

	public IEnumerator comboThing()
	{
		

			int dam = comboDamage;
			if (enemyHealth - dam <= 0) {
				enemyHealth = 0;
				enemyDie ();
			}
			else
				enemyHealth = enemyHealth - dam;
			damNum.GetComponent<TextMesh> ().text = (""+dam);
			Instantiate (damNum, enemyPosition, new Quaternion(0,0,0,0));
		update ();

			yield return new WaitForSeconds (.04f);
		if (combo > 0) {
			StartCoroutine (comboThing ());
			combo--;
			txtcombo.text = ("" + combo);
			if (combo==0)
				reverse = false;
		}

	}

	public void takeDamage ()
	{
		int dam = Random.Range(enminDamage, enmaxDamage);
		if (health - dam <= 0) {
			health = 0;

			die ();
		}
		else 
			health -= dam;
			damNum.GetComponent<TextMesh> ().text = ("" + dam);
			Instantiate (damNum, playerPosition, new Quaternion (0, 0, 0, 0));
		update ();

	}

	public void enemyDie()
	{
		gameActive = false;
	}

	public void die()
	{
		gameActive = false;

	}

	public void OnMouseDown() {
        if (gameActive)
        {

                if (can)
                    click = true;
                else
                    takeDamage();
           
        }
	}




	IEnumerator attackAnimation()
	{
		player.sprite = attacking;
		yield return new WaitForSeconds (.1f);
		player.sprite = still;
	}

	public void thin()
	{
	StartCoroutine(thing());
	}

	IEnumerator thing()
	{
		if (gameActive) {
			if (boxCount < 7) {
				float val = (float)(Random.Range (8, 20) * 1.0 / 10.0);
				yield return new WaitForSeconds (val);
				boxCount++;
				float value2 = (Random.Range (-70, 70)) / 10.0f;
				Instantiate (box, new Vector3 (value2, -2.62f, 0), new Quaternion (0, 0, 0, 0));
				StartCoroutine (thing ());
			}
		}
	}

	IEnumerator enemyBoxSpawn()
	{
		if (gameActive) {
			float val = (float)(Random.Range (14, 24) * 1.0 / 10.0);
			yield return new WaitForSeconds (val);

			Instantiate (enemyBox, new Vector3 (7, -2.62f, 0), new Quaternion (0, 0, 0, 0));
			StartCoroutine (enemyBoxSpawn ());
		}

	}


}
