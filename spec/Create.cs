using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Moq;

namespace specs
{
    static public class Create
    {
        static public Mock<Stub> an<Stub>() where Stub : class
        {
            return An<Stub>();
        }

        static public Mock<ItemToStub> An<ItemToStub>() where ItemToStub : class
        {
            return new Mock<ItemToStub>();
        }
    }
}
