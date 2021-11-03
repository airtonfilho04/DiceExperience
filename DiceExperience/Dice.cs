namespace DiceExperience
{
    class Dice
    {
        public int[] _diceSides;

        public Dice()
        {
            _diceSides = new int[6] { 1, 2, 3, 4, 5, 6 };
        }

        public int GetDiceSide(int i)
        {
            return _diceSides[i];
        }
    }
}
