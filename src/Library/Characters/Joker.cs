namespace RoleplayGame
{
    public class Joker : AbstractEnemy
    {
        public override int Points
        {
            get
            {
                return 69;
            }
        }
        public Joker(string name)
        :base(name)
        {
        }

    }
}