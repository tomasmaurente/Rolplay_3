namespace RoleplayGame
{
    public class Joker : AbstractEnemy
    {
        public Joker(string name)
        :base(name)
        {
        }
        public override int Points
        {
            get
            {
                return 69;
            }
        }
    }
}