using System.IO;
using UniRx.Async;
using UnityEngine;

namespace UniFoundation.Files
{
    public static class PersistentData
    {
        public static string GetAbsolutePath(string relativePath)
        {
            return Path.Combine(Application.persistentDataPath, relativePath);
        }
        
        public static byte[] ReadBinary(string relativePath)
        {
            return FileIO.ReadBinary(GetAbsolutePath(relativePath));
        }

        public static UniTask<byte[]> ReadBinaryAsync(string relativePath)
        {
            return FileIO.ReadBinaryAsync(GetAbsolutePath(relativePath));
        }

        public static bool ReadBinary(string relativePath, long fileOffset, byte[] buffer, int bufferOffset, int numberOfBytes)
        {
            return FileIO.ReadBinary(GetAbsolutePath(relativePath), fileOffset, buffer, bufferOffset, numberOfBytes);
        }

        public static void WriteBinary(string relativePath, byte[] data)
        {
            FileIO.WriteBinary(GetAbsolutePath(relativePath), data);
        }

        public static string ReadText(string relativePath)
        {
            return FileIO.ReadText(GetAbsolutePath(relativePath));
        }

        public static void WriteText(string relativePath, string data)
        {
            FileIO.WriteText(GetAbsolutePath(relativePath), data);
        }        
    }
}