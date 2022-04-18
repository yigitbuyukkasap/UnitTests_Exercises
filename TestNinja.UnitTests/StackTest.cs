using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTest
    {
        [Test]
        public void Push_WhenObjectIsNull_ArgumentNullException()
        {
            var stack = new Stack<string>();
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException) ;
        }
        [Test]
        public void Push_ValidArg_AddTheObjToTheStack()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            Assert.That(stack.Count, Is.EqualTo(1)) ;
        }
        [Test]
        public void Push_EmptyStack_ReturnZero()
        {
            var stack = new Stack<string>();
            Assert.That(stack.Count, Is.EqualTo(0)) ;
        }

        [Test]
        public void Pop_StackWithAFewObj_ThrowInvvalidOperationException()
        {
            var stack = new Stack<string>();
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }
        [Test]
        public void Pop_StackWithAFewObj_ReturnObjOnTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Pop();
            Assert.That(result, Is.EqualTo("c")) ;

        }
        [Test]
        public void Pop_StackWithAFewObj_RemoveObjOnTheTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            stack.Pop();
            Assert.That(stack.Count, Is.EqualTo(2));

        }

        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }
        
        [Test]
        public void Peek_StackWithObj_ReturnObjTopOfTheObj()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Peek();
            Assert.That(result, Is.EqualTo("c"));
        }
        [Test]
        public void Peek_StackWithObj_DoesNotRemoveTheObjOnTopOfTheStack()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            stack.Peek();
            Assert.That(stack.Count, Is.EqualTo(3));
        }
    }
}
