namespace MGU.Core.Tests.Options
{
    using System;
    using Core.Extensions.Cast;
    using Microsoft.CSharp.RuntimeBinder;
    using Xunit;

    public class CastOptionsTests
    {
        [Fact]
        public void To_Should_Return_Correct_Value()
        {
            object source = 5;
            Assert.Equal(5, source.Cast().To<int>());
            Assert.Equal(5, source.Cast().To<int>(true));
            Assert.Equal((uint) 5, source.Cast().To<uint>(true));

            source = -1;
            Assert.Equal(-1, source.Cast().To<int>());
            Assert.Equal(-1, source.Cast().To<int>(true));
            Assert.Equal(uint.MaxValue, source.Cast().To<uint>(true));
        }

        [Fact]
        public void To_Should_Throw_Exceptions()
        {
            object source = null;
            Assert.Throws<NullReferenceException>(() => source.Cast().To<int>());
            Assert.Throws<RuntimeBinderException>(() => source.Cast().To<int>(true));

            source = 5;
            Assert.Throws<InvalidCastException>(() => source.Cast().To<uint>());
        }

        [Fact]
        public void ToOrDefault_Should_Return_Correct_Value()
        {
            object source = 5;
            Assert.Equal(5, source.Cast().ToOrDefault<int>());
            Assert.Equal(5, source.Cast().ToOrDefault<int>(true));

            source = -1;
            Assert.Equal(-1, source.Cast().ToOrDefault<int>());
            Assert.Equal(-1, source.Cast().ToOrDefault<int>(true));
            Assert.Equal(uint.MaxValue, source.Cast().ToOrDefault<uint>(true));
        }

        [Fact]
        public void ToOrDefault_Should_Return_Default_Value()
        {
            object source = null;
            Assert.Equal(0, source.Cast().ToOrDefault<int>());
            Assert.Equal(0, source.Cast().ToOrDefault<int>(true));

            source = 5;
            Assert.Equal((uint) 0, source.Cast().ToOrDefault<uint>());
        }
    }
}