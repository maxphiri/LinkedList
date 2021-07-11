using System;
using Xunit;

namespace StringCalculator.Test
{
    public class LinkedListTests
    {

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void Push_PushNodeToHead_WhenNodeIsValid(int data, int expected)
        {
            //Arrange
            var node = new Node<int>(data);
            LinkedList<int> _sut = new LinkedList<int>();

            //Act
            _sut.Push(node);

            //Assert
            Assert.Equal(expected, _sut.Head.Data);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        public void Delete_DeleteNode_WhenNodesAreValid(int position, int expected)
        {
            //Arrange
            LinkedList<int> _sut = new LinkedList<int>();
            _sut.Append(new Node<int>(2));
            _sut.Append(new Node<int>(4));
            _sut.Append(new Node<int>(5));

            //Act
            _sut.DeleteByPositin(position);

            //Assert
            Assert.Equal(expected, _sut.Length());
        }

        [Fact]
        public void PrintList_PrintNodeValueAsString_WhenNodesAreValid()
        {
            // Arrange
            var expected = "3,4,5";
            var _sut = new LinkedList<int>();
            _sut.Append(new Node<int>(3));
            _sut.Append(new Node<int>(4));
            _sut.Append(new Node<int>(5));

            // Act
            var result = _sut.PrintList();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
