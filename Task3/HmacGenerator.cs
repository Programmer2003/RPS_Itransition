using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Task3
{
    internal class HmacGenerator
    {
        private KeyValuePair<int, string> move;
        private byte[] key;
        private byte[] hash;

        public HmacGenerator(string[] moves, int key_size = 32)
        {
            GenerateKey(key_size);
            GenerateMove(moves);
            GenerateHMAC();
        }

        private void GenerateKey(int size)
        {
            using (var generator = RandomNumberGenerator.Create())
            {
                var salt = new byte[size];
                generator.GetBytes(salt);
                var generated = ByteArrayToString(salt);

                this.key = Encoding.ASCII.GetBytes(generated);
            }
        }

        private void GenerateMove(string[] moves)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            int index = rand.Next(0, moves.Length);
            move = new KeyValuePair<int, string>(index, moves[index]);
        }
        
        private void GenerateHMAC()
        {
            HMACSHA256 hmac = new HMACSHA256();
            hmac.Initialize();
            hmac.Key = key;
            byte[] value_bytes = Encoding.ASCII.GetBytes(move.Value);
            hmac.ComputeHash(value_bytes);
            this.hash = hmac.Hash;
        }

        public string GetHash() => ByteArrayToString(hash);
        public string GetKey() => Encoding.ASCII.GetString(key);

        public string GetMove() => move.Value;
        public int GetMoveIndex() => move.Key;

        static string ByteArrayToString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes) hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
