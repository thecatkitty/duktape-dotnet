using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Duktape.Tests {
  [TestClass]
  public class RunTypesTests {

    [TestMethod]
    public void BooleanTrueTest() {
      var value = new Context().Run("true");
      Assert.IsInstanceOfType(value, typeof(bool));
      Assert.AreEqual(true, value);
    }

    [TestMethod]
    public void BooleanFalseTest() {
      var value = new Context().Run("false");
      Assert.IsInstanceOfType(value, typeof(bool));
      Assert.AreEqual(false, value);
    }

    [TestMethod]
    public void IntegerZeroNodotTest() {
      var value = new Context().Run("0");
      Assert.IsInstanceOfType(value, typeof(int));
      Assert.AreEqual(0, value);
    }

    [TestMethod]
    public void IntegerZeroDotTest() {
      var value = new Context().Run("0.0");
      Assert.IsInstanceOfType(value, typeof(int));
      Assert.AreEqual(0, value);
    }

    [TestMethod]
    public void IntegerNegUniverseNodotTest() {
      var value = new Context().Run("-42");
      Assert.IsInstanceOfType(value, typeof(int));
      Assert.AreEqual(-42, value);
    }

    [TestMethod]
    public void IntegerNegUniverseDotTest() {
      var value = new Context().Run("-42.0");
      Assert.IsInstanceOfType(value, typeof(int));
      Assert.AreEqual(-42, value);
    }

    [TestMethod]
    public void DoublePiTest() {
      var value = new Context().Run("3.1415926");
      Assert.IsInstanceOfType(value, typeof(double));
      Assert.AreEqual(3.1415926, value);
    }

    [TestMethod]
    public void DoubleNegPiTest() {
      var value = new Context().Run("-3.1415926");
      Assert.IsInstanceOfType(value, typeof(double));
      Assert.AreEqual(-3.1415926, value);
    }

  }
}
