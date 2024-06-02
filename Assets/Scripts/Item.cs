using UnityEngine;
using Utilities;

namespace PaperPlane
{
    public abstract class Item : MonoBehaviour
    {
        //les champs pour les items
        [SerializeField] public int healthValue = 20;
    }
}