﻿namespace Zork
{
    public class CharMarkus: Player
    {
        public CharMarkus()
        {
            this.Bio = "Markus delar plats med Mimmi";
            this.Character = CharacterIs.Markus;
        }

        public override void CreateInventory()
        {
            throw new System.NotImplementedException();
        }
    }
}