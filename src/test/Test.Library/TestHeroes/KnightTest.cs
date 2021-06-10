using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class KnightTest
    {
        private Knight knightProof;
        public Sword sword;
        private Shield shield;
        private Armor armor;

        [SetUp]
        public void Setup()
        { 
            // Arrange.
            this.knightProof = new Knight("Aragon");
            this.sword = new Sword();
            this.armor = new Armor();
            this.shield = new Shield();
        }

        // Se testea valor de ataque.
        [Test]
        public void TestAttackValue()
        {
            // Act.
            knightProof.AddItem(sword);
            // Assert.
            Assert.AreEqual(20,knightProof.AttackValue);
        }

        // Se testea valor de defensa con escudo y casco, ya que el codigo no permite tener uno y no otro.
        [Test]
        public void TestDefenseValue()
        {
            // Arrange.
            knightProof.AddItem(shield);
            knightProof.AddItem(armor);
            // Assert.
            Assert.AreEqual(39,knightProof.DefenseValue);
        }

        // Se testea el metodo ReceiveAttack.
        // Caso de numero negativo, se espera que no se modifique la salud.
        [Test]
        public void TestReceiveNegativeAttack()
        {
            // Arrange.
            knightProof.AddItem(shield);
            knightProof.AddItem(armor);

            // Act.
            int healthBeforeAttack = knightProof.Health;
            knightProof.ReceiveAttack(-1);
            int healthAfterAttack = knightProof.Health;

            // Assert.
            Assert.AreEqual(healthBeforeAttack,healthAfterAttack);
        }

        // Se testea la salud despues de un ataque.
        // La vida sigue intacta debido a que su defensa es mayor que el ataque.
        [Test]
        public void TestHealthWithLittleAttack()
        {
            // Arrange.
            Archer archer = new Archer("Legolas");
            Bow bow = new Bow();
            archer.AddItem(bow);
            knightProof.AddItem(shield);
            knightProof.AddItem(armor);
            
            // Act.
            knightProof.ReceiveAttack(archer.AttackValue);

            // Assert.
            Assert.AreEqual(100, knightProof.Health);
        }

        // Se testea la salud despues de un ataque.
        // La vida cambia ya que su defensa es menor que el ataque.
        [Test]
        public void TestHealthWithBigAttack()
        {
            // Arrange.
            Wizard merlin = new Wizard("Merlin");
            merlin.AddItem(new Staff());

            knightProof.AddItem(shield);
            knightProof.AddItem(armor);
            
            // Act.
            knightProof.ReceiveAttack(merlin.AttackValue);

            // Assert.
            Assert.Less(knightProof.Health,100);
        }

        // Se testea la salud despues de un ataque.
        // La vida cambia ya que su defensa es menor que el ataque, y ademas en este caso deberia ser 0 y no menor.
        [Test]
        public void TestHealthWithEnourmousAttack()
        {
            // Arrange.
            knightProof.AddItem(shield);
            knightProof.AddItem(armor);

            // Act.
            knightProof.ReceiveAttack(10000);

            // Assert.
            Assert.Zero(knightProof.Health);
        }

        // Se testea la salud despues de un ataque que mate al personaje y una curación.
        [Test]
        public void TestHealthAfterCure()
        {
            // Arrange.
            knightProof.AddItem(shield);
            knightProof.AddItem(armor);

            // Act.
            knightProof.ReceiveAttack(10000);
            knightProof.Cure();

            // Assert.
            Assert.AreEqual(100, knightProof.Health);   
        }

        // Se testea la salud despues de un ataque que no mate al personaje y una curación.
        [Test]
        public void TestHealthAfterCure2()
        {
            // Arrange.
            knightProof.AddItem(shield);
            knightProof.AddItem(armor);

            // Act.
            knightProof.ReceiveAttack(60);
            knightProof.Cure();

            // Assert.
            Assert.AreEqual(100, knightProof.Health);   
        }
    }
}