using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class DwarfTests
    {
        private Dwarf dwarfProof;
        public Axe axe;
        private Shield shield;
        private Helmet helmet;

        [SetUp]
        public void Setup()
        { 
            // Arrange.
            this.dwarfProof = new Dwarf("Carlos");
            this.axe = new Axe();
            this.helmet = new Helmet();
            this.shield = new Shield();

        }

        // Se testea valor de ataque.
        [Test]
        public void TestAttackValue()
        {
            // Act.
            dwarfProof.AddItem(axe);
            // Assert.
            Assert.AreEqual(25,dwarfProof.AttackValue);
        }

        // Se testea valor de defensa con escudo y casco, ya que el codigo no permite tener uno y no otro, o ninguno.
        [Test]
        public void TestDefenseValue()
        {
            // Arrange.
            dwarfProof.AddItem(shield);
            dwarfProof.AddItem(helmet);
            // Assert.
            Assert.AreEqual(32,dwarfProof.DefenseValue);
        }

        // Se testea el metodo ReceiveAttack.
        // Caso de numero negativo, se espera que no se modifique la salud.
        [Test]
        public void TestReceiveNegativeAttack()
        {
            // Arrange.
            dwarfProof.AddItem(shield);
            dwarfProof.AddItem(helmet);

            // Act.
            int healthBeforeAttack = dwarfProof.Health;
            dwarfProof.ReceiveAttack(-10000);
            int healthAfterAttack = dwarfProof.Health;

            // Assert.
            Assert.AreEqual(healthBeforeAttack,healthAfterAttack);
        }

        // Se testea la salud despues de un ataque.
        // La vida sigue intacta debido a que su defensa es mayor que el ataque.
        [Test]
        public void TestHealthWithLittleAttack()
        {
            // Arrange.
            Knight knight = new Knight("Batman");
            Sword Sword = new Sword();
            dwarfProof.AddItem(shield);
            dwarfProof.AddItem(helmet);
            
            // Act.
            dwarfProof.ReceiveAttack(knight.AttackValue);

            // Assert.
            Assert.AreEqual(100, dwarfProof.Health);
        }

        // Se testea la salud despues de un ataque.
        // La vida cambia ya que su defensa es menor que el ataque.
        [Test]
        public void TestHealthWithBigAttack()
        {
            // Arrange.
            Wizard gandalf = new Wizard("Gandalf");
            gandalf.AddItem(new Staff());

            dwarfProof.AddItem(shield);
            dwarfProof.AddItem(helmet);
            
            // Act.
            dwarfProof.ReceiveAttack(gandalf.AttackValue);

            // Assert.
            Assert.Less(dwarfProof.Health,100);
        }

        // Se testea la salud despues de un ataque.
        // La vida cambia ya que su defensa es menor que el ataque, y ademas en este caso deberia ser 0 y no menor.
        [Test]
        public void TestHealthWithEnourmousAttack()
        {
            // Arrange.
            dwarfProof.AddItem(shield);
            dwarfProof.AddItem(helmet);

            // Act.
            dwarfProof.ReceiveAttack(10000);

            // Assert.
            Assert.Zero(dwarfProof.Health);
        }

        // Se testea la salud despues de un ataque que mate al personaje y una curación.
        [Test]
        public void TestHealthAfterCure()
        {
            // Arrange.
            dwarfProof.AddItem(shield);
            dwarfProof.AddItem(helmet);

            // Act.
            dwarfProof.ReceiveAttack(10000);
            dwarfProof.Cure();

            // Assert.
            Assert.AreEqual(100, dwarfProof.Health);   
        }

        // Se testea la salud despues de un ataque que no mate al personaje y una curación.
        [Test]
        public void TestHealthAfterCure2()
        {
            // Arrange.
            dwarfProof.AddItem(shield);
            dwarfProof.AddItem(helmet);

            // Act.
            dwarfProof.ReceiveAttack(60);
            dwarfProof.Cure();

            // Assert.
            Assert.AreEqual(100, dwarfProof.Health);   
        }
    }
}