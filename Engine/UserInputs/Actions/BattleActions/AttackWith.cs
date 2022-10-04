using System.Linq;

using System.Collections.Generic;
using Text_Based_Adventure.Engine.GameObjects.Items.Weapons;

namespace Text_Based_Adventure.Engine.UserInputs.BattleActions
{
    public class AttackWith : BattleAction
    {
        public override List<string> keyWord => new List<string>() { "attackwith" }; //TODO make 2 words work Also for multi person combat this won't work either

        public override int duration => 1;

        public override string HelpText()
        {
            return "You can type 'attackwith <WeaponName>' to attack with an equipped weapon";
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string weaponName = seperatedWords.Last(); // This might be an NPC name see above
            Weapon weapon = controller.playerController.player.weaponSlots.getWeapon(GameObjects.Creatures.WeaponSlot.RightHand);
            if(weapon != null)
            {
                controller.combatController.ResolveMeleeAttack(weapon, null);
            }
            else
            {
                Util.wl($"You don't have a {weaponName} equipped");
            }
        }

        public override void RespondToInput(GameController controller, string direcObject)
        {
            throw new System.NotImplementedException();
        }

        public override void RespondToInput(GameController controller)
        {
            throw new System.NotImplementedException();
        }
    }
}
