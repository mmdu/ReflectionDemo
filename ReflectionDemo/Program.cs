using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class Program
    {
        class A
        {
            [Required]
            public string myProperty { get; set; }

            public void Function(string a)
            {
                System.Console.WriteLine(a);
            }

             
        }

        
        static void Main(string[] args)
        {
            A a=new A();
            Type t = typeof(A);
            Type t1 = a.GetType();
            if (t.IsEquivalentTo(t1))
            {
            Console.WriteLine("t is equal t1" );

            }
           // var properties=t.GetProperty("myProperty");
          //  properties.SetValue(a, "99",null);
            Console.WriteLine(a.myProperty);
            var method = t.GetMethod("Function");
            method.Invoke(a, new object[] {"abc"});


        // test the property is used or not , see above commented 
        //  SetValue

            if (RequiredAttribute.isPropertyRequired(a))
            {
                Console.WriteLine("the property is used ");
            }
            else
            {
                Console.WriteLine(" this property is not used ");
            }
        }
    }

    // class for customed made attribute

    [AttributeUsage(AttributeTargets.Property)]
    internal class RequiredAttribute : Attribute
    {
        public static bool isPropertyRequired(object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var attributes= property.GetCustomAttributes(typeof(RequiredAttribute), false);
                if (attributes.Length > 0)
                {
                    if (property.GetValue(obj, null) == null)
                        return false;
                }
            }
            return true;

        }
    }
}
