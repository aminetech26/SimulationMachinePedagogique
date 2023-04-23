using System;
using System.Numerics;

namespace ArchiMind
{
    internal class Erreur {
    
   public static string correctionFormat(string valueInHexa)
    // cette fonction rajoute les 0 unitiles a la gauche ,
    // elle est utiles quand on manipule les registre en binaire 
    { string value = valueInHexa;
        while (value.Length < 16)
        {
            value = value.Insert(0,'0'.ToString());
        }
        return value;
    }
        public static bool IsHex(string input)
        {    // verifie si le code est ecrit en hexa 
            foreach (char c in input)
            {
                if (!char.IsDigit(c) && !(c >= 'A' && c <= 'F') && !(c >= 'a' && c <= 'f')) // Vérifie si chaque caractère est un chiffre hexadécimal
                    return false;
            }

            return true;
        }
    }

  }