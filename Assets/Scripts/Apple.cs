using UnityEngine;

namespace Snake
{
    public class Apple : MonoBehaviour
    {
        private string _name = "Apple";

        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
}