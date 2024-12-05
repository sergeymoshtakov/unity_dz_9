using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Weapon.RangeWeapon;
using Zenject;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Enemy.Enemy> _enemies;

    private Player.Player _player;
    private RangeWeapon _rangeWeapon;

    public event UnityAction OnVictory;
    public event UnityAction OnLose;

    [Inject]
    private void Construct(Player.Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        _rangeWeapon = (RangeWeapon)_player.CurrentWeapon;
    }

    private void OnEnable()
    {
        _rangeWeapon.OnAmmoChanged += OnAmmoChanged;
    }

    // Use this for initialization
    void Start()
	{
        _enemies = new List<Enemy.Enemy>(FindObjectsOfType<Enemy.Enemy>());
    }

	// Update is called once per frame
	void Update()
	{
        var activeEnemies = _enemies.FindAll(enemy => enemy.gameObject.activeSelf);
        if (activeEnemies.Count == 0)
        {
            OnVictory?.Invoke();
        }
    }

    private void OnAmmoChanged(int maxAmmo, int totalAmmo)
    {
        var activeEnemies = _enemies.FindAll(enemy => enemy.gameObject.activeSelf);
        if (activeEnemies.Count != 0 && maxAmmo == 0)
        {
            OnLose?.Invoke();
        }
    }
}

