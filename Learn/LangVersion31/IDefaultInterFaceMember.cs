using System;

namespace LangVersion31 {
    internal interface IDefaultInterFaceMember {
        void Foo() { // not allow before C# 8.0
            Console.WriteLine("Default Implementation of Foo");
        }
    }

    internal class ConcreteClass : IDefaultInterFaceMember { }
}