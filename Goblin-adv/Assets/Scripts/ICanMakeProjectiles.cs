using UnityEngine;

namespace DefaultNamespace
{
    public interface ICanMakeProjectiles
    {
        float projectileSpeed { set; get; }
        GameObject projectile { set; get; }
    }
}