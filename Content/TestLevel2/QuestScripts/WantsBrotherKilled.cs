using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.InputActions;
using Text_Based_Adventure.Engine.Scripts;
using Text_Based_Adventure.GameObjects;
using System.Linq;

namespace Text_Based_Adventure.Content.TestLevel2.QuestScripts
{
    internal class WantsBrotherKilled : Script
    {

        private bool IsBrotherKilled = false; // TODO need to figure out how to save game.
        private bool QuestResolved = false;
        private bool QuestStarted = false;
        public override void onMessage(GameObject self, string messageId, string message, GameObject sender)
        {
            // When Brother is killed a message will be broadcast and this method will updat
        }

        public override void React(GameObject self, Verb action)
        {
            if(action is TalkTo)
            {
                Util.wl("What do you want?");
                //TODO make this more generic and add ability to inject new dialog based on quest start/end
                var options = new List<string>
                {
                    "1) Can you sell me something?",
                    "2) Do you need help with anything?",
                    "3) <Leave>"
                };
                int result = 0;
                while (result != 3)
                {
                    Util.fourthWall("Select an option via number");
                    options.ForEach(x => Util.wl(x));
                    bool parse = int.TryParse(Util.rl(), out result);
                    if (parse && Enumerable.Range(1, options.Count()).Contains(result))
                    {
                        if(result == 1)
                        {
                            Util.wl("No does that answer your question??");
                        }
                        if(result == 2)
                        {
                            Util.fourthWall("The Creepy Skeletor says...");
                            if (!IsBrotherKilled && !QuestStarted)
                            {
                                Util.wl("'I want to you to kill my brother hes a skeletor in the next room.'");
                                QuestStarted = true;
                            }
                            else if(!IsBrotherKilled)
                            {
                                Util.wl("Have you killed my brother yet?");
                            }
                            else if (!QuestResolved)
                            {
                                // TODO Quest Results?
                                Util.wl("You did it here is your reward.");
                                QuestResolved = true;
                            }
                            else
                            {
                                Util.wl("Thanks again for killing my brother for me.");
                            }
                        }
                    }
                    else
                    {
                        Util.fourthWall("You have to type a number to match the option you want");
                    }
                }
            }
            if(action is Attack)
            {
                Util.wl("I wouldn't try and attack me if I was you");
            }
        }

        public override void Update(GameObject self)
        {
            // Do nothing
        }
    }
}
