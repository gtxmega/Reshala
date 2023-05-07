
namespace Data
{
    public enum EMathOperator
    {
        ADDING,
        SUBTRACT,
        MULTIPLY,
        DIVIDE,
    }

    [System.Serializable]
    public struct MathData
    {
        public int A;
        public EMathOperator Operator;
        public int B;
    }
}