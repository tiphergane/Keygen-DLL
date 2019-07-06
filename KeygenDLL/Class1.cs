using System;
using System.Text;


namespace KeygenDLL
{
    public class Class1
    {

        #region liste des keygens

        public string[] Data()
        {
            string[] KeyList = new string[] { "keygen1", "keygen2", "keygen3" };
            return KeyList;
        }

        #endregion

        #region choix du keygen
        /// <summary>
        /// Pour savoir sur quel keygen on doit travailler.
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="miaou"></param>
        /// <returns></returns>
        public string Choix(string menu, string miaou)
        {
            switch (menu)
            {
                case "keygen1":
                    return Keygen1(miaou); //on récupère la réponse du keygen avec en paramètre le pseudonyme.
                case "keygen2":
                    return Keygen2(miaou);
                case "keygen3":
                    return Keygen3(miaou);
                default:
                    return "Vous devez choisir un keygen";
            }
        }
        #endregion

        #region Keygen1
        /// <summary>
        /// création du premier Keygen de la DLL, tout le code est transposé dans la DLL
        /// on ne s'occupe pas de la GUI ici.
        /// </summary>
        /// <param name="pseudo"></param>
        /// <returns></returns>
        public string Keygen1(string pseudo)
        {

            if (pseudo.Length > 3 && pseudo.Length < 28)
            {
                // Pour encoder en UTF8 notre chaine de caractère
                byte[] Name = Encoding.Default.GetBytes(pseudo);
                string Nickname = Encoding.UTF8.GetString(Name);

                string Serial_debut = null;
                string Serial_fin = null;
                string result = null;
                int Serial = 0;
                char[] asciiBytes = Nickname.ToCharArray();
                byte[] array = {0x0B, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00,
                                0x11, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00,
                                0x0C, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00,
                                0x05, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00,
                                0x10, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00,
                                0x0B, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00,
                                0x0E, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00,
                                0x04, 0x00, 0x00, 0x00, 0x0B, 0x00, 0x00, 0x00,
                                0x06, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00,
                                0x0E, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00,
                                0x0B, 0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00,
                                0x0C, 0x00, 0x00, 0x00, 0x0B, 0x00, 0x00, 0x00,
                                0x0A, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00,
                                0x0A, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00,
                                0x10, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00,
                                0x04, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00,
                                0x0A, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00,
                                0x10, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00,
                                0x0A, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00,
                                0x10, 0x00, 0x00, 0x00};

                //Génération du début du serial
                for (int i = 3; i < pseudo.Length; ++i)
                {
                    Serial += asciiBytes[i] * array[(i - 3) * 4];
                    Serial_debut = Serial.ToString();
                }

                Serial = 0;

                //Génération de la fin du serial
                for (int i = 3; i < pseudo.Length; ++i)
                {
                    Serial += asciiBytes[i] * asciiBytes[i - 1] * array[(i - 3) * 4];
                    Serial_fin = Serial.ToString();
                }

                //Affichage du Serial
                result = String.Format("{0}-{1}", Serial_debut, Serial_fin);
                //transmet hors de la DLL le résultat de la génération
                return result;
            }
            else
            {
                //Transmet hors de la DLL les conditions pour avoir un numéro de série.
                return "Vous devez être entre 3 et 28 caractères";
            }
        }
        #endregion

        #region Keygen2
        /// <summary>
        /// création du premier Keygen de la DLL, tout le code est transposé dans la DLL
        /// on ne s'occupe pas de la GUI ici.
        /// </summary>
        /// <param name="pseudo"></param>
        /// <returns></returns>
        public string Keygen2(string pseudo)
        {
            if (pseudo.Length > 1)
            {
                byte[] Name = Encoding.Default.GetBytes(pseudo);
                string Nickname = Encoding.UTF8.GetString(Name);

                string Serial_fin = null;
                string Serial_debut = null;
                int ecx = 0;
                int eax = 0;
                int esi = 0;
                int Serial = 0;
                int j = 0;
                char[] asciiBytes = Nickname.ToCharArray();

                //calcul de la fin du serial
                for (int i = 0; i < pseudo.Length; ++i)
                {
                    Serial += asciiBytes[i] * j;
                    j++;
                    Serial_fin = Serial.ToString("x4");
                }

                Serial = 0;
                //Transmet hors de la DLL le résultat de la génération
                //return Serial_fin;

                for (int l = 0; l < pseudo.Length; l++)
                {
                    ecx = asciiBytes[l] * 0x100;
                    int boucle = 8;
                    for (int k = boucle; k > 0; k--)
                    {
                        esi = eax;
                        esi ^= ecx, ecx;
                        int si = esi % 10000;
                        if (si != Math.Abs(si))
                        {
                            eax <<= 1; //shl en asm, décalage des bits vers la gauche
                        }
                        else
                        {
                            eax += eax;
                            eax ^= 0x1021;
                        }
                        ecx <<= 1;
                    }
                    ecx += 1;
                }
                eax += 0x63;
                Serial_debut = eax.ToString("x4").Substring(4);
                string result = String.Format("{0:X4}{1:X4}", Serial_debut, Serial_fin).ToUpper();
                return result;
            }

            else
            {
                //Transmet hors de la DLL les conditions pour avoir un numéro de série
                return "vous devez entrer au moins 2 caractères";
            }
        }
        #endregion

        #region Keygen3
        public string Keygen3(string pseudo)
        {
            if (pseudo.Length > 4)
            {
                byte[] Name = Encoding.Default.GetBytes(pseudo);
                string Nickname = Encoding.UTF8.GetString(Name);

                string SerialEnd = null;
                uint ecx = 0x4E6AF4BC;
                char[] asciiBytes = Nickname.ToCharArray();

                //calcul de la fin du serial
                for (int i = 0; i < (pseudo.Length - 3); ++i)
                {
                    ecx += ecx ^ asciiBytes[i];
                    ecx <<= 1;
                }
                SerialEnd = ecx.ToString();
                string result = String.Format("{0}-{1}", "MEOOW", SerialEnd);
                return result;
            }
            else
            {
                return "vous devez avoir plus de quatres caractères";
            }
        }
        #endregion 
    }
}
