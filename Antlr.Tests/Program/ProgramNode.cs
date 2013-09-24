using System.Collections.Generic;

namespace Antlr.Tests.Program
{
    public class ProgramNode
    {
        public int Type { get; private set; }
        public string Text { get; private set; }
        public ProgramNode Parent { get; private set; }

        private readonly IList<ProgramNode> _childNodes;
        public IEnumerable<ProgramNode> ChildNodes {
            get { return _childNodes; }
        }

        private ProgramNode() {
            _childNodes = new List<ProgramNode>();
        }

        public static ProgramNode Root() {
            return new ProgramNode { Type = FuncLexer.EOF, Text = "main" };
        }

        public ProgramNode AddChild(int type, string text) {
            var childNode = new ProgramNode { Text = text, Type = type, Parent = this };
            _childNodes.Add(childNode);
            return childNode;
        }

        public override string ToString() {
            return Type.ToString().PadRight(2) + " : " + Text;
        }
    }
}