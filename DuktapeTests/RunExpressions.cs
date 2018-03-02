using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Duktape.Tests {
  [TestClass]
  public class EvalExpressionsTests {

    [TestMethod]
    public void IntSumTest() {
      var value = new Context().Run("1+2");
      Assert.IsInstanceOfType(value, typeof(int));
      Assert.AreEqual(3, value);
    }

    [TestMethod]
    public void StringBatmanTest() {
      var value = new Context().Run("Array(17).join('a'-1) + ' Batmaaaan!'");
      Assert.IsInstanceOfType(value, typeof(string));
      Assert.AreEqual("NaNNaNNaNNaNNaNNaNNaNNaNNaNNaNNaNNaNNaNNaNNaNNaN Batmaaaan!", value);
    }

  }
}
