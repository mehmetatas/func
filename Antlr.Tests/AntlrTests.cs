using System;
using System.IO;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Antlr.Tests.Program;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Antlr.Tests
{
    [TestClass]
    public class AntlrTests
    {
        private const string dir = @"C:\Mehmet\Code\VS2012\func\Antlr.Tests\Grammar\";
        // private const string dir = @"C:\Mehmet\Bitbucket\func\Antlr.Tests\Grammar\Func\";
        private const string funcDir = dir + @"Func\";
        private const string jcDir = dir + @"jc\";

        [TestMethod]
        public void ParseFunc()
        {
            var expression = File.ReadAllText(funcDir + "test.func");
            var programTree = GetProgramTree(expression);
        }

        [TestMethod]
        public void ParseJc() {
            var expression = File.ReadAllText(jcDir + "sample.jc");
            var tree = GetJcAST(expression);
        }

        [TestMethod]
        public void ParseDecimal() {
            Assert.AreEqual(12.0M, Decimal.Parse("12.0"));
        }

        [TestMethod]
        public void BuildProgram() {
            var expression = File.ReadAllText(funcDir + "test.func");
            var programTree = GetProgramTree(expression);
            var program = ProgramContext.Create(programTree);
            program.Run();
        }

        [TestMethod]
        public void TestCalc() {
            var x = 3 + 2 - - -2 * 5 - 9 / 3 + 8;

            var expression = "x = 3 + 2 - --2 * 5 - 9 / 3 + 8;";
            var lexer = new CalcLexer(new ANTLRStringStream(expression));
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new CalcParser(tokenStream);
            parser.TreeAdaptor = new CommonTreeAdaptor();
            var ast = parser.build();
            var tree = ast.Tree;
        }

        private static ProgramNode GetProgramTree(string expression) {
            var tree = GetFuncAST(expression);

            var funcNode = ProgramNode.Root();
            BuildTree(tree, funcNode);
            return funcNode;
        }

        private static CommonTree GetFuncAST(string expression)
        {
            var lexer = new FuncLexer(new ANTLRStringStream(expression));
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new FuncParser(tokenStream);
            parser.TreeAdaptor = new CommonTreeAdaptor();
            var ast = parser.build();
            var tree = ast.Tree;
            return tree;
        }

        private static CommonTree GetJcAST(string expression)
        {
            var lexer = new jcLexer(new ANTLRStringStream(expression));
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new jcParser(tokenStream);
            parser.TreeAdaptor = new CommonTreeAdaptor();
            var ast = parser.build();
            var tree = ast.Tree;
            return tree;
        }

        private static void BuildTree(BaseTree tree, ProgramNode rootNode) {
            for(var i = 0; i < tree.ChildCount; i++) {
                var node = tree.Children[i];

                if(node.Type == BaseRecognizer.DefaultTokenChannel)
                    throw new Exception("Invalid expression syntax");

                if(node.Type == FuncLexer.EOF) {
                    if(rootNode.Type != node.Type)
                        throw new Exception("Invalid expression syntax");
                    break;
                }

                if(node.Type == FuncLexer.OPEN_PAR ||
                    node.Type == FuncLexer.COMMA ||
                    node.Type == FuncLexer.SEMICOL)
                    continue;

                switch(node.Type) {
                    case FuncLexer.FUNC:
                    case FuncLexer.METHOD:
                        rootNode = rootNode.AddChild(node.Type, node.Text);
                        break;
                    case FuncLexer.CLOSE_PAR:
                        rootNode = rootNode.Parent;
                        break;
                    default:
                        rootNode.AddChild(node.Type, node.Text);
                        break;
                }
            }
        }
    }
}