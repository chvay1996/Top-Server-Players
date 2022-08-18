using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top_Server_Players
{
    class Program
    {
        static void Main ( string [] args )
        {
            Server server = new Server ();
            server.Wroks ();
        }
    }

    class Server
    {
        private List<Player> _players = new List<Player> ();

        public Server ()
        {
            _players.Add ( new Player ( "Req", 99 , 550 ) );
            _players.Add ( new Player ( "Germes", 70 , 700 ) );
            _players.Add ( new Player ( "Trop", 80 , 500) );
            _players.Add ( new Player ( "Greg", 88 , 600 ) );
            _players.Add ( new Player ( "Rrty", 76 , 324) );
            _players.Add ( new Player ( "Rhsfdg", 98 , 547 ) );
            _players.Add ( new Player ( "Tfjwer", 95 , 657 ) );
            _players.Add ( new Player ( "Lsdhr", 21 , 111 ) );
            _players.Add ( new Player ( "Ldh", 44 ,432 ) );
            _players.Add ( new Player ( "EWgae", 56 ,454 ) );
        }

        public void Wroks ()
        {
            bool isWork = true;
            string input;

            while ( isWork == true )
            {
                Console.WriteLine ("Выбирете действие!" +
                    "\n1 - Показать топ 3х игроков по силе." +
                    "\n2 - Показать топ 3х игроков по уровню." +
                    "\n3 - Показать список всех игроков." +
                    "\n4 - Exit");
                input = Console.ReadLine ();

                switch ( input )
                {
                    case "1":
                        TopPower ();
                        break;
                    case "2":
                        TopLvl ();
                        break;
                    case "3":
                        ShowServer ();
                        break;
                    case "4":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine ("Кмх... Что-то пошло не так!");
                        break;
                }
                Console.ReadLine ();
                Console.Clear ();
            }
        }

        private void TopPower ()
        {
            byte numberPlayer = 3;
            Console.WriteLine ( $"\nТоп {numberPlayer} игроков по силе\n" );

            var TopPlayersFound = _players.OrderByDescending ( Player => Player.Power).Take ( numberPlayer ).ToList ();
            ShowInfo ( TopPlayersFound );
        }

        private void TopLvl ()
        {
            byte numberPlayer = 3;
            Console.WriteLine ($"\nТоп {numberPlayer} игроков по Lvl\n");

            var TopPlayersFound = _players.OrderByDescending ( Player => Player.Lvl ).Take ( numberPlayer ).ToList ();
            ShowInfo ( TopPlayersFound );

        }

        private void ShowInfo ( List<Player> players )
        {
            foreach ( var player in players )
            {
                player.ShowInfo ();
            }
        }

        private void ShowServer ()
        {
            foreach ( var player in _players )
            {
                player.ShowInfo ();
            }
        }
    }

    class Player
    {
        public Player( string name, int lvl, int power )
        {
            Name = name;
            Lvl = lvl;
            Power = power;
        }

        public string Name { get; private set; }
        public int Lvl { get; private set; }
        public int Power { get; private set; }

        public void ShowInfo ()
        {
            Console.WriteLine ($"{Name} \tLvl {Lvl} сила {Power}");
        }
    }
}
/*Задача:
У нас есть список всех игроков(минимум 10). 
У каждого игрока есть поля: имя, уровень, сила. 
Требуется написать запрос для определения топ 3 игроков по уровню и топ 3 игроков по силе, 
после чего вывести каждый топ.
2 запроса получится.*/