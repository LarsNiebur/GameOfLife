using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    // Die Hauptklasse des Programms
    internal class Program
    {
        // Öffentliche statische Variablen für die Größe des Spielfelds
        static public int zeilen = 20;
        static public int spalten = 40;

        // Das zweidimensionale Array repräsentiert das Spielfeld
        static public char[,] spielfeld = new char[zeilen + 1, spalten + 1];

        // Position des Sterns auf dem Spielfeld
        static public int stern_x = 1;
        static public int stern_y = 1;

        // Die Hauptmethode des Programms
        static void Main(string[] args)
        {
            // Versteckt den Cursor in der Konsole, um Flackern zu vermeiden
            Console.CursorVisible = false;

            // Initialisiert das Spielfeld mit Grenzen und einem Stern
            initSpielfeld();

            // Endlosschleife zur Aktualisierung des Spiels
            while (true)
            {
                // Setzt den Cursor am Anfang der Konsole, um das Flackern zu minimieren
                Console.SetCursorPosition(0, 0);

                // Berechnet die neue Position des Sterns
                berechneStern();

                // Zeichnet das Spielfeld neu
                zeichneSpielfeld();

                // Wartet 16 Millisekunden vor der nächsten Aktualisierung
                Thread.Sleep(16);
            }
            // Diese Zeile wird nie erreicht, da oben eine Endlosschleife ist
            Console.ReadKey();
        }

        // Initialisiert das Spielfeld
        static void initSpielfeld()
        {
            // Füllt das Spielfeld Array mit den entsprechenden Zeichen
            for (int y = 0; y <= zeilen; y++)
            {
                for (int x = 0; x <= spalten; x++)
                {
                    if (y == 0 || y == zeilen) // Setzt die obere und untere Grenze
                    {
                        spielfeld[y, x] = '#';
                    }
                    else if (x == 0 || x == spalten) // Setzt die linke und rechte Grenze
                    {
                        spielfeld[y, x] = '#';
                    }
                    else if (x == stern_x && y == stern_y) // Setzt den Stern an der Startposition
                    {
                        spielfeld[y, x] = '*';
                    }
                    else // Füllt den restlichen Raum mit Leerzeichen
                    {
                        spielfeld[y, x] = ' ';
                    }
                }
            }
        }

        // Berechnet die neue Position des Sterns
        static void berechneStern()
        {
            // Entfernt den Stern von der aktuellen Position
            spielfeld[stern_y, stern_x] = ' ';

            // Bewegt den Stern nach rechts
            stern_x = stern_x + 1;

            // Überprüft, ob der Stern die rechte Grenze erreicht hat
            if (stern_x >= spalten)
            {
                stern_x = 1; // Setzt den Stern an den Anfang der nächsten Zeile
                stern_y = stern_y + 1;

                // Überprüft, ob der Stern die untere Grenze erreicht hat
                if (stern_y >= zeilen)
                {
                    stern_y = 1; // Setzt den Stern zurück an den Anfang
                }
            }

            // Setzt den Stern an die neue Position
            spielfeld[stern_y, stern_x] = '*';
        }

        // Zeichnet das Spielfeld
        static void zeichneSpielfeld()
        {
            string output = "";
            // Erstellt einen String aus dem Array des Spielfelds
            for (int y = 0; y <= zeilen; y++)
            {
                for (int x = 0; x <= spalten; x++)
                {
                    output += spielfeld[y, x];
                }
                output += "\n"; // Fügt am Ende jeder Zeile einen Zeilenumbruch hinzu
            }
            // Gibt das Spielfeld in der Konsole aus
            Console.WriteLine(output);
        }
    }
}