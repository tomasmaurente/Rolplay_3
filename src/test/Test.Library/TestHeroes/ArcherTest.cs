using NUnit.Framework;
using System;
using RoleplayGame;

namespace Test.Library
{
    public class ArcherTest 
    {
        private Archer archerProof;
        private Bow bow;
        private Helmet helmet;

        [SetUp]
        public void Setup()
        { 
            // Arrange.
            this.archerProof = new Archer("Legolas");
            this.bow = new Bow();
            this.helmet = new Helmet();

            

        }

        // Se testea valor de ataque.
        [Test]
        public void TestAttackValue()
        {
            // Act.
            this.archerProof.AddItem(this.bow);
            // Assert.
            Assert.AreEqual(15,archerProof.AttackValue);
        }

        // Se testea valor de defensa con casco.
        [Test]
        public void TestDefenseValue()
        {
            // Arrange.
            this.archerProof.AddItem(this.helmet);
            // Assert.
            Assert.AreEqual(18,archerProof.DefenseValue);
        }

        // Se testea el metodo ReceiveAttack.
        // Caso de numero negativo, se espera que no se modifique la salud.
        [Test]
        public void TestReceiveNegativeAttack()
        {
            // Arrange.
            this.archerProof.AddItem(this.helmet);

            // Act.
            int healthBeforeAttack = archerProof.Health;
            archerProof.ReceiveAttack(-1);
            int healthAfterAttack = archerProof.Health;

            // Assert.
            Assert.AreEqual(healthBeforeAttack,healthAfterAttack);
        }

        // Se testea la salud despues de un ataque.
        [Test]
        public void TestHealthWithLittleAttack()
        {
            // Arrange.
            Dwarf dwarf = new Dwarf("Pipin");
            Axe axe = new Axe();
            dwarf.AddItem(axe);
            this.archerProof.AddItem(helmet);
            
            // Act.
            archerProof.ReceiveAttack(dwarf.AttackValue);

            // Assert.
            Assert.AreEqual(93, archerProof.Health);
        }

        // Se testea la salud despues de un ataque.
        // La vida cambia ya que su defensa es menor que el ataque, y ademas en este caso deberia ser 0 y no menor.
        [Test]
        public void TestHealthWithEnourmousAttack()
        {
            // Arrange.
            archerProof.AddItem(helmet);

            // Act.
            archerProof.ReceiveAttack(500);

            // Assert.
            Assert.Zero(archerProof.Health);
        }

        // Se testea la salud despues de un ataque que mate al personaje y una curación.
        [Test]
        public void TestHealthAfterCure()
        {
            // Arrange.
            archerProof.AddItem(helmet);

            // Act.
            archerProof.ReceiveAttack(10000);
            archerProof.Cure();

            // Assert.
            Assert.AreEqual(100, archerProof.Health);   
        }

        // Se testea la salud despues de un ataque que no mate al personaje y una curación.
        [Test]
        public void TestHealthAfterCure2()
        {
            // Arrange.
            archerProof.AddItem(helmet);

            // Act.
            archerProof.ReceiveAttack(60);
            archerProof.Cure();

            // Assert.
            Assert.AreEqual(100, archerProof.Health);   
        }
    }
}