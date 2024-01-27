using UnityEngine;

namespace Assets.Scripts.Domain.Utils.Raycaster
{
    public static class Raycaster
    {
        private static Ray _ray;
        private static RaycastHit _hit;
        private static float _maxDistance = 100f;

        public static bool CheckHit(GameObject gameObject)
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit, _maxDistance))
            {
                if (_hit.transform != null && _hit.transform.gameObject != gameObject)
                    return false;
                else
                    return true;
            }
            return false;
        }
    }
}
