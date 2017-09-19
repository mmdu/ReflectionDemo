using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializeDemo
{
    [Serializable]
    class A
    {
        public string test = "123456";
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            using (var stream = File.Open(typeof(A).Name + ".bin", FileMode.OpenOrCreate))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(stream, a);

            }

            A after = null;
            using (var steam1 = File.Open(typeof(A).Name + ".bin", FileMode.Open))
            {
                var bf = new BinaryFormatter();
                after = (A)bf.Deserialize(steam1);
            }

            Console.WriteLine(after.test);
        }
    }
}
