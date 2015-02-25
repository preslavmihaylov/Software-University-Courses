namespace Infestation
{
    using Models.Units;
    using Supplements;

    class ModifiedHoldingPen : HoldingPen
    {
        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Attack:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);

                    targetUnit.DecreaseBaseHealth(interaction.SourceUnit.Power);
                    break;
                case InteractionType.Infest:
                    targetUnit = this.GetUnit(interaction.TargetUnit);
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Dog":
                    var dog = new Dog(commandWords[2]);
                    this.InsertUnit(dog);
                    break;
                case "Human":
                    var human = new Human(commandWords[2]);
                    this.InsertUnit(human);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var target = this.GetUnit(commandWords[2]);

            switch (commandWords[1])
            {
                case "AggressionCatalyst":
                    var aggressionCatalyst = new AggressionCatalyst();
                    target.AddSupplement(aggressionCatalyst);
                    break;
                case "HealthCatalyst":
                    var healthCatalyst = new HealthCatalyst();
                    target.AddSupplement(healthCatalyst);
                    break;
                case "PowerCatalyst":
                    var powerCatalyst = new PowerCatalyst();
                    target.AddSupplement(powerCatalyst);
                    break;
                case "Weapon":
                    var weapon = new Weapon();
                    target.AddSupplement(weapon);
                    break;
                default:
                    break;
            }
        }

    }
}
