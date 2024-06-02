using UnityEngine;

namespace PaperPlane
{
    public class PlayerWeapon : Weapon
    {
        private InputReader _input;
        private float _fireTimer;
        private bool _isMainNull;
        private Camera _cam;

        private void Awake()
        {
            _fireTimer = weaponStrategy.FireRate;
            _cam = Camera.main;
            _isMainNull = _cam == null;
            _input = GetComponent<InputReader>();
        }

        private void Update()
        {
            _fireTimer += Time.deltaTime;

            if (_fireTimer > weaponStrategy.FireRate)
            {
                if (_input.FireP2 && !isTurret)
                {
                    foreach (var t in firePoint)
                    {
                        weaponStrategy.Fire(t, layer: layer, false);
                    }

                    _fireTimer = 0f;
                }
                else if (_input.FireP1 && isTurret)
                {
                    //if the mouse is below the player fire else don't
                    if (!_isMainNull && (_cam.ScreenToWorldPoint(Input.mousePosition).y < transform.position.y))
                    {
                        foreach (var t in firePoint)
                        {
                            weaponStrategy.Fire(t, layer: layer, true);
                        }
                    }
                    _fireTimer = 0f;
                }
            }
        }
    }
}