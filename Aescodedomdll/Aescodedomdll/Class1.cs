using System;
using System.Collections.Generic;
using System.Text;

using System.CodeDom.Compiler;
using System.IO;
using Microsoft.CSharp;
using System.Reflection;

using System.Security.Cryptography;

namespace DynaCode
{

    public class Program
    {


        public string Main(float r, float f, float t, string key)
        {
            byte[] encrypted_array = { 58, 21, 41, 49, 179, 155, 222, 251, 241, 17, 99, 63, 84, 6, 248, 224, 60, 62, 227, 143, 210, 253, 88, 140, 254, 194, 196, 254, 176, 34, 218, 68, 8, 211, 202, 23, 89, 105, 14, 34, 208, 42, 147, 25, 199, 242, 232, 172, 244, 158, 6, 140, 190, 66, 66, 126, 51, 109, 216, 95, 104, 115, 128, 222, 117, 78, 91, 136, 138, 166, 124, 169, 98, 246, 113, 69, 75, 155, 1, 210, 26, 31, 214, 121, 90, 187, 128, 28, 190, 209, 228, 194, 185, 203, 117, 94, 8, 132, 188, 239, 85, 86, 176, 163, 57, 185, 99, 111, 198, 217, 176, 176, 217, 200, 174, 236, 125, 97, 201, 19, 174, 253, 184, 207, 35, 139, 184, 245, 98, 31, 11, 83, 202, 85, 221, 192, 177, 138, 84, 182, 223, 145, 196, 152, 67, 90, 178, 236, 39, 231, 215, 207, 167, 11, 127, 60, 242, 176, 50, 12, 252, 14, 136, 122, 27, 19, 128, 41, 16, 29, 209, 130, 18, 83, 54, 198, 255, 201, 143, 82, 160, 33, 90, 215, 100, 215, 1, 78, 197, 196, 111, 126, 66, 21, 83, 128, 77, 34, 175, 98, 160, 230, 131, 252, 71, 115, 37, 96, 103, 238, 0, 109, 207, 25, 119, 203, 127, 8, 125, 89, 152, 37, 239, 84, 33, 220, 184, 30, 70, 38, 111, 169, 116, 250, 15, 224, 120, 39, 209, 255, 24, 166, 78, 228, 161, 78, 227, 60, 213, 209, 124, 244, 166, 104, 224, 190, 206, 190, 56, 83, 68, 103, 229, 242, 240, 33, 212, 186, 132, 85, 5, 23, 244, 39, 195, 34, 90, 247, 180, 126, 36, 93, 231, 248, 235, 211, 101, 131, 62, 86, 247, 50, 169, 228, 69, 51, 60, 122, 245, 14, 79, 122, 17, 20, 32, 0, 50, 136, 57, 3, 7, 25, 247, 155, 76, 195, 186, 22, 192, 80, 174, 238, 209, 76, 36, 128, 5, 104, 99, 84, 130, 18, 108, 207, 118, 103, 114, 143, 178, 82, 25, 31, 113, 169, 236, 43, 242, 161, 251, 77, 191, 164, 61, 18, 242, 184, 98, 58, 188, 26, 122, 111, 90, 214, 5, 105, 143, 89 };
            string code = "";
            string result = "";
            string key_input = key;


            using (AesCryptoServiceProvider myAes = new AesCryptoServiceProvider())
            {
                ///custom Keys

                string custom_IV = "dolbydotiodolbyx";
                byte[] custom_IV_bytes = System.Text.Encoding.UTF8.GetBytes(custom_IV);
                string custom_key = "dolbydotiodolbyiodolbydotiodolby";
                byte[] custom_key_bytes = System.Text.Encoding.UTF8.GetBytes(custom_key);

                code = DecryptStringFromBytes_Aes(encrypted_array, custom_key_bytes, custom_IV_bytes);

                //Console.WriteLine("Decrypting.......: {0}", code);
            }

            result = CompileAndRun(code, r, f, t);

            //Console.ReadKey();
            return result;
        }

        public static string CompileAndRun(string code, float r, float f, float t)
        {
            CompilerParameters CompilerParams = new CompilerParameters();
            string outputDirectory = Directory.GetCurrentDirectory();
            float radius = r;
            float force = f;
            float theta = t;
            string result = "";
            CompilerParams.GenerateInMemory = true;
            CompilerParams.TreatWarningsAsErrors = false;
            CompilerParams.GenerateExecutable = false;
            CompilerParams.CompilerOptions = "/optimize";

            string[] references = { "System.dll" };
            CompilerParams.ReferencedAssemblies.AddRange(references);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults compile = provider.CompileAssemblyFromSource(CompilerParams, code);

            if (compile.Errors.HasErrors)
            {
                string text = "Compile error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    text += "rn" + ce.ToString();
                }
                throw new Exception(text);
            }

            //ExpoloreAssembly(compile.CompiledAssembly);

            Module module = compile.CompiledAssembly.GetModules()[0];
            Type mt = null;
            MethodInfo methInfo = null;

            if (module != null)
            {
                mt = module.GetType("DynaCore.DynaCore");
            }

            if (mt != null)
            {
                methInfo = mt.GetMethod("Main");
            }

            if (methInfo != null)
            {
                //Console.WriteLine(methInfo.Invoke(null, new object[] { r, f, t }));
                result = methInfo.Invoke(null, new object[] { r, f, t }).ToString();
            }
            return result;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                string custom_IV = "dolbydotiodolbyx";
                byte[] custom_IV_bytes = System.Text.Encoding.UTF8.GetBytes(custom_IV);
                string custom_key = "dolbydotiodolbyiodolbydotiodolby";
                byte[] custom_key_bytes = System.Text.Encoding.UTF8.GetBytes(custom_key);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(custom_key_bytes, custom_IV_bytes);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        static void ExpoloreAssembly(Assembly assembly)
        {
            //Console.WriteLine("Modules in the assembly:");
            foreach (Module m in assembly.GetModules())
            {
                //Console.WriteLine("{0}", m);

                foreach (Type t in m.GetTypes())
                {
                    //Console.WriteLine("t{0}", t.Name);

                    foreach (MethodInfo mi in t.GetMethods())
                    {
                        //Console.WriteLine("tt{0}", mi.Name);
                    }
                }
            }
        }
    }
}