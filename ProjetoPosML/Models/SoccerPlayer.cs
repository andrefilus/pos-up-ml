using System;
namespace ProjetoPosML.Models
{
    public class SoccerPlayer
    {
        public float Hability { get; set; }
        public float Price { get; set; }

        public static SoccerPlayer[] getPlayers()
        {
            SoccerPlayer[] soccerPlayers =
            {
                new SoccerPlayer() { Hability = 88F, Price = 1400000F },
                new SoccerPlayer() { Hability = 64F, Price = 603000F },
                new SoccerPlayer() { Hability = 45F, Price = 230000F },
                new SoccerPlayer() { Hability = 93F, Price = 2100000F },
                new SoccerPlayer() { Hability = 87F, Price = 1300000F },
                new SoccerPlayer() { Hability = 71F, Price = 900000F },
                new SoccerPlayer() { Hability = 54F, Price = 430000F }
            };

            return soccerPlayers;
        }
    }
}
