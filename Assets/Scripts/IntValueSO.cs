using UnityEngine;

[CreateAssetMenu(fileName = "IntName", menuName = "IntValueSO/IntName")]
public class IntValueSO : ScriptableObject
{
    [SerializeField] private int value;

    public delegate void OnValueChange(int value);
    public event OnValueChange onValueChange;

    public int Value
    {
        get { return this.value; }
        set
        {
            this.value = value;
            onValueChange?.Invoke(this.value);
        }
    }
}
